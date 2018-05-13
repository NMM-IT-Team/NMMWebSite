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

		//Command _onListViewRowSelect;
		//public ICommand OnListViewRowSelect
		//{
		//	get
		//	{
		//		if (_onListViewRowSelect == null)
		//		{
		//			_onListViewRowSelect = new Command(DidSelectRow);
		//		}
		//		return _onListViewRowSelect;
		//	}
		//}

		Command _onItemSelectedCommand;
		public ICommand OnItemSelectedCommand
		{
			get
			{
				if (_onItemSelectedCommand == null)
				{
					_onItemSelectedCommand = new Command(DidSelectItem);
				}
				return _onItemSelectedCommand;
			}
		}

		public ManagerFactoryInitalizers FactoryInitalizers = new ManagerFactory();

		#endregion

		public EventPageViewModel(INavigation navigation) : base(navigation)
		{
			EventList = FactoryInitalizers.CreateEventManager().GetEvents().Result;
		}

		public void DidSelectRow(int eventId)
		{
			this.NavigateTo(new Interface.EventDetailsPage(eventId));
		}

		private void DidSelectItem()
		{

		}
	}
}
