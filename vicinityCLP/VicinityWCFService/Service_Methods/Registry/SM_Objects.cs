using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace VicinityWCF
{
    public partial class VicinityWCFService : IVicinityWCFService
    {
        public Stream SM_Objects_GET()
        {
            #region Comment
            //            string response = @"[
            //  {
            //    ""type"": ""SmartOven"",
            //    ""oid"": ""smart_oven_cerknica_0"",
            //    ""properties"": [
            //      {
            //        ""pid"": ""device_status"",
            //        ""monitors"": ""device_status"",
            //        ""output"": {
            //          ""units"": ""Adimensional"",
            //          ""datatype"": ""string""
            //        },
            //        ""writable"": false,
            //        ""read_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""write_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ]
            //      },
            //      {
            //        ""pid"": ""light"",
            //        ""monitors"": ""light"",
            //        ""output"": {
            //          ""units"": ""Adimensional"",
            //          ""datatype"": ""string""
            //        },
            //        ""writable"": false,
            //        ""read_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""write_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ]
            //      }
            //    ],
            //    ""actions"": [      
            //      {
            //        ""aid"": ""delayed_baking"",
            //        ""affects"": ""delayed_baking_status"",
            //        ""read_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/actions/{aid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""write_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/actions/{aid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""input"": {
            //          ""units"": ""Adimensional"",
            //          ""datatype"": ""string""
            //        }
            //      }
            //    ]
            //  },
            //  {
            //    ""type"": ""SmartOven"",
            //    ""oid"": ""smart_oven_cerknica_1"",
            //    ""properties"": [
            //      {
            //        ""pid"": ""device_status"",
            //        ""monitors"": ""device_status"",
            //        ""output"": {
            //          ""units"": ""Adimensional"",
            //          ""datatype"": ""string""
            //        },
            //        ""writable"": false,
            //        ""read_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""write_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ]
            //      },
            //      {
            //        ""pid"": ""light"",
            //        ""monitors"": ""light"",
            //        ""output"": {
            //          ""units"": ""Adimensional"",
            //          ""datatype"": ""string""
            //        },
            //        ""writable"": false,
            //        ""read_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""write_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/properties/{pid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ]
            //      }
            //    ],
            //    ""actions"": [      
            //      {
            //        ""aid"": ""delayed_baking"",
            //        ""affects"": ""delayed_baking_status"",
            //        ""read_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/actions/{aid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""write_links"": [
            //          {
            //            ""href"": ""/objects/{oid}/actions/{aid}"",
            //            ""mediaType"": ""application/json""
            //          }
            //        ],
            //        ""input"": {
            //          ""units"": ""Adimensional"",
            //          ""datatype"": ""string""
            //        }
            //      }
            //    ]
            //  }
            //]";
            #endregion


            List<Appliance> appliances = new List<Appliance>();
            List<Property> ovenProperties = new List<Property>();
            List<Event> ovenEvents = new List<Event>();
            List<Action> ovenActions = new List<Action>();
            List<Property> refrigeratorProperties = new List<Property>();
            List<Action> refrigeratorActions = new List<Action>();
            List<Event> refrigeratorEvents = new List<Event>();
                        
            XmlDocument xmldoc2 = new XmlDocument();
            try
            {
                xmldoc2.Load(@"C:\VICINITY\Files\ObjectsStructure.xml");
                XmlNodeList xmlOvenProperties = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property");
                XmlNodeList xmlOvenActions = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action");
                XmlNodeList xmlOvenEvents = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Events/Event");
                XmlNodeList xmlRefrigeratorProperties = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property");
                XmlNodeList xmlRefrigeratorActions = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action");
                XmlNodeList xmlRefrigeratorEvents = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Events/Event");
                foreach (XmlNode node in xmlOvenProperties)
                {
                    string pid = node.Attributes["pid"].Value;
                    XmlNodeList xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property[@pid='" + pid + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach(XmlNode field in xmlOvenPropertiesFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value), field.Attributes["predicate"].Value));
                    }
                    InOutput readOutput = new InOutput
                    {
                        Type = "object",
                        Field = readOutputFields
                    };
                    xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property[@pid='" + pid + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenPropertiesFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput
                    {
                        Type = "object",
                        Field = writeInputFields
                    };
                    xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property[@pid='" + pid + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenPropertiesFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput
                    {
                        Type = "object",
                        Field = writeOutputFields
                    };
                    ovenProperties.Add(new Property
                    {
                        Pid = pid,
                        Monitors = node.Attributes["monitors"].Value,
                        ReadLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/properties/{pid}",
                            Output = readOutput
                        },
                        WriteLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/properties/{pid}",
                            Input = writeInput,
                            Output = writeOutput
                        }
                    });
                }
                foreach (XmlNode node in xmlOvenActions)
                {
                    string aid = node.Attributes["aid"].Value;
                    XmlNodeList xmlOvenActionssFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action[@aid='" + aid + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenActionssFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput readOutput = new InOutput
                    {
                        Type = "object",
                        Field = readOutputFields
                    };
                    xmlOvenActionssFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action[@aid='" + aid + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenActionssFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput
                    {
                        Type = "object",
                        Field = writeInputFields
                    };
                    xmlOvenActionssFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action[@aid='" + aid + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenActionssFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput
                    {
                        Type = "object",
                        Field = writeOutputFields
                    };
                    ovenActions.Add(new Action
                    {
                        Aid = aid,
                        Affects = node.Attributes["affects"].Value,
                        ReadLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/actions/{pid}",
                            Output = readOutput
                        },
                        WriteLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/actions/{pid}",
                            Input = writeInput,
                            Output = writeOutput
                        }
                    });
                }
                foreach (XmlNode node in xmlOvenEvents)
                {
                    string eid = node.Attributes["eid"].Value;
                    XmlNodeList xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Events/Event[@eid='" + eid + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenPropertiesFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    ovenEvents.Add(new Event
                    {
                        Eid = eid,
                        Monitors = node.Attributes["monitors"].Value,
                        Output = new InOutput
                        {
                            Type = "object",
                            Field = readOutputFields
                        }
                    });
                }
                foreach (XmlNode node in xmlRefrigeratorProperties)
                {
                    string pid = node.Attributes["pid"].Value;
                    XmlNodeList xmlRefrigeratorPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property[@pid='" + pid + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorPropertiesFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value), field.Attributes["predicate"].Value));
                    }
                    InOutput readOutput = new InOutput
                    {
                        Type = "object",
                        Field = readOutputFields
                    };
                    xmlRefrigeratorPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property[@pid='" + pid + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorPropertiesFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput
                    {
                        Type = "object",
                        Field = writeInputFields
                    };
                    xmlRefrigeratorPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property[@pid='" + pid + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorPropertiesFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput
                    {
                        Type = "object",
                        Field = writeOutputFields
                    };
                    refrigeratorProperties.Add(new Property
                    {
                        Pid = pid,
                        Monitors = node.Attributes["monitors"].Value,
                        ReadLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/properties/{pid}",
                            Output = readOutput
                        },
                        WriteLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/properties/{pid}",
                            Input = writeInput,
                            Output = writeOutput
                        }
                    });
                }
                foreach (XmlNode node in xmlRefrigeratorActions)
                {
                    string aid = node.Attributes["aid"].Value;
                    XmlNodeList xmlRefrigeratorActionsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action[@aid='" + aid + "']/Fields[@type='readOutput']//Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorActionsFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput readOutput = new InOutput
                    {
                        Type = "object",
                        Field = readOutputFields
                    };
                    xmlRefrigeratorActionsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action[@aid='" + aid + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorActionsFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput
                    {
                        Type = "object",
                        Field = writeInputFields
                    };
                    xmlRefrigeratorActionsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action[@aid='" + aid + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorActionsFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput
                    {
                        Type = "object",
                        Field = writeOutputFields
                    };
                    refrigeratorActions.Add(new Action
                    {
                        Aid = aid,
                        Affects = node.Attributes["affects"].Value,
                        ReadLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/actions/{pid}",
                            Output = readOutput
                        },
                        WriteLink = new ReadWriteLink
                        {
                            Href = "/objects/{oid}/actions/{pid}",
                            Input = writeInput,
                            Output = writeOutput
                        }
                    });
                }
                foreach (XmlNode node in xmlRefrigeratorEvents)
                {
                    string eid = node.Attributes["eid"].Value;
                    XmlNodeList xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Events/Event[@eid='" + eid + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenPropertiesFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    refrigeratorEvents?.Add(new Event
                    {
                        Eid = eid,
                        Monitors = node.Attributes["monitors"].Value,
                        Output = new InOutput
                        {
                            Type = "object",
                            Field = readOutputFields
                        }
                    });
                }
            }
            catch
            { }

            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(@"C:\VICINITY\Files\Appliances.xml");
                XmlNodeList xmlAppliances = xmldoc.SelectNodes("/items/item");
                foreach (XmlNode node in xmlAppliances)
                {
                    string type = node["type"].InnerText;
                    if (type.Equals("oven"))
                    {
                        appliances.Add(new Appliance
                        {
                            Type = "adapters:SmartOven",
                            Oid = node.Attributes["oid"].Value,
                            Name = node.Attributes["name"].Value,
                            Properties = ovenProperties,
                            Actions = ovenActions,
                            Events = ovenEvents
                        });
                    }
                    else if (type.Equals("refrigerator"))
                    {
                        appliances.Add(new Appliance
                        {
                            Type = "adapters:SmartRefrigerator",
                            Oid = node.Attributes["oid"].Value,
                            Name = node.Attributes["name"].Value,
                            Properties = refrigeratorProperties,
                            Actions = refrigeratorActions,
                            Events = refrigeratorEvents
                        });
                    }
                }
            }
            catch
            { }

            Objects objects = new Objects
            {
                AdapterID = "adapter-gorenje",
                //AdapterID = "dev-adapter-gorenje",
                Appliances = appliances
            };

            string response = JsonConvert.SerializeObject(objects, Newtonsoft.Json.Formatting.Indented);

            #region oldResponse
            //response = @"{
            //             ""adapter-id"": ""adapter-gorenje"",
            //""thing-descriptions"":
            //[
            //           {
            //             ""type"": ""core:Device"",
            //             ""oid"": ""smart_oven_cerknica_0"",
            //             ""name"": ""Smart Oven Cerknica 0"",
            //             ""properties"": [
            //               {
            //                 ""pid"": ""device_status"",
            //                 ""monitors"": ""adapters:Motion"",                    
            //                 ""read_link"": {
            //                     ""href"": ""/objects/{oid}/properties/{pid}"",
            //                     ""output"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     }
            //                 },
            //                 ""write_link"":  {
            //                     ""href"": ""/objects/{oid}/properties/{pid}"",
            //                     ""input"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     },
            //                     ""output"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     }
            //                 }
            //               },
            //               {
            //                 ""pid"": ""light"",
            //                 ""monitors"": ""adapters:Motion"",
            //                 ""read_link"": {
            //                     ""href"": ""/objects/{oid}/properties/{pid}"",
            //                     ""output"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     }
            //                   },
            //                 ""write_link"": {
            //                     ""href"": ""/objects/{oid}/properties/{pid}"",
            //                     ""input"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     },
            //                     ""output"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     }
            //                   }
            //               }
            //             ],
            //             ""actions"": [      
            //               {
            //                 ""aid"": ""delayed_baking"",
            //                 ""affects"": ""adapters:Motion"",
            //                 ""read_link"": {
            //                     ""href"": ""/objects/{oid}/actions/{aid}"",
            //                     ""output"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     }
            //                   },
            //                 ""write_link"": {
            //                     ""href"": ""/objects/{oid}/actions/{aid}"",
            //                     ""input"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     },
            //                     ""output"": {
            //                         ""type"": ""object"",
            //                         ""field"": [
            //                             {
            //                                 ""name"": ""status"",
            //                                 ""schema"": {
            //                                     ""type"": ""string""
            //                                 }
            //                             }                   
            //                         ]
            //                     }
            //                   }
            //               }
            //             ],
            //             ""events"": []
            //           }
            //         ]
            // }";
            #endregion

            return new MemoryStream(Encoding.UTF8.GetBytes(response));
        }

    }
}