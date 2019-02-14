using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using VicinityWCF;
using ClpConnection;
using System.Timers;
using vicinityCLP.Events.Classes;
using RestSharp;
using System.Configuration;
using vicinityCLP;

namespace VicinityCLP
{
    public class ServiceWorker
    {
        private ServiceHost vicinity_wcf_host;
        private List<Device> _devices;
        private List<Thread> _eventThreads;
        private List<string> _actions;

        #region CLP variables

        CLP_Connection clp_connection;

        string clp_user;
        string clp_pass;
        LoginData clp_login_token;

        DateTime clp_login_token_expire;

        #endregion

        
        public Action<Exception> exception;

        public ApplianceMethods app_methods;


        public ServiceWorker()
        {
            clp_connection = new CLP_Connection();
            _devices = new List<Device>();
            _eventThreads = new List<Thread>();
            _actions = new List<string>() { "delayed_baking", "baking", "start", "stop" };
            
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(@"C:\VICINITY\Files\ClpInfo.xml");
            }
            catch
            {

            }

            XmlNode node = xmldoc.SelectSingleNode("/User");

            if (node != null)
            {
                try
                {
                    clp_user = node["username"].InnerText;
                    clp_pass = node["password"].InnerText;
                }
                catch
                {

                }
            }

            clp_login_token = null;
            clp_login_token_expire = DateTime.Now;
            
            exception = null;

            app_methods = new ApplianceMethods();
            
            //events
            List<DeviceEvent> ovenEvents = new List<DeviceEvent>();
            List<DeviceEvent> refrigeratorEvents = new List<DeviceEvent>();
            XmlDocument xmldoc2 = new XmlDocument();
            try
            {
                xmldoc2.Load(@"C:\VICINITY\Files\Events.xml");
                XmlNodeList xmlOvenEvents = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Events/Event");
                XmlNodeList xmlRefrigeratorEvents = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Events/Event");
                foreach (XmlNode ovenEvent in xmlOvenEvents)
                {
                    string eid = ovenEvent.Attributes["eid"].Value;
                    string clpID = ovenEvent["clpID"].InnerText;
                    List<EmergencyLevel> emergencyLevel = null;
                    try
                    {
                        string lvl1 = ovenEvent["level1"].InnerText;
                        string lvl2 = ovenEvent["level2"].InnerText;
                        string lvl3 = ovenEvent["level3"].InnerText;
                        if (!string.IsNullOrEmpty(lvl1) && !string.IsNullOrEmpty(lvl2) && !string.IsNullOrEmpty(lvl3))
                        {
                            emergencyLevel = new List<EmergencyLevel>();
                            int no = int.Parse(lvl3);
                            emergencyLevel?.Add(new EmergencyLevel(no, EmergencyStage.Three));
                            no = int.Parse(lvl2);
                            emergencyLevel?.Add(new EmergencyLevel(no, EmergencyStage.Two));
                            no = int.Parse(lvl1);
                            emergencyLevel?.Add(new EmergencyLevel(no, EmergencyStage.One));
                        }
                    }
                    catch
                    { }
                    ovenEvents?.Add(new DeviceEvent(clpID, eid, emergencyLevel));
                }
                foreach (XmlNode refrigeratorEvent in xmlRefrigeratorEvents)
                {
                    string eid = refrigeratorEvent.Attributes["eid"].Value;
                    string clpID = refrigeratorEvent["clpID"].InnerText;
                    List<EmergencyLevel> emergencyLevel = null;
                    try
                    {
                        string lvl1 = refrigeratorEvent["level1"].InnerText;
                        string lvl2 = refrigeratorEvent["level2"].InnerText;
                        string lvl3 = refrigeratorEvent["level3"].InnerText;
                        if (!string.IsNullOrEmpty(lvl1) && !string.IsNullOrEmpty(lvl2) && !string.IsNullOrEmpty(lvl3))
                        {
                            emergencyLevel = new List<EmergencyLevel>();
                            int no = int.Parse(lvl3);
                            emergencyLevel?.Add(new EmergencyLevel(no, EmergencyStage.Three));
                            no = int.Parse(lvl2);
                            emergencyLevel?.Add(new EmergencyLevel(no, EmergencyStage.Two));
                            no = int.Parse(lvl1);
                            emergencyLevel?.Add(new EmergencyLevel(no, EmergencyStage.One));
                        }
                    }
                    catch
                    { }
                    refrigeratorEvents?.Add(new DeviceEvent(clpID, eid, emergencyLevel));
                }
            }
            catch
            { }
            
