using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using NMMEvents.UI;
using NMMEvents.BusinessObjects;

namespace NMMEvents.Droid
{
    public class ExtendedListViewRendererAdapter : BaseAdapter
    {
        readonly Activity context;
        IList<object> tableItems = new List<object>();

        public IEnumerable<object> Items
        {
            set
            {
                tableItems = value.ToList();
            }
        }

        public ExtendedListViewRendererAdapter(Activity context, ExtendedListView view)
        {
            this.context = context;
            tableItems = view.Items.ToList();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return tableItems.ElementAt(position) as Java.Lang.Object;
        }

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = tableItems[position];

            var view = convertView;
            if (view == null)
            {
                // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.NativeAndroidEventCell, null);
            }

            //TODO: Use reflection and fix this use proper way to re-use this component
            if (item is EventInfo)
            {
                view.FindViewById<TextView>(Resource.Id.textView1).Text = ((EventInfo)item).EventName;
                view.FindViewById<TextView>(Resource.Id.textView2).Text = ((EventInfo)item).EventDateTime.ToString();
            }
            else if (item is NewsInfo)
            {
                view.FindViewById<TextView>(Resource.Id.textView1).Text = ((NewsInfo)item).NewsTitle;
            }

            // grab the old image and dispose of it
            if (view.FindViewById<ImageView>(Resource.Id.imageView1).Drawable != null)
            {
                using (var image = view.FindViewById<ImageView>(Resource.Id.imageView1).Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            //image.Bitmap.Recycle ();
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            // If a new image is required, display it
            if (!String.IsNullOrWhiteSpace("hello image"))
            {
                context.Resources.GetBitmapAsync("http://www.myiconfinder.com/uploads/iconsets/256-256-64273d52c282e3b26d2d0968d08b9d8d.png").ContinueWith((t) =>
                {
                    var bitmap = t.Result;
                    if (bitmap != null)
                    {
                        view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageBitmap(bitmap);
                        bitmap.Dispose();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                // clear the image
                view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageBitmap(null);
            }

            return view;
        }

    }
}
