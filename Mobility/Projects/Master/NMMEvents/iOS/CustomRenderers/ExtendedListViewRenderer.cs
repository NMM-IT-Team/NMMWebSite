using UIKit;
using NMMEvents.UI;
using NMMEvents.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(ExtendedListView), typeof(ExtendedListViewRenderer))]

namespace NMMEvents.iOS
{
    public class ExtendedListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Set line style
                var view = (e.NewElement != null) ? e.NewElement as ListView : e.OldElement as ListView;
                var style = view.StyleId == null ? string.Empty : view.StyleId.ToUpper();

                switch (style)
                {
                    case "NONE":
                        Control.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                        break;
                    case "SINGLELINE":
                        Control.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
                        break;
                    case "SINGLELINEETCHED":
                        Control.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLineEtched;
                        break;
                    case "DOUBLELINEETCHED":
                        Control.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
                        break;
                }

                // Set properties based on custom renderer properties
                if (e.NewElement != null)
                {
                    var extendedListView = ((ExtendedListView)e.NewElement);
                    Control.ScrollsToTop = extendedListView.ScrollsToTop;
                    Control.ScrollEnabled = extendedListView.Scrollable;
                }

                // Hide blank rows
                Control.TableFooterView = new UIView();
            }
        }
    }
}
