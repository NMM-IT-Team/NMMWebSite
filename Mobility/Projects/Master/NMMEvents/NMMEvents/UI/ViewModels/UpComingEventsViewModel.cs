using System;
using System.Collections.ObjectModel;
using System.Linq;
using NMMEvents.BusinessObjects;
using System.Windows.Input;
using Xamarin.Forms;
using NMMEvents.UI.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        private Command _onRefreshCommand;
        public ICommand OnRefreshCommand
        {
            get
            {
                if (_onRefreshCommand == null)
                {
                    _onRefreshCommand = new Command(async () => await Retrieve());
                }
                return _onRefreshCommand;
            }
        }

        #endregion

        #region Constructor

        public UpComingEventsViewModel(INavigation navigation) : base(navigation)
        {
            IsRefreshing = false;
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

        protected override Task Retrieve()
        {
            //TODO: Get back to this and implement using different pattern
            Device.BeginInvokeOnMainThread(() =>
            {
                MessagingCenter.Send<object>(this, "EndRefreshUpcomingEvent");
            });

            return Task.Delay(4000);
        }

        #endregion
    }
}
