using System;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class Oven_Response : ApplianceResponse
    {
        private enum AllowedPropertyType
        {
            DEVICE_STATUS,
            LIGHT,
            CHILD_LOCK,
            DOOR,
            CURRENT_TEMPERATURE,
            CURRENT_MEAT_PROBE_TEMPERATURE,
            SET_MEAT_PROBE_TEMPERATURE,
            SET_BAKING_TEMPERATURE,
            SET_BAKING_TIME,
            BAKE_ELAPSED_TIME,
            BAKE_REMAINING_TIME,
            HEATER_SYSTEM,
            ALARM_TIME,
            BAKING_START_TIME_HOUR,
            BAKING_START_TIME_MINUTE,
            SELECTED_HEATER_MIN_TEMPERATURE,
            SELECTED_HEATER_MAX_TEMPERATURE,
            SELECTED_HEATER_DEFAULT_TEMPERATURE,
            SELECTED_HEATER_MEAT_PROBE_ALLOWED,
            SELECTED_HEATER_PREHEAT_ALLOWED,
            invalid_property
        }


        private enum AllowedActionType { DELAYED_BAKING, BAKING, START, STOP, invalid_action }


        public Oven_Response()
            : base()
        { }


        #region Allowed actions/properties

        private AllowedActionType GetAllowedActionType(string action_id)
        {
            try
            {
                return (AllowedActionType)Enum.Parse(typeof(AllowedActionType), action_id, true);
            }
            catch
            { }

            return AllowedActionType.invalid_action;
        }

        private AllowedPropertyType GetAllowedPropertyType(string property_id)
        {
            try
            {
                return (AllowedPropertyType)Enum.Parse(typeof(AllowedPropertyType), property_id, true);
            }
            catch
            { }

            return AllowedPropertyType.invalid_property;
        }

        #endregion


        #region Validity of properties and actions

        public override bool IsValidProperty(string property_id)
        {
            return GetAllowedPropertyType(property_id) != AllowedPropertyType.invalid_property;
        }

        public override bool IsValidAction(string action_id)
        {
            return GetAllowedActionType(action_id) != AllowedActionType.invalid_action;
        }

        #endregion


        public override string Objects_Properties_GET(string object_id, string property_id)
        {
            if (OnRequestReceived == null)
            {
                return "Error: (Objects_Properties_GET:OnRequestReceived = NULL)";
            }



            HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { clp_params_request = true };

            OnRequestReceived.Invoke(this, args);


            if ((args != null) && (args.clp_params != null))
            {
                if (args.clp_params.ContainsKey(property_id.ToUpper()))
                {
                    return args.clp_params[property_id.ToUpper()];
                }
                
                // if defined name does not match with the one, obtained from the oven

                switch (GetAllowedPropertyType(property_id))
                {
                    case AllowedPropertyType.LIGHT:
                        {
                            if (args.clp_params.ContainsKey("OVEN_LIGHT"))
                            {
                                return args.clp_params["OVEN_LIGHT"];
                            }
                        }
                        break;

                    case AllowedPropertyType.DOOR:
                        {
                            if (args.clp_params.ContainsKey("OVEN_DOOR"))
                            {
                                return args.clp_params["OVEN_DOOR"];
                            }
                        }                        
                        break;

                    case AllowedPropertyType.CURRENT_TEMPERATURE:
                        {
                            if (args.clp_params.ContainsKey("CURRENT_OVEN_TEMPERATURE"))
                            {
                                return args.clp_params["CURRENT_OVEN_TEMPERATURE"];
                            }
                        }
                        break; 
                            
                    case AllowedPropertyType.SET_BAKING_TEMPERATURE:
                        {
                            if (args.clp_params.ContainsKey("SET_OVEN_TEMPERATURE"))
                            {
                                return args.clp_params["SET_OVEN_TEMPERATURE"];
                            }
                        }
                        break;

                    case AllowedPropertyType.SET_BAKING_TIME:
                        {
                            if (args.clp_params.ContainsKey("SET_BAKE_TIME_MINUTES"))
                            {
                                return args.clp_params["SET_BAKE_TIME_MINUTES"];
                            }
                        }
                        break;

                    case AllowedPropertyType.BAKE_ELAPSED_TIME:
                        {
                            if (args.clp_params.ContainsKey("ELAPSED_BAKING_TIME_MINUTES"))
                            {
                                return args.clp_params["ELAPSED_BAKING_TIME_MINUTES"];
                            }
                        }
                        break;

                    case AllowedPropertyType.HEATER_SYSTEM:
                        {
                            if (args.clp_params.ContainsKey("HEATER_SYSTEM_SUB"))
                            {
                                return args.clp_params["HEATER_SYSTEM_SUB"];
                            }
                        }
                        break;

                    case AllowedPropertyType.ALARM_TIME:
                        {
                            if (args.clp_params.ContainsKey("ALARM_TIME_MINUTES"))
                            {
                                return args.clp_params["ALARM_TIME_MINUTES"];
                            }
                        }
                        break;

                    case AllowedPropertyType.CURRENT_MEAT_PROBE_TEMPERATURE:
                        {
                            if (args.clp_params.ContainsKey("MEAT_PROBE_TEMP"))
                            {
                                return args.clp_params["MEAT_PROBE_TEMP"];
                            }
                        }
                        break;

                    case AllowedPropertyType.SET_MEAT_PROBE_TEMPERATURE:
                        {
                            if (args.clp_params.ContainsKey("SET_MEAT_PROBE_TEMP"))
                            {
                                return args.clp_params["SET_MEAT_PROBE_TEMP"];
                            }
                        }
                        break;

                    case AllowedPropertyType.BAKE_REMAINING_TIME:
                        {
                            if (args.clp_params.ContainsKey("BAKE_REMAINING_TIME_MINUTES"))
                            {
                                return args.clp_params["BAKE_REMAINING_TIME_MINUTES"];
                            }
                        }
                        break;

                    case AllowedPropertyType.DEVICE_STATUS:
                        {
                            if (args.clp_params.ContainsKey("DEVICE_STATUS"))
                            {
                                return args.clp_params["DEVICE_STATUS"];
                            }
                        }
                        break;

                    case AllowedPropertyType.CHILD_LOCK:
                        {
                            if (args.clp_params.ContainsKey("CHILD_LOCK"))
                            {
                                return args.clp_params["CHILD_LOCK"];
                            }
                        }
                        break;

                    case AllowedPropertyType.BAKING_START_TIME_HOUR:
                        {
                            if (args.clp_params.ContainsKey("BAKING_START_TIME_HOUR"))
                            {
                                return args.clp_params["BAKING_START_TIME_HOUR"];
                            }
                        }
                        break;

                    case AllowedPropertyType.BAKING_START_TIME_MINUTE:
                        {
                            if (args.clp_params.ContainsKey("BAKING_START_TIME_MINUTE"))
                            {
                                return args.clp_params["BAKING_START_TIME_MINUTE"];
                            }
                        }
                        break;

                    case AllowedPropertyType.SELECTED_HEATER_MIN_TEMPERATURE:
                        {
                            return "30";
                        }

                    case AllowedPropertyType.SELECTED_HEATER_MAX_TEMPERATURE:
                        {
                            return "270";
                        }

                    case AllowedPropertyType.SELECTED_HEATER_DEFAULT_TEMPERATURE:
                        {
                            return "180";
                        }

                    case AllowedPropertyType.SELECTED_HEATER_MEAT_PROBE_ALLOWED:
                        {
                            return "true";
                        }

                    case AllowedPropertyType.SELECTED_HEATER_PREHEAT_ALLOWED:
                        {
                            return "true";
                        }

                    default:
                        {
                            return base.Objects_Properties_GET(object_id, property_id);
                        }
                }
            }


            return "Error";
        }


        public override string Objects_Properties_PUT(string object_id, string property_id, params string[] put_data)
        {
            if (OnRequestReceived == null)
            {
                return "Error: (Objects_Properties_PUT:OnRequestReceived = NULL)";
            }


            HTTPRequestEventArgs args = null;


            switch (GetAllowedPropertyType(property_id))
            {
                case AllowedPropertyType.LIGHT:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_LIGHT };
                        
                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("light"))
                        {
                            String light = "";
                            if (put_data.Length == 1)
                            {
                                light = put_data[0];
                            }
                            args.clp_params.Add("light", light);
                        }
                    }
                    break;

                case AllowedPropertyType.CHILD_LOCK:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_CHILD_LOCK };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("child_lock"))
                        {
                            String child_lock = "";
                            if (put_data.Length == 1)
                            {
                                child_lock = put_data[0];
                            }
                            args.clp_params.Add("child_lock", child_lock);
                        }
                    }
                    break;

                case AllowedPropertyType.HEATER_SYSTEM:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_HEATER_SYSTEM };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("heater_system_sub"))
                        {
                            String heater_system_sub = "";
                            if (put_data.Length == 1)
                            {
                                heater_system_sub = put_data[0];
                            }
                            args.clp_params.Add("heater_system_sub", heater_system_sub);
                        }
                    }
                    break;

                case AllowedPropertyType.SET_MEAT_PROBE_TEMPERATURE:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_SET_MEAT_PROBE_TEMPERATURE };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("set_meat_probe_temp"))
                        {
                            String set_meat_probe_temp = "";
                            if (put_data.Length == 1)
                            {
                                set_meat_probe_temp = put_data[0];
                            }
                            args.clp_params.Add("set_meat_probe_temp", set_meat_probe_temp);
                        }
                    }
                    break;

                case AllowedPropertyType.SET_BAKING_TEMPERATURE:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_SET_BAKING_TEMPERATURE };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("set_oven_temperature"))
                        {
                            String set_oven_temperature = "";
                            if (put_data.Length == 1)
                            {
                                set_oven_temperature = put_data[0];
                            }
                            args.clp_params.Add("set_oven_temperature", set_oven_temperature);
                        }
                    }
                    break;

                case AllowedPropertyType.SET_BAKING_TIME:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_SET_BAKING_TIME };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("set_bake_time_minutes"))
                        {
                            String set_bake_time_minutes = "";
                            if (put_data.Length == 1)
                            {
                                set_bake_time_minutes = put_data[0];
                            }
                            args.clp_params.Add("set_bake_time_minutes", set_bake_time_minutes);
                        }
                    }
                    break;

                case AllowedPropertyType.ALARM_TIME:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_ALARM_TIME };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("alarm_time_minutes"))
                        {
                            String alarm_time_minutes = "";
                            if (put_data.Length == 1)
                            {
                                alarm_time_minutes = put_data[0];
                            }
                            args.clp_params.Add("alarm_time_minutes", alarm_time_minutes);
                        }
                    }
                    break;

                case AllowedPropertyType.BAKING_START_TIME_HOUR:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_BAKING_START_TIME_HOUR };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("baking_start_time_hour"))
                        {
                            String baking_start_time_hour = "";
                            if (put_data.Length == 1)
                            {
                                baking_start_time_hour = put_data[0];
                            }
                            args.clp_params.Add("baking_start_time_hour", baking_start_time_hour);
                        }
                    }
                    break;

                case AllowedPropertyType.BAKING_START_TIME_MINUTE:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_BAKING_START_TIME_MINUTE };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("baking_start_time_minute"))
                        {
                            String baking_start_time_minute = "";
                            if (put_data.Length == 1)
                            {
                                baking_start_time_minute = put_data[0];
                            }
                            args.clp_params.Add("baking_start_time_minute", baking_start_time_minute);
                        }
                    }
                    break;

                default:
                    {
                        return base.Objects_Properties_GET(object_id, property_id);
                    }
            }


            if (args != null)
            {
                OnRequestReceived.Invoke(this, args);
            }


            return "OK";
        }


        public override string Objects_Actions_GET(string object_id, string action_id, out string action_desc)
        {
            is_error = false;
            action_desc = "";

            switch (GetAllowedActionType(action_id))
            {
                case AllowedActionType.DELAYED_BAKING:
                    {
                        if (OnRequestReceived == null)
                        {
                            return "Error: (Objects_Actions_GET:OnRequestReceived = NULL)";
                        }


                        HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { clp_params_request = true };

                        OnRequestReceived.Invoke(this, args);

                        string bakingStatus = string.Empty, bakingStartAt = string.Empty, delay = string.Empty, duration = string.Empty, temp = string.Empty, heater = string.Empty;
                        bool is_valid_response = true;

                        if ((args != null) && (args.clp_params != null))
                        {
                            if (args.clp_params.ContainsKey("DEVICE_STATUS"))
                            {
                                bakingStatus = args.clp_params["DEVICE_STATUS"];

                                if (args.clp_params["DEVICE_STATUS"].Equals("DELAY_TIME_WAITING"))
                                {

                                    // start_at parameter

                                    if (args.clp_params.ContainsKey("BAKING_START_TIME_HOUR") && args.clp_params.ContainsKey("BAKING_START_TIME_MINUTE"))
                                    {
                                        try
                                        {
                                            bakingStartAt = Convert.ToInt32(args.clp_params["BAKING_START_TIME_HOUR"]) + ":" + Convert.ToInt32(args.clp_params["BAKING_START_TIME_MINUTE"]).ToString("00");

                                            DateTime time = DateTime.Today.AddHours(Convert.ToInt32(args.clp_params["BAKING_START_TIME_HOUR"])).AddMinutes(Convert.ToInt32(args.clp_params["BAKING_START_TIME_MINUTE"]));
                                            TimeSpan span = new TimeSpan(time.Ticks - DateTime.Now.Ticks);

                                            delay  = span.TotalMinutes.ToString();
                                        }
                                        catch
                                        {
                                            is_valid_response = false;
                                        }
                                    }
                                    else
                                    {
                                        is_valid_response = false;
                                    }


                                    // set duration minutes parameter

                                    if (args.clp_params.ContainsKey("SET_BAKE_TIME_MINUTES"))
                                    {
                                        duration = args.clp_params["SET_BAKE_TIME_MINUTES"];
                                    }
                                    else
                                    {
                                        is_valid_response = false;
                                    }


                                    // set temperature parameter

                                    if (args.clp_params.ContainsKey("SET_OVEN_TEMPERATURE"))
                                    {
                                        temp = args.clp_params["SET_OVEN_TEMPERATURE"];
                                    }
                                    else
                                    {
                                        is_valid_response = false;
                                    }


                                    // set heater_system parameter

                                    if (args.clp_params.ContainsKey("HEATER_SYSTEM_SUB"))
                                    {
                                        heater = args.clp_params["HEATER_SYSTEM_SUB"];
                                    }
                                    else
                                    {
                                        is_valid_response = false;
                                    }
                                }else if (args.clp_params["DEVICE_STATUS"].Equals("IDLE") || args.clp_params["DEVICE_STATUS"].Equals("RUNNING"))
                                {
                                    bakingStartAt = "0:00";
                                    delay = "0";
                                    duration = "0";
                                    temp = "30";
                                    heater = "hotair";
                                }
                            }
                            else
                            {
                                is_valid_response = false;
                            }
                        }
                        else
                        {
                            is_valid_response = false;
                        }


                        if (is_valid_response)
                        {
                            action_desc = @"{
    ""delayed_baking"": """ + bakingStatus + @""",
    ""start_baking_at"": """ + bakingStartAt + @""",
    ""duration"": " + duration + @",
    ""delay"": " + delay + @",
    ""temperature"": " + temp + @",
    ""heater-system"": """ + heater + @"""
}";
                            return "OK";
                        }


                        action_desc = "error while preparing response";
                        return "Error";
                    }
                case AllowedActionType.BAKING:
                    {
                        if (OnRequestReceived == null)
                        {
                            return "Error: (Objects_Actions_GET:OnRequestReceived = NULL)";
                        }


                        HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { clp_params_request = true };

                        OnRequestReceived.Invoke(this, args);

                        
                        string duration = string.Empty, temp = string.Empty, heater = string.Empty;

                        bool is_valid_response = true;
                        if ((args != null) && (args.clp_params != null))
                        {
                            // set duration minutes parameter

                            if (args.clp_params.ContainsKey("SET_BAKE_TIME_MINUTES"))
                            {
                                duration = args.clp_params["SET_BAKE_TIME_MINUTES"];
                            }
                            else
                            {
                                is_valid_response = false;
                            }


                            // set temperature parameter

                            if (args.clp_params.ContainsKey("SET_OVEN_TEMPERATURE"))
                            {
                                temp = args.clp_params["SET_OVEN_TEMPERATURE"];
                            }
                            else
                            {
                                is_valid_response = false;
                            }


                            // set heater_system parameter

                            if (args.clp_params.ContainsKey("HEATER_SYSTEM_SUB"))
                            {
                                heater = args.clp_params["HEATER_SYSTEM_SUB"];
                            }
                            else
                            {
                                is_valid_response = false;
                            }
                        }
                        else
                        {
                            is_valid_response = false;
                        }


                        if (is_valid_response)
                        {
                            action_desc = @"{
    ""duration"": " + duration + @",
    ""temperature"": " + temp + @",
    ""heater_system"": """ + heater + @"""
}";

                            return "OK";
                        }


                        action_desc = "error while preparing response";
                        return "Error";
                    }

                default:
                    {
                        return base.Objects_Actions_GET(object_id, action_id, out action_desc);
                    }
            }
        }


        public override string Objects_Actions_POST(string object_id, string action_id, Dictionary<string, string> post_data)
        {
            is_error = false;

            switch (GetAllowedActionType(action_id))
            {
                case AllowedActionType.DELAYED_BAKING:
                    {
                        if (OnRequestReceived == null)
                        {
                            return "Error: (Objects_Actions_POST:OnRequestReceived = NULL)";
                        }


                        HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_DELAYED_BAKING };


                        args.clp_params = new Dictionary<string, string>();
                        foreach (var item in post_data)
                        {
                            if (!args.clp_params.ContainsKey(item.Key))
                            {
                                args.clp_params.Add(item.Key, item.Value);
                            }
                        }


                        OnRequestReceived.Invoke(this, args);


                        return "OK";
                    }

                case AllowedActionType.BAKING:
                    {
                        if (OnRequestReceived == null)
                        {
                            return "Error: (Objects_Actions_POST:OnRequestReceived = NULL)";
                        }


                        HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_BAKING };


                        args.clp_params = new Dictionary<string, string>();
                        foreach (var item in post_data)
                        {
                            if (!args.clp_params.ContainsKey(item.Key))
                            {
                                args.clp_params.Add(item.Key, item.Value);
                            }
                        }


                        OnRequestReceived.Invoke(this, args);


                        return "OK";
                    }

                case AllowedActionType.START:
                    {
                        if (OnRequestReceived == null)
                        {
                            return "Error: (Objects_Actions_POST:OnRequestReceived = NULL)";
                        }


                        HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_BAKING_START };


                        args.clp_params = new Dictionary<string, string>();
                        foreach (var item in post_data)
                        {
                            if (!args.clp_params.ContainsKey(item.Key))
                            {
                                args.clp_params.Add(item.Key, item.Value);
                            }
                        }


                        OnRequestReceived.Invoke(this, args);


                        return "OK";
                    }

                case AllowedActionType.STOP:
                    {
                        if (OnRequestReceived == null)
                        {
                            return "Error: (Objects_Actions_POST:OnRequestReceived = NULL)";
                        }


                        HTTPRequestEventArgs args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.OVEN_BAKING_STOP };


                        args.clp_params = new Dictionary<string, string>();
                        foreach (var item in post_data)
                        {
                            if (!args.clp_params.ContainsKey(item.Key))
                            {
                                args.clp_params.Add(item.Key, item.Value);
                            }
                        }


                        OnRequestReceived.Invoke(this, args);


                        return "OK";
                    }

                default:
                    {
                        return base.Objects_Actions_POST(object_id, action_id, post_data);
                    }
            }
        }
    }
}