using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SpectTest.CustomControls;
using SpectTest.Droid.Renderers;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(BorderlessDatePickerRenderer))]

namespace SpectTest.Droid.Renderers
{
    public class BorderlessDatePickerRenderer : DatePickerRenderer
    {
        public BorderlessDatePickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            Control.Background = null;
        }
    }
}