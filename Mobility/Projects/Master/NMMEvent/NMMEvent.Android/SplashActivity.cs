
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace NMMEvent.Droid
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, Label = "NMM")]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.splash);
			ThreadPool.QueueUserWorkItem(o => LoadActivity());
		}

		void LoadActivity()
		{
			Thread.Sleep(100); // Simulate a long pause
			RunOnUiThread(() => StartActivity(typeof(MainActivity)));
		}
	}
}
