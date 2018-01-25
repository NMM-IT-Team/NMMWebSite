using System;
using System.Collections.ObjectModel;
using System.Linq;
using NMMEvents.BusinessObjects;
using System.Windows.Input;
using Xamarin.Forms;
using NMMEvents.UI.Views;
using System.Collections.Generic;

namespace NMMEvents.UI.ViewModels
{
    public class UpComingEventsViewModel : BaseViewModel
    {

        #region Properties
        private ObservableCollection<EventInfo> _eventList;
        public ObservableCollection<EventInfo> EventList
        {
            get { return _eventList; }
            set { _eventList = value; }
        }

        private Command _onListViewRowSelect;
        public ICommand OnListViewRowSelect
        {
            get
            {
                if (_onListViewRowSelect == null)
                {
                    _onListViewRowSelect = new Command(DidSelectRow);
                }
                return _onListViewRowSelect;
            }
        }

        #endregion

        #region Constructor

        public UpComingEventsViewModel(INavigation navigation) : base(navigation)
        {
            EventList = EventInfo.GetEventInfoTempList();
        }

        public List<EventInfo> GetEventInfoListType()
        {
            if (this.EventList != null)
            {
                return this.EventList.ToList();
            }
            return null;
        }

        #endregion

        #region Events
        private void DidSelectRow()
        {
            NavigateTo(new EventDetailsPage());

        }
        #endregion
    }
}
