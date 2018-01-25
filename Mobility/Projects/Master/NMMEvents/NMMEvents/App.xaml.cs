using Xamarin.Forms;
using NMMEvents.UI.Views;
namespace NMMEvents
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RootSlideMenuPage slideMenuPage = new RootSlideMenuPage();
            //slideMenuPage.Master = new SlideDashboardMenuListPage();
            //slideMenuPage.Detail = new UpComingEventsPage();

            //NavigationPage navPage = new NavigationPage(slideMenuPage);
            MainPage = slideMenuPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
