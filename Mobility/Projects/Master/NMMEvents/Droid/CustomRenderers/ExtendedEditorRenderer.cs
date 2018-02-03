using System;
using NMMEvents.UI;
using NMMEvents.Droid;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Text.Method;
//https://stackoverflow.com/questions/47047813/how-to-make-xamarin-forms-editor-scrollable-auto-resizable

[assembly: ExportRenderer(typeof(Editor), typeof(ExtendedEditorRenderer))]
namespace NMMEvents.Droid
{

    public class DroidTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            v.Parent?.RequestDisallowInterceptTouchEvent(true);
            if ((e.Action & MotionEventActions.Up) != 0 && (e.ActionMasked & MotionEventActions.Up) != 0)
            {
                v.Parent?.RequestDisallowInterceptTouchEvent(false);
            }
            return false;
        }
    }


    public class ExtendedEditorRenderer : EditorRenderer
    {
        Context _context;

        public ExtendedEditorRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;

                //While scrolling inside Editor stop scrolling parent view.
                nativeEditText.OverScrollMode = OverScrollMode.Always;
                nativeEditText.ScrollBarStyle = ScrollbarStyles.InsideInset;
                nativeEditText.SetOnTouchListener(new DroidTouchListener());
                nativeEditText.Focusable = false;
                nativeEditText.SetSelection(0, 0);

                //For Scrolling in Editor innner area
                Control.VerticalScrollBarEnabled = true;

                Control.MovementMethod = ScrollingMovementMethod.Instance;
                Control.ScrollBarStyle = ScrollbarStyles.InsideInset;
                //Force scrollbars to be displayed
                Android.Content.Res.TypedArray a = Control.Context.Theme.ObtainStyledAttributes(new int[0]);
                InitializeScrollbars(a);
                a.Recycle();
            }
        }

    }
}
