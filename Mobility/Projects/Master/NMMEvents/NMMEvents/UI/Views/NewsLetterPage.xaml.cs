using System;
using System.Collections.Generic;
using NMMEvents.UI.ViewModels;
using NMMEvents.BusinessObjects;
using Xamarin.Forms;
using System.Linq;

namespace NMMEvents.UI.Views
{
    public partial class NewsLetterPage : ContentPage
    {
        #region Members

        private NewsLetterViewModel _viewModel;

        #endregion

        public NewsLetterPage()
        {
            _viewModel = new NewsLetterViewModel(this.Navigation);
            this.BindingContext = _viewModel;
            InitializeComponent();
            uxNewsLetterList.Items = _viewModel.NewsInfoList.ToList();

            //TODO: implement this using different pattern
            MessagingCenter.Subscribe<object>(this, "EndRefreshNewsLetterPage", (sender) =>
            {
                uxNewsLetterList.EndRefresh();
            });

        }
    }
}
