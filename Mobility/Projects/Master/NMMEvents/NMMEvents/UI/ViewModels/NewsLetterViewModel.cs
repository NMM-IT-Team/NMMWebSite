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
    public class NewsLetterViewModel : BaseViewModel
    {
        #region Properties
        private ObservableCollection<NewsInfo> _newsInfoList;
        public ObservableCollection<NewsInfo> NewsInfoList
        {
            get { return _newsInfoList; }
            set { _newsInfoList = value; }
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

        public NewsLetterViewModel(INavigation navigation) : base(navigation)
        {
            NewsInfoList = NewsInfo.GetNewsInfoTempList();
        }

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
                MessagingCenter.Send<object>(this, "EndRefreshNewsLetterPage");
            });

            return Task.Delay(4000);
        }

        #endregion

    }
}
