using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using Database;
using Database.Factory;
namespace NMMEvent.Viewmodels
{
	public class EventPageViewModel : BaseViewModel
	{
		#region Properties

		List<DCEvents> _eventList;
		public List<DCEvents> EventList
		{
			get { return _eventList; }
			set { _eventList = value; }
		}

		DCEvents _selectedEventItem;
		public DCEvents SelectedEventItem
		{
			get { return _selectedEventItem; }
			set
			{
				_selectedEventItem = value;
				_selectedEventItem = null;
				OnPropertyChanged("SelectedEventItem");
			}
		}

		public ManagerFactoryInitalizers FactoryInitalizers = new ManagerFactory();

		#endregion

		public EventPageViewModel(INavigation navigation) : base(navigation)
		{
			EventList = FactoryInitalizers.CreateEventManager().GetEvents().Result;
		}

		public void DidSelectRow(int eventId, string eventName)
		{
			NavigateTo(new Interface.EventDetailsPage(eventId, eventName));
		}
	}
}
