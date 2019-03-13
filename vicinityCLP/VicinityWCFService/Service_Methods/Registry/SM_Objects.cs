using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace VicinityWCF
{
    public partial class VicinityWCFService : IVicinityWCFService
    {
        #region Methods

        #region Public

        #region SM_Objects_GET
        public Stream SM_Objects_GET()
        {
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
                    string pID = node.Attributes["pid"].Value;
                    XmlNodeList xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property[@pid='" + pID + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach(XmlNode field in xmlOvenPropertiesFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value), field.Attributes["predicate"].Value));
                    }
                    InOutput readOutput = new InOutput("object", readOutputFields);
                    xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property[@pid='" + pID + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenPropertiesFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput("object", writeInputFields);
                    xmlOvenPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Properties/Property[@pid='" + pID + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenPropertiesFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput("object", writeOutputFields);
                    ovenProperties.Add(new Property
                    (
                        pID,
                        node.Attributes["monitors"].Value,
                        new ReadWriteLink("/objects/{oid}/properties/{pid}", readOutput),
                        new ReadWriteLink("/objects/{oid}/properties/{pid}", writeOutput, writeInput)
                    ));
                }
                foreach (XmlNode node in xmlOvenActions)
                {
                    string aID = node.Attributes["aid"].Value;
                    XmlNodeList xmlOvenActionssFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action[@aid='" + aID + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenActionssFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput readOutput = new InOutput("object", readOutputFields);
                    xmlOvenActionssFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action[@aid='" + aID + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenActionssFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput("object", writeInputFields);
                    xmlOvenActionssFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Actions/Action[@aid='" + aID + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenActionssFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput("object", writeOutputFields);
                    ovenActions.Add(new Action
                    (
                        aID,
                        node.Attributes["affects"].Value,
                        new ReadWriteLink("/objects/{oid}/actions/{pid}", writeOutput, writeInput),
                        new ReadWriteLink("/objects/{oid}/actions/{pid}", readOutput)
                    ));
                }
                foreach (XmlNode node in xmlOvenEvents)
                {
                    string eID = node.Attributes["eid"].Value;
                    XmlNodeList xmlOvenEventsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='oven']/Events/Event[@eid='" + eID + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlOvenEventsFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    ovenEvents.Add(new Event(eID, node.Attributes["monitors"].Value, new InOutput("object", readOutputFields)));
                }
                foreach (XmlNode node in xmlRefrigeratorProperties)
                {
                    string pID = node.Attributes["pid"].Value;
                    XmlNodeList xmlRefrigeratorPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property[@pid='" + pID + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorPropertiesFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value), field.Attributes["predicate"].Value));
                    }
                    InOutput readOutput = new InOutput("object", readOutputFields);
                    xmlRefrigeratorPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property[@pid='" + pID + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorPropertiesFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput("object", writeInputFields);
                    xmlRefrigeratorPropertiesFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Properties/Property[@pid='" + pID + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorPropertiesFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput("object", writeOutputFields);
                    refrigeratorProperties.Add(new Property
                    (
                        pID,
                        node.Attributes["monitors"].Value,
                        new ReadWriteLink("/objects/{oid}/properties/{pid}", readOutput),
                        new ReadWriteLink("/objects/{oid}/properties/{pid}", writeOutput, writeInput)
                    ));
                }
                foreach (XmlNode node in xmlRefrigeratorActions)
                {
                    string aID = node.Attributes["aid"].Value;
                    XmlNodeList xmlRefrigeratorActionsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action[@aid='" + aID + "']/Fields[@type='readOutput']//Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorActionsFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput readOutput = new InOutput("object", readOutputFields);
                    xmlRefrigeratorActionsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action[@aid='" + aID + "']/Fields[@type='writeInput']/Field");
                    List<Field> writeInputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorActionsFields)
                    {
                        writeInputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeInput = new InOutput("object", writeInputFields);
                    xmlRefrigeratorActionsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Actions/Action[@aid='" + aID + "']/Fields[@type='writeOutput']/Field");
                    List<Field> writeOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorActionsFields)
                    {
                        writeOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    InOutput writeOutput = new InOutput("object", writeOutputFields);
                    refrigeratorActions.Add(new Action
                    (
                        aID,
                        node.Attributes["affects"].Value,
                        new ReadWriteLink("/objects/{oid}/actions/{pid}", writeOutput, writeInput),
                        new ReadWriteLink("/objects/{oid}/actions/{pid}", readOutput)
                    ));
                }
                foreach (XmlNode node in xmlRefrigeratorEvents)
                {
                    string eID = node.Attributes["eid"].Value;
                    XmlNodeList xmlRefrigeratorEventsFields = xmldoc2.SelectNodes("/Appliances/Appliance[@type='refrigerator']/Events/Event[@eid='" + eID + "']/Fields[@type='readOutput']/Field");
                    List<Field> readOutputFields = new List<Field>();
                    foreach (XmlNode field in xmlRefrigeratorEventsFields)
                    {
                        readOutputFields.Add(new Field(field.Attributes["name"].Value, field.Attributes["description"].Value, new Schema(field.Attributes["schemaType"].Value)));
                    }
                    refrigeratorEvents?.Add(new Event(eID, node.Attributes["monitors"].Value, new InOutput("object", readOutputFields)));
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
                    string oid = node.Attributes["oid"].Value;

                    XmlNodeList xmlAppliancesLocatedIn = xmldoc.SelectNodes("/items/item[@oid='" + oid + "']/Locations/Location");
                    List<LocatedIn> locatedIn = new List<LocatedIn>();
                    foreach (XmlNode location in xmlAppliancesLocatedIn)
                    {
                        locatedIn?.Add(new LocatedIn(location.Attributes["location_type"].Value, location.Attributes["label"].Value, location.Attributes["location_id"]?.Value));
                    }

                    XmlNodeList xmlAppliancesStaticValues = xmldoc.SelectNodes("/items/item[@oid='" + oid + "']/StaticValues/StaticValue");
                    List<StaticValue> staticValues = new List<StaticValue>();
                    foreach (XmlNode staticValue in xmlAppliancesStaticValues)
                    {
                        staticValues?.Add(new StaticValue(staticValue.Attributes["pid"]?.Value, staticValue.Attributes["type"]?.Value, staticValue.Attributes["value"]?.Value));
                    }

                    string type = node["type"].InnerText;
                    if (type.CompareTo("oven") == 0)
                    {
                        List<Property> newOvenProperties = AddStaticValuesToProperties(ovenProperties, staticValues);

                        appliances?.Add(new Appliance
                        (
                            "adapters:SmartOven",
                            oid,
                            node.Attributes["name"].Value,
                            newOvenProperties,
                            ovenActions,
                            ovenEvents,
                            locatedIn
                        ));
                    }
                    else if (type.CompareTo("refrigerator") == 0)
                    {
                        List<Property> newRefrigeratorProperties = AddStaticValuesToProperties(refrigeratorProperties, staticValues);

                        appliances?.Add(new Appliance
                        (
                            "adapters:SmartRefrigerator",
                            oid,
                            node.Attributes["name"].Value,
                            newRefrigeratorProperties,
                            refrigeratorActions,
                            refrigeratorEvents,
                            locatedIn
                        ));
                    }
                }
            }
            catch
            { }

            //Objects objects = new Objects("dev-adapter-gorenje", appliances);
            Objects objects = new Objects("adapter-gorenje", appliances);

            string response = JsonConvert.SerializeObject(objects, Newtonsoft.Json.Formatting.Indented);

            return new MemoryStream(Encoding.UTF8.GetBytes(response));
        }
        #endregion

        #endregion

        #region Private

        #region AddStaticValuesToProperties
        private List<Property> AddStaticValuesToProperties(List<Property> currentProperties, List<StaticValue> staticValues)
        {
            List<Property> newProperties = new List<Property>();
            if (currentProperties != null && staticValues != null)
            {
                foreach (var property in currentProperties)
                {
                    if (property.ReadLink != null)
                    {
                        Property item = new Property(property.PID, property.Monitors, new ReadWriteLink(property.ReadLink.Href, property.ReadLink.Output, property.ReadLink.Input), property.WriteLink);
                        foreach (var staticValue in staticValues)
                        {
                            if (!string.IsNullOrEmpty(staticValue.PID) && item.PID.CompareTo(staticValue.PID) == 0)
                            {
                                item.ReadLink.StaticValue = staticValue;
                                break;
                            }
                        }
                        newProperties.Add(item);
                    }
                }
            }
            return newProperties;
        }
        #endregion

        #endregion

        #endregion
    }
}