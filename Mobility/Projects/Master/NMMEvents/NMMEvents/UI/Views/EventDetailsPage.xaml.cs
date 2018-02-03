using System;
using System.Collections.Generic;
using NMMEvents.UI.ViewModels;
using NMMEvents.BusinessObjects;
using Xamarin.Forms;
using System.Linq;


namespace NMMEvents.UI.Views
{
    public partial class EventDetailsPage : ContentPage
    {
        #region Members

        private EventDetailsViewModel _viewModel;

        #endregion

        public EventDetailsPage(EventInfo info)
        {
            InitializeComponent();
            _viewModel = new EventDetailsViewModel(this.Navigation);
            _viewModel.SelectedEvent = info;
            this.BindingContext = _viewModel;
            this.Title = info.EventName;
        }
    }
}
