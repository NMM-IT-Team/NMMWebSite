using System;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NMMEvents.UI.ViewModels
{
    public class BaseViewModel
    {
        #region Members
        protected INavigation Navigation { get; private set; }
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
