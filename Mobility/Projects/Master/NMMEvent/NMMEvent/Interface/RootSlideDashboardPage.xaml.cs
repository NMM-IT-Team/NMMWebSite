using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NMMEvent.Interface
{
	public partial class RootSlideDashboardPage : MasterDetailPage, IDisposable
	{
		private Type _detailPageType;

		public RootSlideDashboardPage()
		{
			InitializeComponent();
			masterPage.ListView.ItemSelected += OnMenuItemSelected;
			_detailPageType = ((NavigationPage)Detail).Navigation.NavigationStack.GetType();
			MasterBehavior = MasterBehavior.Popover;

		}

		void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as Viewmodels.MenuInfo;
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
	}
}
