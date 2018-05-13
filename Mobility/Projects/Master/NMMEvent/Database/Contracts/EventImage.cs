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
					return PopulateCarouselImageForTest1();

				case 2:
					return PopulateCarouselImageForTest2();

			}

			return null;
		}

		List<EventImage> PopulateCarouselImageForTest1()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 2; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = $"test01{index}.jpg";
				eventImage.Add(eventImages);
			}

			return eventImage;
		}

		List<EventImage> PopulateCarouselImageForTest2()
		{
			var eventImage = new List<EventImage>();

			for (int index = 0; index < 2; index++)
			{
				var eventImages = new EventImage();
				eventImages.ImageSource = $"test02_{index}.jpg";
				eventImage.Add(eventImages);
			}

			return eventImage;
		}
	}
}
