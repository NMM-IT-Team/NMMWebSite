using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace NMMEvents.BusinessObjects
{

    public class EventImage
    {
        public string ImageUrl { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EventInfo
    {
        #region Properties

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IsCommercial")]
        public string IsCommercial { get; set; }

        [JsonProperty("Cost")]
        public decimal Cost { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Event_Date")]
        public string EventDate { get; set; }

        [JsonProperty("Venu_Name")]
        public string VenuName { get; set; }

        [JsonProperty("RootFolder")]
        public string RootFolder { get; set; }

        [JsonProperty("EventImages")]
        public List<string> EventImages { get; set; }

        public List<EventImage> EventInfoImages { get; set; }

        #endregion

        public EventInfo()
        {

        }

    }

}

