using System.Net;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Database;
using Database.Factory;
using System;

namespace NMMEvent.Viewmodels
{
	public class CarouselItem
	{
		public ImageSource Picture { get; set; }
	}

	public class EventDetailsViewModel : BaseViewModel
	{
		Command _onDirectionButtonTapped;
		public ICommand OnDirectionButtonTapped
		{
			get
			{
				if (_onDirectionButtonTapped == null)
				{
					_onDirectionButtonTapped = new Command(OpenDirectionInMaps);
				}
				return _onDirectionButtonTapped;
			}
		}

		DCEventDetails _eventDetails;
		public DCEventDetails EventDetails
		{
			get { return _eventDetails; }
			set
			{
				_eventDetails = value;
			}
		}

		string _eventTitle;
		public string EventTitle
		{
			get { return _eventTitle; }
			set { _eventTitle = value; }
		}

		string _eventImage;
		public string EventImage
		{
			get { return _eventImage; }
			set { _eventImage = value; }
		}



		public ObservableCollection<CarouselItem> pictures { get; set; }

		public ManagerFactoryInitalizers FactoryInitalizers = new ManagerFactory();

		public EventDetailsViewModel(INavigation navigation, int eventId, string eventName) : base(navigation)
		{
			EventTitle = eventName;
			EventDetails = FactoryInitalizers.CreateEventManager().GetEventDetails(eventId).Result;
			EventImage = new Database.Contracts.EventImage().PopulateEventImage(EventDetails.EventId);

		}

		void OpenDirectionInMaps()
		{
			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					//Device.OpenUri(
					//new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(SelectedEvent.Location))));
					break;
				case Device.Android:
					Device.OpenUri(
						new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(EventDetails.Location))));
					break;
			}
		}

	}
}
