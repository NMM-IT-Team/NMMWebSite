using System;
using System.Collections.ObjectModel;
using System.Linq;
using NMMEvents.BusinessObjects;
using System.Windows.Input;
using Xamarin.Forms;
using NMMEvents.UI.Views;
using System.Collections.Generic;

namespace NMMEvents.UI.ViewModels
{
    public class SlideMenuViewModel : BaseViewModel
    {
        #region Properties

        private List<MenuInfo> _menuInfoList;
        public List<MenuInfo> MenuInfoList
        {
            get { return _menuInfoList; }
            set { _menuInfoList = value; }
        }

        private Command _onListViewRowSelect;
        public ICommand OnListViewRowSelect
        {
            get
            {
                if (_onListViewRowSelect == null)
                {
                    _onListViewRowSelect = new Command(DidSelectRow);
                }
                return _onListViewRowSelect;
            }
        }

        #endregion

        #region constructor
        public SlideMenuViewModel(INavigation navigation) : base(navigation)
        {
            MenuInfoList = MenuInfo.GetMenuItems();
        }
        #endregion

        #region Events
        private void DidSelectRow(object sender)
        {
            if (sender is MenuInfo)
            {
                MenuInfo selectedMenuInfo = sender as MenuInfo;

                switch (selectedMenuInfo.MenuTitleId)
                {
                    case 1:
                        //Upcoming event
                        break;

                    case 2:

                        Navigation.PushAsync(new NewsLetterPage());
                        break;
                }

            }
        }

        private void SelectedItemOnTableView()
        {

        }


        #endregion
    }
}
