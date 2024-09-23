using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WSCADTask.Classes
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("shapesList")]
    public class GraphicsList
    {
        [XmlArray("shapes")]
        [XmlArrayItem("shape")]
        [JsonProperty("shapes")]
        public List<Graphics> graphics { get; set; }
    }

    [Serializable()]
    public class Graphics
    {
        [System.Xml.Serialization.XmlElement("type")]
        [JsonProperty("type")]
        public string type { get; set; }

        [System.Xml.Serialization.XmlElement("a")]
        [JsonProperty("a", NullValueHandling = NullValueHandling.Ignore)]
        public string? a { get; set; }

        [System.Xml.Serialization.XmlElement("b")]
        [JsonProperty("b", NullValueHandling = NullValueHandling.Ignore)]
        public string? b { get; set; }

        [System.Xml.Serialization.XmlElement("c")]
        [JsonProperty("c", NullValueHandling = NullValueHandling.Ignore)]
        public string? c { get; set; }

        [System.Xml.Serialization.XmlElement("filled")]
        [JsonProperty("filled")]
        public bool filled { get; set; }

        [System.Xml.Serialization.XmlElement("color")]
        [JsonProperty("color")]
        public string color { get; set; }

        [System.Xml.Serialization.XmlElement("center")]
        [JsonProperty("center", NullValueHandling = NullValueHandling.Ignore)]
        public string? center { get; set; }

        [System.Xml.Serialization.XmlElement("radius")]
        [JsonProperty("radius", NullValueHandling = NullValueHandling.Ignore)]
        public string? radius { get; set; }
    }


}
