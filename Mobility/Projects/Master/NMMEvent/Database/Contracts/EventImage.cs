using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Contracts
{
	public class EventImage
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string ImageSource { get; set; }

		public List<EventImage> PopulateEventImage(int eventId)
		{
			switch (eventId)
			{
				case 1:
					return PopulateCarouselImageForPadwa();

				case 2:
					return PopulateCarouselImageForPicnic();

				case 3:
					return PopulateCarouselImageForGanpati();

				case 4:
					return PopulateCarouselImageForDiwali();

				case 5:
					return PopulateCarouselImageForWorkshop();

			}

			return null;
		}

		List<EventImage> PopulateCarouselImageForPadwa()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 4; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = string.Format("padwa{0}.jpg", index);
				eventImage.Add(eventImages);
			}

			return eventImage;
		}

		List<EventImage> PopulateCarouselImageForPicnic()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 2; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = string.Format("picnic{0}.jpg", index);
				eventImage.Add(eventImages);
			}

			return eventImage;
		}

		List<EventImage> PopulateCarouselImageForGanpati()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 1; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = string.Format("ganpati{0}.jpg", index);
				eventImage.Add(eventImages);
			}

			return eventImage;
		}

		List<EventImage> PopulateCarouselImageForDiwali()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 3; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = string.Format("dipawali{0}.jpg", index);
				eventImage.Add(eventImages);
			}

			return eventImage;
		}

		List<EventImage> PopulateCarouselImageForWorkshop()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 3; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = string.Format("workshop{0}.jpg", index);
				eventImage.Add(eventImages);
			}

			return eventImage;
		}
	}
}
