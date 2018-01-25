using System;
using System.Collections.Generic;
using NMMEvents.UI.Views;
using NMMEvents.BusinessObjects;

using Xamarin.Forms;

namespace NMMEvents.UI.Views
{
    public partial class RootSlideMenuPage : MasterDetailPage, IDisposable
    {
        #region Members
        private Type _detailPageType;
        #endregion

        public RootSlideMenuPage()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnMenuItemSelected;
            _detailPageType = ((NavigationPage)Detail).Navigation.NavigationStack.GetType();
            MasterBehavior = MasterBehavior.Popover;

        }

        #region Events

        void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuInfo;
            if (item != null)
            {
                // if selected page is not one currently displayed
                if (_detailPageType != item.TargetType)
                {
                    _detailPageType = item.TargetType;
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                }

                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        public void Dispose()
        {
            masterPage.ListView.ItemSelected -= OnMenuItemSelected;
        }
        #endregion
    }
}
