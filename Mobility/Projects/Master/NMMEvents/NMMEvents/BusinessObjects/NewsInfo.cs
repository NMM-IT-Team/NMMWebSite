using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NMMEvents.BusinessObjects
{
    public class NewsInfo : BaseBusinessObject
    {
        #region Properties

        private string _newsDescription;
        public string NewsDescription
        {
            get { return _newsDescription; }
            set
            {
                if (_newsDescription != value)
                {
                    _newsDescription = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _newsTitle;
        public string NewsTitle
        {
            get { return _newsTitle; }
            set
            {
                if (_newsTitle != value)
                {
                    _newsTitle = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _newsDateTime;
        public DateTime NewsDateTime
        {
            get { return _newsDateTime; }
            set
            {
                if (_newsDateTime != value)
                {
                    _newsDateTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion


        public NewsInfo()
        {
        }

        public static ObservableCollection<NewsInfo> GetNewsInfoTempList()
        {
            ObservableCollection<NewsInfo> info = new ObservableCollection<NewsInfo>();

            NewsInfo item1 = new NewsInfo();
            item1.NewsDateTime = DateTime.Now;
            item1.NewsTitle = "News 1";
            item1.NewsDescription = "news description";

            NewsInfo item2 = new NewsInfo();
            item2.NewsDateTime = DateTime.Now;
            item2.NewsTitle = "news 2";
            item2.NewsDescription = "news description";

            NewsInfo item3 = new NewsInfo();
            item3.NewsDateTime = DateTime.Now;
            item3.NewsTitle = "news 3";
            item3.NewsDescription = "news description";

            NewsInfo item4 = new NewsInfo();
            item4.NewsDateTime = DateTime.Now;
            item4.NewsTitle = "news 4";
            item4.NewsDescription = "news description";

            NewsInfo item5 = new NewsInfo();
            item5.NewsDateTime = DateTime.Now;
            item5.NewsTitle = "news 4";
            item5.NewsDescription = "news description";


            info.Add(item1);
            info.Add(item2);
            info.Add(item3);
            info.Add(item4);
            info.Add(item5);


            return info;
        }


    }
}
