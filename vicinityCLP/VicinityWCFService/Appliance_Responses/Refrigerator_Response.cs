using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class Refrigerator_Response : ApplianceResponse
    {
        private enum AllowedPropertyType
        {
            DEVICE_STATUS,
            REFRIGERATOR_LIGHT,
            FREEZER_LIGHT,
            REFRIGERATOR_DOOR,
            FREEZER_DOOR,
            REFRIGERATOR_TEMPERATURE,
            FREEZER_TEMPERATURE,
            FASTFREEZE,
            SUPERCOOL,
            CHILD_LOCK,
            invalid_property
        }

        private enum AllowedActionType { invalid_action }


        public Refrigerator_Response()
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


                // if defined name does not match with the one, obtained from the refrigerator

                switch (GetAllowedPropertyType(property_id))
                {
                    case AllowedPropertyType.REFRIGERATOR_LIGHT:
                        {
                            if (args.clp_params.ContainsKey("LIGHT_STATUS_REFRIGERATOR"))
                            {
                                return args.clp_params["LIGHT_STATUS_REFRIGERATOR"];
                            }
                        }
                        break;

                    case AllowedPropertyType.FREEZER_LIGHT:
                        {
                            if (args.clp_params.ContainsKey("LIGHT_STATUS_FREEZER"))
                            {
                                return args.clp_params["LIGHT_STATUS_FREEZER"];
                            }
                        }
                        break;

                    case AllowedPropertyType.REFRIGERATOR_DOOR:
                        {
                            if (args.clp_params.ContainsKey("REFRIGERATOR_DOOR_STATUS"))
                            {
                                return args.clp_params["REFRIGERATOR_DOOR_STATUS"];
                            }
                        }
                        break;

                    case AllowedPropertyType.FREEZER_DOOR:
                        {
                            if (args.clp_params.ContainsKey("FREEZER_DOOR_STATUS"))
                            {
                                return args.clp_params["FREEZER_DOOR_STATUS"];
                            }
                        }
                        break;

                    case AllowedPropertyType.REFRIGERATOR_TEMPERATURE:
                        {
                            if (args.clp_params.ContainsKey("SET_REFRIGERATOR_TEMPERATURE"))
                            {
                                return args.clp_params["SET_REFRIGERATOR_TEMPERATURE"];
                            }
                        }
                        break;

                    case AllowedPropertyType.FREEZER_TEMPERATURE:
                        {
                            if (args.clp_params.ContainsKey("SET_FREEZER_TEMPERATURE"))
                            {
                                return args.clp_params["SET_FREEZER_TEMPERATURE"];
                            }
                        }
                        break;

                    case AllowedPropertyType.FASTFREEZE:
                        {
                            if (args.clp_params.ContainsKey("FASTFREEZE_FUNCTION"))
                            {
                                return args.clp_params["FASTFREEZE_FUNCTION"];
                            }
                        }
                        break;

                    case AllowedPropertyType.SUPERCOOL:
                        {
                            if (args.clp_params.ContainsKey("SUPERCOOL_FUNCTION"))
                            {
                                return args.clp_params["SUPERCOOL_FUNCTION"];
                            }
                        }
                        break;
                        
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
                case AllowedPropertyType.CHILD_LOCK:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.REFRIGERATOR_CHILD_LOCK };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("child_lock"))
                        {
                            String childLock = "";
                            if (put_data.Length == 1)
                            {
                                childLock = put_data[0];
                            }

                            args.clp_params.Add("child_lock", childLock);
                        }
                    }
                    break;
                case AllowedPropertyType.REFRIGERATOR_TEMPERATURE:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.REFRIGERATOR_TEMPERATURE };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("refrigerator_temperature"))
                        {
                            String refrigeratorTemp = "";
                            if (put_data.Length == 1)
                            {
                                refrigeratorTemp = put_data[0];
                            }

                            args.clp_params.Add("refrigerator_temperature", refrigeratorTemp);
                        }
                    }
                    break;
                case AllowedPropertyType.FREEZER_TEMPERATURE:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.REFRIGERATOR_FREEZER_TEMPERATURE };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("freezer_temperature"))
                        {
                            String freezerTemp = "";
                            if (put_data.Length == 1)
                            {
                                freezerTemp = put_data[0];
                            }

                            args.clp_params.Add("freezer_temperature", freezerTemp);
                        }
                    }
                    break;
                case AllowedPropertyType.FASTFREEZE:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.REFRIGERATOR_FASTFREEZE };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("fastfreeze"))
                        {
                            String fastfreeze = "";
                            if (put_data.Length == 1)
                            {
                                fastfreeze = put_data[0];
                            }

                            args.clp_params.Add("fastfreeze", fastfreeze);
                        }
                    }
                    break;
                case AllowedPropertyType.SUPERCOOL:
                    {
                        args = new HTTPRequestEventArgs(AUID) { action_type = RequestActionType.REFRIGERATOR_SUPERCOOL };


                        args.clp_params = new Dictionary<string, string>();
                        if (!args.clp_params.ContainsKey("supercool"))
                        {
                            String supercool = "";
                            if (put_data.Length == 1)
                            {
                                supercool = put_data[0];
                            }

                            args.clp_params.Add("supercool", supercool);
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
    }
}