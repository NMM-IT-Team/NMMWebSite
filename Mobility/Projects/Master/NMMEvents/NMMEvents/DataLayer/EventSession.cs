using System;
using NMMEvents.BusinessObjects;
using System.Collections.Generic;
namespace NMMEvents.DataLayer
{
    public class EventSession : BaseSession
    {
        public EventSession()
        {

        }

        public List<EventInfo> FetchEvents()
        {
            var uri = new Uri(string.Format("http://192.168.0.12:8888/mylearningapp/public/index.php/api/events", string.Empty));
            var eventData = GetData<EventInfo>(uri);
            if (eventData != null && eventData.Count > 0)
            {
                return eventData;
            }
            return null;
        }
    }
}
