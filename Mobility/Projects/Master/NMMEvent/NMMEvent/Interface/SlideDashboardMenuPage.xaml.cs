using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class SlideDashboardMenuPage : ContentPage
	{
		public ListView ListView { get { return uxSlideDashboardMenuList; } }
		Viewmodels.SlideMenuViewModel _viewmodel = new Viewmodels.SlideMenuViewModel();

		public SlideDashboardMenuPage()
		{
			InitializeComponent();
			this.Title = "Menu";
			uxSlideDashboardMenuList.ItemsSource = _viewmodel.MenuInfoList;
		}
	}
}
