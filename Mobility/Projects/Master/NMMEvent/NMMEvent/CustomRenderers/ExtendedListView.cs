using Xamarin.Forms;
using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;

namespace NMMEvent.CustomRenderers
{
	public class ExtendedListView : ListView
	{
		#region Properties

		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create("Items", typeof(IEnumerable<object>), typeof(ExtendedListView), new List<object>());

		public IEnumerable<object> Items
		{
			get { return (IEnumerable<object>)GetValue(ItemsProperty); }
			set { SetValue(ItemsProperty, value); }
		}

		/// <summary>
		/// The item tapped command property.
		/// </summary>
		public static readonly BindableProperty ItemTappedCommandProperty =
			BindableProperty.Create(nameof(ItemTappedCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

		/// <summary>
		/// Gets or sets the item tapped command.
		/// </summary>
		/// <value>The item tapped command.</value>
		public ICommand ItemTappedCommand
		{
			get { return (ICommand)GetValue(ItemTappedCommandProperty); }
			set { SetValue(ItemTappedCommandProperty, value); }
		}

		/// <summary>
		/// The item selected command property.
		/// </summary>
		public static readonly BindableProperty ItemSelectedCommandProperty =
			BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

		/// <summary>
		/// Gets or sets the item selected command.
		/// </summary>
		/// <value>The item selected command.</value>
		public ICommand ItemSelectedCommand
		{
			get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
			set { SetValue(ItemSelectedCommandProperty, value); }
		}

		/// <summary>
		/// The load more records command property.
		/// </summary>
		public static readonly BindableProperty LoadMoreCommandProperty =
			BindableProperty.Create(nameof(LoadMoreCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

		/// <summary>
		/// Gets or sets the load more command.
		/// </summary>
		/// <value>The load more command.</value>
		public ICommand LoadMoreCommand
		{
			get { return (ICommand)GetValue(LoadMoreCommandProperty); }
			set { SetValue(LoadMoreCommandProperty, value); }
		}

		/// <summary>
		/// The enables scroll to top property.
		/// </summary>
		public static readonly BindableProperty ScrollsToTopProperty =
			BindableProperty.Create(nameof(ScrollsToTop), typeof(bool), typeof(ExtendedListView), false);

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Punchlist.UI.ExtendedListView"/> scrolls to top.
		/// </summary>
		/// <value><c>true</c> if scrolls to top; otherwise, <c>false</c>.</value>
		public bool ScrollsToTop
		{
			get { return (bool)GetValue(ScrollsToTopProperty); }
			set { SetValue(ScrollsToTopProperty, value); }
		}

		/// <summary>
		/// The Scrolling enable/disable property.
		/// </summary>
		public static readonly BindableProperty ScrollableProperty =
			BindableProperty.Create(nameof(Scrollable), typeof(bool), typeof(ExtendedListView), true);

		/// <summary>
		/// Gets or sets a value indicating whether the tableview is scrollable
		/// </summary>
		/// <value><c>true</c> if tableView is scrollable; otherwise, <c>false</c>.</value>
		public bool Scrollable
		{
			get { return (bool)GetValue(ScrollableProperty); }
			set { SetValue(ScrollableProperty, value); }
		}

		#endregion

		#region Constructor

		public ExtendedListView()
		{
			this.ItemTapped += OnItemTapped;
			this.ItemSelected += OnItemSelected;
			this.ItemAppearing += OnItemAppearing;
		}

		#endregion

		#region Events

		public void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			var items = ItemsSource as IList;

			if (items != null && e.Item == items[items.Count - 1])
			{
				if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
				{
					LoadMoreCommand.Execute(null);
				}
			}
		}

		public void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			// set item selected to null so line is not highlighted after selection
			((ListView)sender).SelectedItem = null;

			if (ItemTappedCommand != null)
			{
				ItemTappedCommand.Execute(e.Item);
			}
		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			if (ItemSelectedCommand != null)
			{
				ItemSelectedCommand.Execute(e.SelectedItem);
			}
		}

		public void OnAndroidListViewSelect(object sender)
		{
			if (sender != null)
			{
				ItemSelectedCommand.Execute(sender);

			}
			else
			{
				return;
			}
		}

		#endregion
	}
}
