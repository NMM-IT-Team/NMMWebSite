using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NMMEvents.BusinessObjects
{
    public class EventInfo : BaseBusinessObject
    {
        #region Properties

        private string _eventDescription;
        public string EventDescription
        {
            get { return _eventDescription; }
            set
            {
                if (_eventDescription != value)
                {
                    _eventDescription = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _eventName;
        public string EventName
        {
            get { return _eventName; }
            set
            {
                if (_eventName != value)
                {
                    _eventName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _eventDateTime;
        public DateTime EventDateTime
        {
            get { return _eventDateTime; }
            set
            {
                if (_eventDateTime != value)
                {
                    _eventDateTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        public EventInfo()
        {

        }

        public static ObservableCollection<EventInfo> GetEventInfoTempList()
        {
            ObservableCollection<EventInfo> info = new ObservableCollection<EventInfo>();

            EventInfo item1 = new EventInfo();
            item1.EventDateTime = DateTime.Now;
            item1.EventName = "Event 1";
            item1.EventDescription = "event description";

            EventInfo item2 = new EventInfo();
            item2.EventDateTime = DateTime.Now;
            item2.EventName = "Event 2";
            item2.EventDescription = "event description";

            EventInfo item3 = new EventInfo();
            item3.EventDateTime = DateTime.Now;
            item3.EventName = "Event 3";
            item3.EventDescription = "event description";

            EventInfo item4 = new EventInfo();
            item4.EventDateTime = DateTime.Now;
            item4.EventName = "Event 4";
            item4.EventDescription = "event description";

            EventInfo item5 = new EventInfo();
            item5.EventDateTime = DateTime.Now;
            item5.EventName = "Event 4";
            item5.EventDescription = "event description";


            info.Add(item1);
            info.Add(item2);
            info.Add(item3);
            info.Add(item4);
            info.Add(item5);


            return info;
        }
    }

}

