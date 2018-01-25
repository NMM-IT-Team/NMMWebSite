using System;
using System.Collections.Generic;
using NMMEvents.UI.ViewModels;
using NMMEvents.BusinessObjects;
using Xamarin.Forms;
using System.Linq;

namespace NMMEvents.UI.Views
{
    public partial class UpComingEventsPage : ContentPage
    {
        #region Members

        private UpComingEventsViewModel _viewModel;

        #endregion

        #region Construction

        public UpComingEventsPage()
        {
            _viewModel = new UpComingEventsViewModel(this.Navigation);
            this.BindingContext = _viewModel;
            InitializeComponent();
            uxEventList.Items = _viewModel.EventList.ToList();
        }
        #endregion
    }
}
