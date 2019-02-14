using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VicinityWCF
{
    public partial class VicinityWCFService : IVicinityWCFService
    {
        #region GET method
        public Stream SM_Objects_Properties_GET(string object_id, string property_id)
        {
            ApplianceResponse app_response = ApplianceResponse.CreateInstance(object_id, OnRequestReceived);

            if (app_response != null)
            {
                if (app_response.IsValidProperty(property_id))
                {
                    switch (property_id.ToLower())
                    {
                        case "device_status":
                            {
                                string response = @"{
    ""device_status"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "light":
                            {
                                string response = @"{
    ""light"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "child_lock":
                            {
                                string response = @"{
    ""child_lock"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "door":
                            {
                                string response = @"{
    ""door"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "current_temperature":
                            {
                                string response = @"{
    ""current_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "current_meat_probe_temperature":
                            {
                                string response = @"{
    ""current_meat_probe_temperature"":  " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "heater_system":
                            {
                                string response = @"{
    ""heater_system"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "selected_heater_min_temperature":
                            {
                                string response = @"{
    ""selected_heater_min_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "selected_heater_max_temperature":
                            {
                                string response = @"{
    ""selected_heater_max_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "selected_heater_default_temperature":
                            {
                                string response = @"{
    ""selected_heater_default_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "selected_heater_meat_probe_allowed":
                            {
                                string response = @"{
    ""selected_heater_meat_probe_allowed"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "selected_heater_preheat_allowed":
                            {
                                string response = @"{
    ""selected_heater_preheat_allowed"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "set_meat_probe_temperature":
                            {
                                string response = @"{
    ""set_meat_probe_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "set_baking_temperature":
                            {
                                string response = @"{
    ""set_baking_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "set_baking_time":
                            {
                                string response = @"{
    ""set_baking_time"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "alarm_time":
                            {
                                string response = @"{
    ""alarm_time"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "bake_elapsed_time":
                            {
                                string response = @"{
    ""bake_elapsed_time"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "bake_remaining_time":
                            {
                                string response = @"{
    ""bake_remaining_time"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "baking_start_time_hour":
                            {
                                string response = @"{
    ""baking_start_time_hour"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "baking_start_time_minute":
                            {
                                string response = @"{
    ""baking_start_time_minute"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "refrigerator_light":
                            {
                                string response = @"{
    ""refrigerator_light"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "freezer_light":
                            {
                                string response = @"{
    ""freezer_light"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "refrigerator_door":
                            {
                                string response = @"{
    ""refrigerator_door"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "freezer_door":
                            {
                                string response = @"{
    ""freezer_door"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "refrigerator_temperature":
                            {
                                string response = @"{
    ""refrigerator_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "freezer_temperature":
                            {
                                string response = @"{
    ""freezer_temperature"": " + app_response.Objects_Properties_GET(object_id, property_id) + @"
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "fastfreeze":
                            {
                                string response = @"{
    ""fastfreeze"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                        case "supercool":
                            {
                                string response = @"{
    ""supercool"": """ + app_response.Objects_Properties_GET(object_id, property_id) + @"""
}";

                                return new MemoryStream(Encoding.UTF8.GetBytes(response));
                            }
                    }
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid pid: " + property_id);
                }
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid oid: " + object_id);
            }


            return null;
        }

        #endregion


        #region PUT method
        public Stream SM_Objects_Properties_PUT(string object_id, string property_id)
        {
            ApplianceResponse app_response = ApplianceResponse.CreateInstance(object_id, OnRequestReceived);

            if (app_response != null)
            {
                if (app_response.IsValidProperty(property_id))
                {
                    switch (property_id.ToLower())
                    {
                        case "light":
                            {
                                DC_Objects_Properties_PUT_Light put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_Light>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_Light)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.Light);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "child_lock":
                            {
                                DC_Objects_Properties_PUT_ChildLock put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_ChildLock>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_ChildLock)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.ChildLock);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "heater_system":
                            {
                                DC_Objects_Properties_PUT_HeaterSystem put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_HeaterSystem>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_HeaterSystem)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.HeaterSystem);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "set_meat_probe_temperature":
                            {
                                DC_Objects_Properties_PUT_SetMeatProbeTemp put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_SetMeatProbeTemp>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_SetMeatProbeTemp)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.MeatProbeTemp);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "set_baking_temperature":
                            {
                                DC_Objects_Properties_PUT_SetBakingTemp put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_SetBakingTemp>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_SetBakingTemp)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.BakingTemp);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "set_baking_time":
                            {
                                DC_Objects_Properties_PUT_SetBakingTime put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_SetBakingTime>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_SetBakingTime)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.BakingTime);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "alarm_time":
                            {
                                DC_Objects_Properties_PUT_AlarmTime put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_AlarmTime>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_AlarmTime)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.AlarmTime);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "baking_start_time_hour":
                            {
                                DC_Objects_Properties_PUT_BakingStartTimeHour put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_BakingStartTimeHour>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_BakingStartTimeHour)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.StartTimeHour);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "baking_start_time_minute":
                            {
                                DC_Objects_Properties_PUT_BakingStartTimeMinute put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_BakingStartTimeMinute>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_BakingStartTimeMinute)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.StartTimeMinute);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "refrigerator_temperature":
                            {
                                DC_Objects_Properties_PUT_RefrigeratorTemp put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_RefrigeratorTemp>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_RefrigeratorTemp)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.RefrigeratorTemp);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "freezer_temperature":
                            {
                                DC_Objects_Properties_PUT_FreezerTemp put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_FreezerTemp>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_FreezerTemp)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.FreezerTemp);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "fastfreeze":
                            {
                                DC_Objects_Properties_PUT_Fastfreeze put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_Fastfreeze>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_Fastfreeze)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.Fastfreeze);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                        case "supercool":
                            {
                                DC_Objects_Properties_PUT_Supercool put_data = null;

                                try
                                {
                                    put_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_Properties_PUT_Supercool>(new DataContractJsonSerializer(typeof(DC_Objects_Properties_PUT_Supercool)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (put_data != null)
                                {
                                    app_response.Objects_Properties_PUT(object_id, property_id, put_data.Supercool);

                                    string response = @"{
    ""result"": ""true""
}";

                                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                                }
                                else
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Error while serializing JSON message!");
                                }
                            }
                            break;
                    }
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid pid: " + property_id);
                }
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid oid: " + object_id);
            }


            return null;

        }

        #endregion
    }
}