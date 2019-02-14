using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClpConnection;
using vicinityCLP;

namespace VicinityCLP
{
    public class ApplianceMethods
    {

        private bool ArePropertiesSet(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, Dictionary<string, string> props)
        {
            string json_response = clp_connection.GetCLPObject(clp_user, clp_token, clp_auid);

            CLP_Parameters clp_parameters = new CLP_Parameters();
            clp_parameters.Parse(json_response);
            Dictionary<string, string> dict = clp_parameters.GetParams(clp_auid);


            foreach (KeyValuePair<string, string> item in props)
            {
                if (!dict.ContainsKey(item.Key))
                {
                    return false;
                }

                if (!dict[item.Key].ToUpper().Equals(item.Value.ToUpper()))
                {
                    return false;
                }
            }


            return true;
        }

        #region Methods

        #region Oven

        #region PutLight
        public void Oven_PUT_Light(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, string property_name)
        {
            // Set light property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("OVEN_LIGHT", property_name);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetOvenLight(clp_user, clp_token, clp_auid, property_name);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetOvenLight -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetOvenLight -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetOvenLight -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetOvenLight -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region DelayedBaking
        public void Oven_POST_DelayedBaking(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int duration, int delay, int temperature, string heater)
        {
            /* string response = clp_connection.ActionStop(clp_user, CLPtokenToString(), AUIDs[0]);
            Thread.Sleep(1000); */


            // Set step bake 1 baking properties

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_BAKE_TIME_MINUTES", duration.ToString());
            props.Add("SET_OVEN_TEMPERATURE", temperature.ToString());
            props.Add("HEATER_SYSTEM_SUB",heater);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakeSettings(clp_user, clp_token, clp_auid, "OVEN_SET", duration, heater, temperature);

                int count_check = 0;

                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> action executed", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);

                return;
            }


            Thread.Sleep(750);


            // Set bake delay
            DateTime delay_time = DateTime.Now.AddMinutes(delay);

            clp_connection.OV_SetBakeStartTime(clp_user, clp_token, clp_auid, delay_time.Minute, delay_time.Hour);

            props.Clear();
            props.Add("BAKING_START_TIME_HOUR", delay_time.Hour.ToString());
            props.Add("BAKING_START_TIME_MINUTE", delay_time.Minute.ToString());

            properties_set = false;
            count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakeStartTime(clp_user, clp_token, clp_auid, delay_time.Minute, delay_time.Hour);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakeStartTime -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakeStartTime -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakeStartTime -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetBakeStartTime -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);

                return;
            }
            Thread.Sleep(30000);


            // Start bake action

