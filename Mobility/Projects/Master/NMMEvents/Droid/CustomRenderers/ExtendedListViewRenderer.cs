using System;
using NMMEvents.UI;
using NMMEvents.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(ExtendedListViewRenderer))]

namespace NMMEvents.Droid
{
    public class ExtendedListViewRenderer : ListViewRenderer
    {
        Context _context;

        public ExtendedListViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // unsubscribe
                Control.ItemSelected -= OnItemClick;
            }

            if (e.NewElement != null)
            {
                // subscribe
                Control.Adapter = new ExtendedListViewRendererAdapter(_context as Android.App.Activity, e.NewElement as ExtendedListView);
                Control.ItemSelected += OnItemClick;
            }
        }

        void OnItemClick(object sender, Android.Widget.AdapterView.ItemSelectedEventArgs e)
        {
            ((ExtendedListView)Element).OnAndroidListViewSelect(((ExtendedListView)Element).Items.ToList()[e.Position - 1]);
        }
    }
}
