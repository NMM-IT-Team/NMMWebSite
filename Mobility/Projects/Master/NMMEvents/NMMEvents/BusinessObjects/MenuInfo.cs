using System;
using System.Collections.Generic;
using NMMEvents.UI.Views;
namespace NMMEvents.BusinessObjects
{
    public class MenuInfo : BaseBusinessObject
    {

        #region Properties


        public Type TargetType { get; set; }

        private string _menuTitle;
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

        private int _menuTitleId;
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

        #endregion

        public MenuInfo()
        {
        }

        public static List<MenuInfo> GetMenuItems()
        {
            List<MenuInfo> info = new List<MenuInfo>();
            info.Add(new MenuInfo() { MenuTitle = "Upcoming events", MenuTitleId = 1, TargetType = typeof(UpComingEventsPage) });
            info.Add(new MenuInfo() { MenuTitle = "News letter", MenuTitleId = 2, TargetType = typeof(NewsLetterPage) });
            info.Add(new MenuInfo() { MenuTitle = "Membership benefits", MenuTitleId = 3, TargetType = typeof(MemberShipBenefitsPage) });
            info.Add(new MenuInfo() { MenuTitle = "About us", MenuTitleId = 4, TargetType = typeof(AboutUsPage) });
            return info;

        }
    }
}
