using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace NMMEvents.BusinessObjects
{
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

        [JsonProperty("PhotoId")]
        public int PhotoId { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonProperty("ModifiedOn")]
        public string ModifiedOn { get; set; }

        #endregion

        public EventInfo()
        {

        }

    }

}

