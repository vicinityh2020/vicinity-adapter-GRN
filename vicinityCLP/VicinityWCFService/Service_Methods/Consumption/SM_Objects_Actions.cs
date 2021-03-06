/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System;
using System.Collections.Generic;
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
        public Stream SM_Objects_Actions_GET(string object_id, string action_id)
        {
            ApplianceResponse app_response = ApplianceResponse.CreateInstance(object_id, OnRequestReceived);

            if (app_response != null)
            {
                if (app_response.IsValidAction(action_id))
                {
                    string action_desc = "";
                    string action_response = app_response.Objects_Actions_GET(object_id, action_id, out action_desc);

                    string response = action_desc;

                    return new MemoryStream(Encoding.UTF8.GetBytes(response));
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid aid: " + action_id);
                }
            }
            else
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid oid: " + object_id);
            }


            return null;
        }
        #endregion


        #region POST method    
        public Stream SM_Objects_Actions_POST(string object_id, string action_id)
        {
            ApplianceResponse app_response = ApplianceResponse.CreateInstance(object_id, OnRequestReceived);

            if (app_response != null)
            {
                if (app_response.IsValidAction(action_id))
                {
                    switch (action_id.ToLower())
                    {
                        case "delayed_baking":
                            {
                                DC_Objects_ActionsDelayedBaking post_data = null;

                                try
                                {
                                    post_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_ActionsDelayedBaking>(new DataContractJsonSerializer(typeof(DC_Objects_ActionsDelayedBaking)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (post_data != null)
                                {
                                    Dictionary<string, string> data = new Dictionary<string, string>();
                                    data.Add("duration", post_data.Duration);
                                    data.Add("delay", post_data.Delay);
                                    data.Add("temperature", post_data.Temperature);
                                    data.Add("heater_system", post_data.HeaterSystem);

                                    app_response.Objects_Actions_POST(object_id, action_id, data);

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
                        case "baking":
                            {
                                DC_Objects_ActionsBaking post_data = null;

                                try
                                {
                                    post_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_ActionsBaking>(new DataContractJsonSerializer(typeof(DC_Objects_ActionsBaking)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (post_data != null)
                                {
                                    Dictionary<string, string> data = new Dictionary<string, string>();
                                    data.Add("duration", post_data.Duration);
                                    data.Add("temperature", post_data.Temperature);
                                    data.Add("heater_system", post_data.HeaterSystem);

                                    app_response.Objects_Actions_POST(object_id, action_id, data);

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
                        case "start":
                        case "stop":
                            {
                                DC_Objects_ActionsStartStop post_data = null;

                                try
                                {
                                    post_data = OperationContext.Current.RequestContext.RequestMessage.GetBody<DC_Objects_ActionsStartStop>(new DataContractJsonSerializer(typeof(DC_Objects_ActionsStartStop)));
                                }
                                catch (Exception ex)
                                {
                                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Exception: " + ex.Message);
                                }

                                if (post_data != null)
                                {
                                    Dictionary<string, string> data = new Dictionary<string, string>();

                                    app_response.Objects_Actions_POST(object_id, action_id, data);

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
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound("Invalid aid: " + action_id);
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
