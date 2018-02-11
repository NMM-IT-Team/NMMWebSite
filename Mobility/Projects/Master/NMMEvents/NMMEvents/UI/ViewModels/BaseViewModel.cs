using System;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using Plugin.Connectivity;

namespace NMMEvents.UI.ViewModels
{
    public class BaseViewModel
    {
        #region Members
        protected INavigation Navigation { get; private set; }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commmands

        private Command _onRetrieveCommand;
        public virtual ICommand OnRetrieveCommand
        {
            get
            {
                if (_onRetrieveCommand == null)
                {
                    _onRetrieveCommand = new Command(async () =>
                    {
                        try
                        {
                            await Retrieve();
                        }
                        catch (Exception ex)
                        {
                            WriteOnConsole(ex.Message);
                        }
                    });
                }

                return _onRetrieveCommand;
            }
        }

        #endregion


        #region Constructor

        public BaseViewModel(INavigation navigationService)
        {
            Navigation = navigationService;
        }

        #endregion

        #region Public methods

        public void NavigateTo(Page pageToNavigate)
        {
            if (Navigation != null && pageToNavigate != null)
            {
                Navigation.PushAsync(pageToNavigate);
            }
        }

        //TODO: Need to test this in real device for no internet
        public bool CheckInternet()
        {
            //if (!CrossConnectivity.IsSupported)
            //return true;

            var connectivity = CrossConnectivity.Current;

            try
            {
                return connectivity.IsConnected;
            }
            finally
            {
                CrossConnectivity.Dispose();
            }
        }

        public void DisplayNoInternetConnectionAlert()
        {
            Application.Current.MainPage.DisplayAlert("Internet connection required", "It looks like your are not connected to the internet, please connect to a working internet connection and try again", "OK");
        }

        //writes string on console
        public void WriteOnConsole(string data)
        {
            System.Diagnostics.Debug.WriteLine(data);
        }

        #endregion

        #region protected methods

        protected virtual Task Retrieve()
        {
            return Task.Delay(0);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="name">Name of property.</param>
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