            XmlDocument xmldoc3 = new XmlDocument();
            try
            {
                xmldoc3.Load(@"C:\VICINITY\Files\Appliances.xml");
                XmlNodeList xmlAppliances = xmldoc3.SelectNodes("/items/item");
                foreach (XmlNode appliance in xmlAppliances)
                {
                    string type = appliance["type"].InnerText;
                    if (type.Equals("oven"))
                    {
                        _devices?.Add(new Device(appliance["clp"].InnerText, appliance.Attributes["oid"].Value, ovenEvents, DeviceType.oven));
                    }
                    else if (type.Equals("refrigerator"))
                    {
                        _devices?.Add(new Device(appliance["clp"].InnerText, appliance.Attributes["oid"].Value, refrigeratorEvents, DeviceType.refrigerator));
                    }
                }
            }
            catch
            { }
        }

        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    vicinity_wcf_host = new ServiceHost(new VicinityWCFService(), new Uri("http://localhost:8733/VICINITY/VICINITY.svc/"));
                    vicinity_wcf_host.Open();

                    VicinityWCFService wcf_service = (VicinityWCFService)vicinity_wcf_host.SingletonInstance;
                    wcf_service.OnRequestReceived += VicinityWCFService_OnRequestReceived;
                }
                catch (Exception e)
                {
                    Logger.Log(LogMsgType.ERROR, e.ToString(), LogAuthor.Adapter);
                }
            });


            Logger.Log(LogMsgType.INFO, "Service started!", LogAuthor.Adapter);
            //events
            Events();
        }

        public void Stop()
        {
            try
            {
                vicinity_wcf_host?.Close();
                if (_eventThreads != null)
                {
                    foreach(var item in _eventThreads)
                    {
                        item.Abort();
                        item.Join();
                    }
                    _eventThreads?.Clear();
                    _eventThreads = null;
                }
                if (_devices != null)
                {
                    _devices.Clear();
                    _devices = null;
                }
                if (_actions != null)
                {
                    _actions.Clear();
                    _actions = null;
                }
            }
            catch(Exception e)
            {
                Logger.Log(LogMsgType.ERROR, e.ToString(), LogAuthor.Adapter);
            }
            
            Logger.Log(LogMsgType.INFO, "Service and events stopped!", LogAuthor.Adapter);
        }

        private string CLPtokenToString()
        {
            if (clp_login_token == null || clp_login_token_expire < DateTime.Now)
            {
                clp_login_token = clp_connection.getValidCLPToken(clp_user, clp_pass);

                DateTime utc_time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                utc_time = utc_time.AddMilliseconds(clp_login_token.expirationDate);

                clp_login_token_expire = utc_time.ToLocalTime();
            }

            return clp_login_token.token;
        }

        private void VicinityWCFService_OnRequestReceived(object sender, HTTPRequestEventArgs e)
        {
            if (e.clp_params_request)
            {
                string json_response = clp_connection.GetCLPObject(clp_user, CLPtokenToString(), e.AUID);

                CLP_Parameters clp_parameters = new CLP_Parameters();
                clp_parameters.Parse(json_response);
                e.clp_params = clp_parameters.GetParams(e.AUID);
                
                Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] requested parameters from CLP!", LogAuthor.Adapter);
            }
            else
            {
                switch (e.action_type)
                {
                    case RequestActionType.OVEN_DELAYED_BAKING:
                        {
                            if (e.clp_params.ContainsKey("duration") &&
                                e.clp_params.ContainsKey("delay") &&
                                e.clp_params.ContainsKey("temperature") &&
                                e.clp_params.ContainsKey("heater_system"))
                            {
                                try
                                {
                                    int duration = Convert.ToInt32(e.clp_params["duration"]);
                                    int delay = Convert.ToInt32(e.clp_params["delay"]);
                                    int temperature = Convert.ToInt32(e.clp_params["temperature"]);
                                    

                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_POST_DelayedBaking(clp_connection, clp_user, CLPtokenToString(), e.AUID, duration, delay, temperature, e.clp_params["heater_system"].ToUpper());
                                    });


                                    e.action_executed = true;


                                    string logtext = "";
                                    foreach (KeyValuePair<string, string> item in e.clp_params)
                                    {
                                        if (!String.IsNullOrEmpty(logtext))
                                            logtext += "; ";

                                        logtext += item.Key + " = " + item.Value;
                                    }
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: delayed_baking -> " + logtext, LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_BAKING:
                        {
                            if (e.clp_params.ContainsKey("duration") &&
                                e.clp_params.ContainsKey("temperature") &&
                                e.clp_params.ContainsKey("heater_system"))
                            {
                                try
                                {
                                    int duration = Convert.ToInt32(e.clp_params["duration"]);
                                    int temperature = Convert.ToInt32(e.clp_params["temperature"]);


                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_POST_Baking(clp_connection, clp_user, CLPtokenToString(), e.AUID, duration, temperature, e.clp_params["heater_system"].ToUpper());
                                    });


                                    e.action_executed = true;


                                    string logtext = "";
                                    foreach (KeyValuePair<string, string> item in e.clp_params)
                                    {
                                        if (!String.IsNullOrEmpty(logtext))
                                            logtext += "; ";

                                        logtext += item.Key + " = " + item.Value;
                                    }
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: baking -> " + logtext, LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_LIGHT:
                        {
                            if (e.clp_params.ContainsKey("light"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_Light(clp_connection, clp_user, CLPtokenToString(), e.AUID, e.clp_params["light"].ToUpper());
                                    });


                                    e.action_executed = true;

                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: light -> " + e.clp_params["light"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_CHILD_LOCK:
                        {
                            if (e.clp_params.ContainsKey("child_lock"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_ChildLock(clp_connection, clp_user, CLPtokenToString(), e.AUID, e.clp_params["child_lock"].ToUpper());
                                    });


                                    e.action_executed = true;

                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: child lock -> " + e.clp_params["child_lock"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_BAKING_START:
                        {
                            try
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    app_methods.Oven_POST_ActionStart(clp_connection, clp_user, CLPtokenToString(), e.AUID);
                                });
                                
                                e.action_executed = true;
                                
                                Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: start baking ", LogAuthor.Adapter);
                            }
                            catch (Exception ex)
                            {
                                exception?.Invoke(ex);

                                e.action_executed = false;
                            }
                        }
                        break;
                    case RequestActionType.OVEN_BAKING_STOP:
                        {
                            try
                            {
                                Task.Factory.StartNew(() =>
                                {
                                app_methods.Oven_POST_ActionStop(clp_connection, clp_user, CLPtokenToString(), e.AUID);
                                });


                                e.action_executed = true;
                                
                                Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: stop baking ", LogAuthor.Adapter);
                            }
                            catch (Exception ex)
                            {
                                exception?.Invoke(ex);

                                e.action_executed = false;
                            }
                        }
                        break;
                    case RequestActionType.OVEN_HEATER_SYSTEM:
                        {
                            if (e.clp_params.ContainsKey("heater_system_sub"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_HeaterSystem(clp_connection, clp_user, CLPtokenToString(), e.AUID, e.clp_params["heater_system_sub"].ToUpper());
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: heater system -> " + e.clp_params["heater_system_sub"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_SET_MEAT_PROBE_TEMPERATURE:
                        {
                            if (e.clp_params.ContainsKey("set_meat_probe_temp"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_SetMeatProbeTemp(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["set_meat_probe_temp"]));
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: set meat probe temp -> " + e.clp_params["set_meat_probe_temp"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_SET_BAKING_TEMPERATURE:
                        {
                            if (e.clp_params.ContainsKey("set_oven_temperature"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_SetBakingTemp(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["set_oven_temperature"]));
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: set baking temp -> " + e.clp_params["set_oven_temperature"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_SET_BAKING_TIME:
                        {
                            if (e.clp_params.ContainsKey("set_bake_time_minutes"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_SetBakingTime(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["set_bake_time_minutes"]));
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: set baking time -> " + e.clp_params["set_bake_time_minutes"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_ALARM_TIME:
                        {
                            if (e.clp_params.ContainsKey("alarm_time_minutes"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_AlarmTime(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["alarm_time_minutes"]));
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: alarm time -> " + e.clp_params["alarm_time_minutes"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_BAKING_START_TIME_HOUR:
                        {
                            if (e.clp_params.ContainsKey("baking_start_time_hour"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_BakingStartTimeHour(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["baking_start_time_hour"]));
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: baking start time hour -> " + e.clp_params["baking_start_time_hour"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.OVEN_BAKING_START_TIME_MINUTE:
                        {
                            if (e.clp_params.ContainsKey("baking_start_time_minute"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Oven_PUT_BakingStartTimeMinute(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["baking_start_time_minute"]));
                                    });


                                    e.action_executed = true;
                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: baking start time minute -> " + e.clp_params["baking_start_time_minute"].ToUpper(), LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;

                    //refrigerator
                    case RequestActionType.REFRIGERATOR_CHILD_LOCK:
                        {
                            if (e.clp_params.ContainsKey("child_lock"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Refrigerator_PUT_ChildLock(clp_connection, clp_user, CLPtokenToString(), e.AUID, e.clp_params["child_lock"].ToUpper());
                                    });


                                    e.action_executed = true;

                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: child lock -> " + e.clp_params["child_lock"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.REFRIGERATOR_TEMPERATURE:
                        {
                            if (e.clp_params.ContainsKey("refrigerator_temperature"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Refrigerator_PUT_RefrigeratorTemp(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["refrigerator_temperature"]));
                                    });


                                    e.action_executed = true;


                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: refrigerator temperature -> " + e.clp_params["refrigerator_temperature"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.REFRIGERATOR_FREEZER_TEMPERATURE:
                        {
                            if (e.clp_params.ContainsKey("freezer_temperature"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Refrigerator_PUT_FreezerTemp(clp_connection, clp_user, CLPtokenToString(), e.AUID, Int32.Parse(e.clp_params["freezer_temperature"]));
                                    });


                                    e.action_executed = true;

                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: freezer temperature -> " + e.clp_params["freezer_temperature"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.REFRIGERATOR_FASTFREEZE:
                        {
                            if (e.clp_params.ContainsKey("fastfreeze"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Refrigerator_PUT_Fastfreeze(clp_connection, clp_user, CLPtokenToString(), e.AUID, e.clp_params["fastfreeze"].ToUpper());
                                    });


                                    e.action_executed = true;

                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: fastfreeze -> " + e.clp_params["fastfreeze"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                    case RequestActionType.REFRIGERATOR_SUPERCOOL:
                        {
                            if (e.clp_params.ContainsKey("supercool"))
                            {
                                try
                                {
                                    Task.Factory.StartNew(() =>
                                    {
                                        app_methods.Refrigerator_PUT_Supercool(clp_connection, clp_user, CLPtokenToString(), e.AUID, e.clp_params["supercool"].ToUpper());
                                    });


                                    e.action_executed = true;

                                    
                                    Logger.Log(LogMsgType.INFO, "[" + e.AUID + "] action: supercool -> " + e.clp_params["supercool"], LogAuthor.Adapter);
                                }
                                catch (Exception ex)
                                {
                                    exception?.Invoke(ex);

                                    e.action_executed = false;
                                }
                            }
                        }
                        break;
                }
            }
        }

        private void Events()
        {
            if (_devices != null)
            {
                Logger.Log(LogMsgType.INFO, "Events started!", LogAuthor.Adapter);
                foreach (var device in _devices)
                {
                    if (device.Events == null)
                    {
                        continue;
                    }
                    if (device.Properties == null)
                    {
                        string json_response = clp_connection.GetCLPObject(clp_user, CLPtokenToString(), device.AUID);

                        CLP_Parameters clp_parameters = new CLP_Parameters();
                        clp_parameters.Parse(json_response);
                        device.Properties = clp_parameters.GetParams(device.AUID);
                    }
                    Thread thread = new Thread(() => EventCheck(device));
                    thread.IsBackground = true;
                    thread.Start();
                    _eventThreads?.Add(thread);
                }
            }
        }
        private void EventCheck(Device device)
        {
            while (true)
            {
                try
                {
                    if (clp_connection != null && device.Properties != null && device.Events != null && device.Properties.Count > 0 && device.Events.Count > 0)
                    {
                        string json_response = clp_connection.GetCLPObject(clp_user, CLPtokenToString(), device.AUID);

                        CLP_Parameters clp_parameters = new CLP_Parameters();
                        clp_parameters.Parse(json_response);
                        Dictionary<string, string> props = clp_parameters.GetParams(device.AUID);

                        if (props != null)
                        {
                            foreach (var item in device.Events)
                            {
                                if (props.ContainsKey(item.CLPID) && device.Properties.ContainsKey(item.CLPID) &&
                                    !device.Properties[item.CLPID].ToUpper().Equals(props[item.CLPID].ToUpper()))
                                {
                                    //property value has changed
                                    //publish event
                                    device.Properties[item.CLPID] = props[item.CLPID];
                                    string value = props[item.CLPID].ToUpper();
                                    var client = new RestClient("http://localhost:9997/agent/events/" + item.EID);
                                    string json = CreateJSON(device.OID, device.AUID, item.EID, value);
                                    var request = CreateRequest(json, device.OID);

                                    IRestResponse response = client.Execute(request);

                                    string message = "Device: " + device.OID + " property: " + item.CLPID + " has changed to: " + value + Environment.NewLine + response.Content;
                                    Logger.Log(LogMsgType.INFO, message, LogAuthor.Event);

                                    if(item.EID.Equals("device_status") && (value.ToUpper().Equals("IDLE")))
                                    {
                                        SetBakingStatus(device.Events, CookingStatus.None);
                                        ChangeActionStatus(device.OID, device.AUID);
                                    }
                                    else if ((item.EID.Equals("refrigerator_door") || item.EID.Equals("freezer_door") || item.EID.Equals("door")) && 
                                              value.ToUpper().Equals("OPENED"))
                                    {
                                        item.LastChanged = DateTime.Now;
                                        item.EmergencyStage = EmergencyStage.None;
                                        item.CookingStatus = CookingStatus.None;
                                    }
                                    else if (item.EID.Equals("device_status") && value.ToUpper().Equals("AFTER_BAKE"))
                                    {
                                        SetBakingStatus(device.Events, CookingStatus.BakingFinished);
                                    }
                                }
                                else if (item.EmergencyLevel != null && item.LastChanged.Year >= 2018 && item.EmergencyStage != EmergencyStage.Three && 
                                       ((device.DeviceType == DeviceType.refrigerator && device.Properties[item.CLPID].ToUpper().Equals("OPENED")) || 
                                        (device.DeviceType == DeviceType.oven && device.Properties[item.CLPID].ToUpper().Equals("CLOSED") && item.CookingStatus == CookingStatus.BakingFinished)))
                                {
                                    DateTime now = DateTime.Now;
                                    foreach (var level in item.EmergencyLevel)
                                    {
                                        int index = item.EmergencyLevel.IndexOf(level);
                                        if ((now-item.LastChanged).TotalMinutes >= level.Min && index == (int)item.EmergencyStage)
                                        {
                                            int lvl = (int)level.Stage;
                                            string eventID = device.DeviceType.ToString() + "_emergency";
                                            var client = new RestClient("http://localhost:9997/agent/events/" + eventID);
                                            string json = CreateJSON(device.OID, device.AUID, eventID, lvl.ToString());
                                            var request = CreateRequest(json, device.OID);

                                            IRestResponse response = client.Execute(request);

                                            string message = "Device: " + device.OID + " Emergency Level: " + lvl + Environment.NewLine + response.Content;
                                            Logger.Log(LogMsgType.INFO, message, LogAuthor.Event);
                                            item.EmergencyStage = (EmergencyStage)(index + 1);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Logger.Log(LogMsgType.ERROR, "Device: " + device.OID + " " + e.ToString(), LogAuthor.Event);
                }
            }
        }

        private void ChangeActionStatus(string deviceID, string AUID, string newStatus = "finished")
        {
            try
            {
                if (_actions != null)
                {
                    foreach(var action in _actions)
                    {
                        var client = new RestClient("http://localhost:9997/agent/actions/" + action);

                        string json = CreateJSON(deviceID, AUID, action, newStatus);
                        var request = CreateRequest(json, deviceID, newStatus);
                        IRestResponse response = client.Execute(request);

                        string message = "Device: " + deviceID + " action: " + action + " has changed to: " + newStatus + Environment.NewLine + response.Content;
                        Logger.Log(LogMsgType.INFO, message, LogAuthor.Adapter);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log(LogMsgType.ERROR, "Device: " + deviceID + " " + e.ToString(), LogAuthor.Adapter);
            }
        }

        private string CreateJSON(string deviceID, string AUID, string parameter, string parValue)
        {
            DateTime utc = DateTime.UtcNow;
            string json = @"{
    ""Name"": """ + deviceID + @""",
    ""AUID"": """ + AUID + @""",
    """ + parameter + @""": """ + parValue + @""",
    ""Timestamp"": """ + utc.ToString() + @"""
}";
            return json;
        }

        private RestRequest CreateRequest(string json, string deviceID, string status = null)
        {
            try
            {
                var request = new RestRequest(Method.PUT);

                request.AddHeader("infrastructure-id", deviceID);
                request.AddHeader("adapter-id", "adapter-gorenje");
                //request.AddHeader("adapter-id", "dev-adapter-gorenje");
                if (!string.IsNullOrEmpty(status))
                {
                    request.AddHeader("status", status);
                }
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                return request;
            }
            catch
            {
                return null;
            }
        }

        private void SetBakingStatus(List<DeviceEvent> events, CookingStatus status)
        {
            foreach(var evnt in events)
            {
                if (evnt.EID.ToUpper().Equals("DOOR"))
                {
                    evnt.LastChanged = DateTime.Now;
                    evnt.EmergencyStage = EmergencyStage.None;
                    evnt.CookingStatus = status;
                    break;
                }
            }
        }
    }
}