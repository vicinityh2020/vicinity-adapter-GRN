/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System;
using System.Collections.Generic;
using System.Xml;

namespace VicinityWCF
{
    public class ApplianceResponse
    {
        public EventHandler<HTTPRequestEventArgs> OnRequestReceived;

        public bool is_error { get; protected set; }
        public string AUID { set; get; }

        public ApplianceResponse()
        {
            OnRequestReceived = null;

            is_error = false;
        }

        public virtual bool IsValidProperty(string property_id)
        {
            return false;
        }

        public virtual bool IsValidAction(string action_id)
        {
            return false;
        }

        public virtual string Objects_Properties_GET(string object_id, string property_id)
        {
            return "";
        }

        public virtual string Objects_Properties_PUT(string object_id, string property_id, params string[] value)
        {
            return "";
        }


        public virtual string Objects_Actions_GET(string object_id, string action_id, out string action_desc)
        {
            action_desc = "";

            return "invalid action id";
        }

        public virtual string Objects_Actions_POST(string object_id, string action_id, Dictionary<string, string> post_data)
        {
            return "invalid action id";
        }


        public static ApplianceResponse CreateInstance(string object_id, EventHandler<HTTPRequestEventArgs> _on_request_received_handler)
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(@"C:\VICINITY\Files\Appliances.xml");
            }
            catch
            {
                return null;
            }

            XmlNode node = xmldoc.SelectSingleNode("/items/item[@oid='" + object_id + "']");

            if (node != null)
            {
                string type = "", _AUID = "";
                try
                {
                    type = node["type"].InnerText;
                    _AUID = node["clp"].InnerText;
                }
                catch
                {
                    return null;
                }
                
                if (type.Equals("oven"))
                {
                    return new Oven_Response() { OnRequestReceived = _on_request_received_handler, AUID = _AUID };
                }else if (type.Equals("refrigerator"))
                {
                    return new Refrigerator_Response() { OnRequestReceived = _on_request_received_handler, AUID = _AUID };
                }
            }
            return null;
        }
    }
}
