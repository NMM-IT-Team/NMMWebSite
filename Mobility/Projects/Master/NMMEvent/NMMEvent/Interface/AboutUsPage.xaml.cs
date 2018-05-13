using System;
using System.Collections.Generic;
using NMMEvent.Viewmodels;
using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class AboutUsPage : ContentPage
	{
		AboutUsViewModel _viewModel;

		public AboutUsPage()
		{
			InitializeComponent();
			_viewModel = new AboutUsViewModel();
			BindingContext = _viewModel;
			Title = "About us";



		}
	}
}
