using SpectTest.CustomControls;
using SpectTest.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace SpectTest.iOS
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
            //Control.Layer.BorderWidth = 0;
            //Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}