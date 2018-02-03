using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NMMEvents.BusinessObjects
{
    public class EventImages
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }


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

        private List<EventImages> _eventInfoImages;
        public List<EventImages> EventInfoImages
        {
            get { return _eventInfoImages; }
            set
            {
                if (_eventInfoImages != value)
                {
                    _eventInfoImages = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _eventAddress;
        public string EventAddress
        {
            get { return _eventAddress; }
            set
            {
                if (_eventAddress != value)
                {
                    _eventAddress = value;
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
            item1.EventAddress = "13010 Arbor St, Omaha, NE 68144";

            item1.EventInfoImages = new List<EventImages>()
            {
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.laughspark.info/thumbfiles/705X705/funny-cute-cat-635796173634032620-17213.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="https://images.huffingtonpost.com/2016-05-30-1464600256-1952992-cutecatnames-thumb.jpg"},

            };

            item1.EventDescription = "event description";

            EventInfo item2 = new EventInfo();
            item2.EventDateTime = DateTime.Now;
            item2.EventName = "Event 2";
            item2.EventDescription = "event description";
            item2.EventAddress = "700 S 72nd St, Omaha, NE 68114";
            item2.EventInfoImages = new List<EventImages>()
            {
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.laughspark.info/thumbfiles/705X705/funny-cute-cat-635796173634032620-17213.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="https://images.huffingtonpost.com/2016-05-30-1464600256-1952992-cutecatnames-thumb.jpg"},

            };

            EventInfo item3 = new EventInfo();
            item3.EventDateTime = DateTime.Now;
            item3.EventName = "Event 3";
            item3.EventDescription = "event description";
            item3.EventAddress = "14128 Arbor St, Omaha, NE 68144";

            item3.EventInfoImages = new List<EventImages>()
            {
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.laughspark.info/thumbfiles/705X705/funny-cute-cat-635796173634032620-17213.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="https://images.huffingtonpost.com/2016-05-30-1464600256-1952992-cutecatnames-thumb.jpg"},

            };

            EventInfo item4 = new EventInfo();
            item4.EventDateTime = DateTime.Now;
            item4.EventName = "Event 4";
            item4.EventDescription = "event description";
            item4.EventAddress = "13010 Arbor St, Omaha, NE 68144";
            item4.EventInfoImages = new List<EventImages>()
            {
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.laughspark.info/thumbfiles/705X705/funny-cute-cat-635796173634032620-17213.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="https://images.huffingtonpost.com/2016-05-30-1464600256-1952992-cutecatnames-thumb.jpg"},

            };

            EventInfo item5 = new EventInfo();
            item5.EventDateTime = DateTime.Now;
            item5.EventName = "Event 5";
            item5.EventDescription = "event description";
            item5.EventAddress = "13010 Arbor St, Omaha, NE 68144";
            item5.EventInfoImages = new List<EventImages>()
            {
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.laughspark.info/thumbfiles/705X705/funny-cute-cat-635796173634032620-17213.jpg"},
                new EventImages() {Name = "",ImageUrl="http://www.twitrcovers.com/wp-content/uploads/2012/09/Cute-Cat.jpg"},
                new EventImages() {Name = "",ImageUrl="https://images.huffingtonpost.com/2016-05-30-1464600256-1952992-cutecatnames-thumb.jpg"},

            };


            info.Add(item1);
            info.Add(item2);
            info.Add(item3);
            info.Add(item4);
            info.Add(item5);


            return info;
        }
    }

}