            clp_connection.OV_ActionStart(clp_user, clp_token, clp_auid);

            Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBake ACTION SET", LogAuthor.Adapter);

        }
        #endregion

        #region Baking
        public void Oven_POST_Baking(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int duration, int temperature, string heater)
        {
            /* string response = clp_connection.ActionStop(clp_user, CLPtokenToString(), AUIDs[0]);
            Thread.Sleep(1000); */


            // Set step bake 1 baking properties

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_BAKE_TIME_MINUTES", duration.ToString());
            props.Add("SET_OVEN_TEMPERATURE", temperature.ToString());
            props.Add("HEATER_SYSTEM_SUB", heater);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakeSettings(clp_user, clp_token, clp_auid, "OVEN_SET", duration, heater, temperature);

                int count_check = 0;

                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> action executed", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetStepBakeSettingsStep1 -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);

                return;
            }
            Thread.Sleep(30000);


            //Start bake action

            clp_connection.OV_ActionStart(clp_user, clp_token, clp_auid);


            Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBake ACTION SET", LogAuthor.Adapter);
        }
        #endregion

        #region ChildLock
        public void Oven_PUT_ChildLock(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, string property_name)
        {
            // Set child lock property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("CHILD_LOCK", property_name);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetChildLock(clp_user, clp_token, clp_auid, property_name);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetChildLock -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetChildLock -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetChildLock -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetChildLock -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region ActionStart
        public void Oven_POST_ActionStart(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid)
        {
            clp_connection.OV_ActionStart(clp_user, clp_token, clp_auid);
            
            Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBake ACTION SET", LogAuthor.Adapter);
        }
        #endregion

        #region ActionStop
        public void Oven_POST_ActionStop(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("DEVICE_STATUS", "IDLE");

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_ActionStop(clp_user, clp_token, clp_auid);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] ActionStop -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] ActionStop -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] ActionStop -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] ActionStop -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region HeaterSystem
        public void Oven_PUT_HeaterSystem(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, string heater)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("HEATER_SYSTEM_SUB", heater);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetHeaterSystem(clp_user, clp_token, clp_auid, heater);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] HeaterSystem -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] HeaterSystem -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] HeaterSystem -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] HeaterSystem -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region SetMeatProbeTemp
        public void Oven_PUT_SetMeatProbeTemp(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int temp)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_MEAT_PROBE_TEMP", "0");

            if (!ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
            {
                props.Clear();
                props.Add("SET_MEAT_PROBE_TEMP", temp.ToString());
                bool properties_set = false;
                int count_repeats = 0;
                while (count_repeats < 5)
                {
                    clp_connection.OV_SetMeatProbeTemp(clp_user, clp_token, clp_auid, temp);

                    int count_check = 0;
                    while (count_check < 2)
                    {
                        if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                        {
                            Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetMeatProbeTemp -> properties OK", LogAuthor.Adapter);
                            break;
                        }
                        
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetMeatProbeTemp -> properties recheck required", LogAuthor.Adapter);

                        count_check++;

                        Thread.Sleep(750);
                    }

                    if (count_check < 2)
                    {
                        properties_set = true;
                        break;
                    }

                    count_repeats++;
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetMeatProbeTemp -> action re-initiating", LogAuthor.Adapter);

                    Thread.Sleep(750);
                }

                if (!properties_set)
                {
                    Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetMeatProbeTemp -> action not executed", LogAuthor.Adapter);

                    ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
                }
            }
            else
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetMeatProbeTemp -> action not executed(meat probe not present)", LogAuthor.Adapter);
            }
        }
        #endregion

        #region SetBakingtemp
        public void Oven_PUT_SetBakingTemp(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int temp)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_OVEN_TEMPERATURE", temp.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakingTemp(clp_user, clp_token, clp_auid, temp);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakingTemp -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakingTemp -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakingTemp -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetBakingTemp -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region SetBakingTime
        public void Oven_PUT_SetBakingTime(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int temp)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_BAKE_TIME_MINUTES", temp.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakingTime(clp_user, clp_token, clp_auid, temp);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakingTime -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakingTime -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetBakingTime -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetBakingTime -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region AlarmTime
        public void Oven_PUT_AlarmTime(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int minutes)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("ALARM_TIME_MINUTES", minutes.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetAlarmTime(clp_user, clp_token, clp_auid, minutes);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] AlarmTime -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] AlarmTime -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] AlarmTime -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] AlarmTime -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region BakingStartTimeHour
        public void Oven_PUT_BakingStartTimeHour(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int hour)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("BAKING_START_TIME_HOUR", hour.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakingStartTimeHour(clp_user, clp_token, clp_auid, hour);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] BakingStartTimeHour -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] BakingStartTimeHour -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] BakingStartTimeHour -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] BakingStartTimeHour -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region BakingStartTimeMinute
        public void Oven_PUT_BakingStartTimeMinute(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int minute)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("BAKING_START_TIME_MINUTE", minute.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.OV_SetBakingStartTimeMinute(clp_user, clp_token, clp_auid, minute);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] BakingStartTimeMinute -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] BakingStartTimeMinute -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] BakingStartTimeMinute -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] BakingStartTimeMinute -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #endregion

        #region Refrigerator

        #region ChildLock
        public void Refrigerator_PUT_ChildLock(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, string property_name)
        {
            // Set child lock property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("CHILD_LOCK", property_name);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.RF_SetChildLock(clp_user, clp_token, clp_auid, property_name);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetChildLock -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetChildLock -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetChildLock -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetChildLock -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region RefrigeratorTemp
        public void Refrigerator_PUT_RefrigeratorTemp(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int temp)
        {
            // Set refrigerator temperature property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_REFRIGERATOR_TEMPERATURE", temp.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.RF_SetFridgeTemp(clp_user, clp_token, clp_auid, temp);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetRefrigeratorTemp -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetRefrigeratorTemp -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetRefrigeratorTemp -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetRefrigeratorTemp -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region FreezerTemp
        public void Refrigerator_PUT_FreezerTemp(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, int temp)
        {
            // Set freezer temperature property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SET_FREEZER_TEMPERATURE", temp.ToString());

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.RF_SetFreezerTemp(clp_user, clp_token, clp_auid, temp);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetFreezerTemp -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetFreezerTemp -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetFreezerTemp -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetFreezerTemp -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region Fastfreeze
        public void Refrigerator_PUT_Fastfreeze(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, string property_name)
        {
            // Set fastfreeze property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("FASTFREEZE_FUNCTION", property_name);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.RF_SetFastFreeze(clp_user, clp_token, clp_auid, property_name);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetFastfreeze -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetFastfreeze -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetFastfreeze -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetFastfreeze -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #region Supercool
        public void Refrigerator_PUT_Supercool(CLP_Connection clp_connection, string clp_user, string clp_token, string clp_auid, string property_name)
        {
            // Set supercool property

            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("SUPERCOOL_FUNCTION", property_name);

            bool properties_set = false;
            int count_repeats = 0;
            while (count_repeats < 5)
            {
                clp_connection.RF_SetSuperCool(clp_user, clp_token, clp_auid, property_name);

                int count_check = 0;
                while (count_check < 2)
                {
                    if (ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props))
                    {
                        Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetSupercool -> properties OK", LogAuthor.Adapter);
                        break;
                    }
                    
                    Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetSupercool -> properties recheck required", LogAuthor.Adapter);

                    count_check++;

                    Thread.Sleep(750);
                }

                if (count_check < 2)
                {
                    properties_set = true;
                    break;
                }

                count_repeats++;
                
                Logger.Log(LogMsgType.INFO, "[" + clp_auid + "] SetSupercool -> action re-initiating", LogAuthor.Adapter);

                Thread.Sleep(750);
            }

            if (!properties_set)
            {
                Logger.Log(LogMsgType.ERROR, "[" + clp_auid + "] SetSupercool -> action not executed", LogAuthor.Adapter);

                ArePropertiesSet(clp_connection, clp_user, clp_token, clp_auid, props);
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
