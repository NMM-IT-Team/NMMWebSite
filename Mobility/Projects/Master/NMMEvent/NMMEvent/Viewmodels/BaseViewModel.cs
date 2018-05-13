using System;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace NMMEvent.Viewmodels
{
	public class BaseViewModel
	{
		#region Members
		protected INavigation Navigation { get; private set; }

		#endregion

		public BaseViewModel(INavigation navigationService)
		{
			Navigation = navigationService;
		}

		public void NavigateTo(Page pageToNavigate)
		{
			if (Navigation != null && pageToNavigate != null)
			{
				Navigation.PushAsync(pageToNavigate);
			}
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;
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
