using System;
using System.Collections.Generic;
using NMMEvents.UI.ViewModels;
using Xamarin.Forms;

namespace NMMEvents.UI.Views
{
    public partial class SlideDashboardMenuListPage : ContentPage
    {
        #region Members

        private SlideMenuViewModel _viewModel;
        public ListView ListView { get { return uxSlideDashboardMenuList; } }

        #endregion

        public SlideDashboardMenuListPage()
        {
            _viewModel = new SlideMenuViewModel(this.Navigation);
            this.BindingContext = _viewModel;
            InitializeComponent();
            this.Title = "Menu";
            uxSlideDashboardMenuList.Items = _viewModel.MenuInfoList;
            uxSlideDashboardMenuList.ItemsSource = _viewModel.MenuInfoList;
        }
    }
}
