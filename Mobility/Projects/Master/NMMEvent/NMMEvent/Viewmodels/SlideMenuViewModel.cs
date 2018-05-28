using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.Generic;
namespace NMMEvent.Viewmodels
{
	public class BaseBusinessObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName]string name = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;
			changed(this, new PropertyChangedEventArgs(name));

		}
	}

	public class MenuInfo : BaseBusinessObject
	{
		public Type TargetType { get; set; }

		string _menuTitle;
		public string MenuTitle
		{
			get { return _menuTitle; }
			set
			{
				if (_menuTitle != value)
				{
					_menuTitle = value;
					NotifyPropertyChanged();
				}
			}
		}

		string _menuImage;
		public string MenuImage
		{
			get { return _menuImage; }
			set
			{
				if (_menuImage != value)
				{
					_menuImage = value;
					NotifyPropertyChanged();
				}
			}
		}

		int _menuTitleId;
		public int MenuTitleId
		{
			get { return _menuTitleId; }
			set
			{
				if (_menuTitleId != value)
				{
					_menuTitleId = value;
					NotifyPropertyChanged();
				}
			}
		}

		public static List<MenuInfo> GetMenuItems()
		{
			var info = new List<MenuInfo>();
			info.Add(new MenuInfo { MenuTitle = "Events", MenuImage = "eventicon.png", MenuTitleId = 1, TargetType = typeof(Interface.EventPage) });
			info.Add(new MenuInfo { MenuTitle = "Benefits", MenuImage = "benefiticon.png", MenuTitleId = 2, TargetType = typeof(Interface.MembershipBenefitsPage) });
			info.Add(new MenuInfo { MenuTitle = "About us", MenuImage = "info.png", MenuTitleId = 3, TargetType = typeof(Interface.AboutUsPage) });
			return info;

		}
	}

	public class SlideMenuViewModel
	{
		List<MenuInfo> _menuInfoList;
		public List<MenuInfo> MenuInfoList
		{
			get { return _menuInfoList; }
			set { _menuInfoList = value; }
		}

		public SlideMenuViewModel()
		{
			MenuInfoList = MenuInfo.GetMenuItems();
		}


	}
}
