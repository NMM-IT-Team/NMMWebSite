using System;
using System.Collections.ObjectModel;
using System.Linq;
using NMMEvents.BusinessObjects;
using System.Windows.Input;
using Xamarin.Forms;
using NMMEvents.UI.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
namespace NMMEvents.UI.ViewModels
{
    public class EventDetailsViewModel : BaseViewModel
    {
        #region Properties

        private EventInfo _selectedEvent;
        public EventInfo SelectedEvent
        {
            get { return _selectedEvent; }
            set { _selectedEvent = value; }
        }

        private Command _onDirectionButtonTapped;
        public ICommand OnDirectionButtonTapped
        {
            get
            {
                if (_onDirectionButtonTapped == null)
                {
                    _onDirectionButtonTapped = new Command(OpenDirectionInMaps);
                }
                return _onDirectionButtonTapped;
            }
        }

        private Command _onRSVPButtonTapped;
        public ICommand OnRSVPButtonTapped
        {
            get
            {
                if (_onRSVPButtonTapped == null)
                {
                    _onRSVPButtonTapped = new Command(OpenRSVPScreen);
                }
                return _onRSVPButtonTapped;
            }
        }

        #endregion

        #region Constructor
        public EventDetailsViewModel(INavigation navigation) : base(navigation)
        {

        }
        #endregion

        #region Events

        private void OpenDirectionInMaps()
        {
            WriteOnConsole("OpenDirectionInMaps");
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Device.OpenUri(
                        new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(""))));
                    break;
                case Device.Android:
                    Device.OpenUri(
                        new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(""))));
                    break;
            }
        }

        private void OpenRSVPScreen()
        {
            //TODO: detect if event is paid or free and open respective screens
            WriteOnConsole("OpenRSVPScreen");

        }


        #endregion


    }
}
