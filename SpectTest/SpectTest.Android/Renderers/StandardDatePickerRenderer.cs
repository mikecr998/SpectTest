using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SpectTest.Controls;
using SpectTest.Droid.Renderers;

[assembly: ExportRenderer(typeof(StandardDatePicker), typeof(StandardDatePickerRenderer))]

namespace SpectTest.Droid.Renderers
{
    public class StandardDatePickerRenderer : DatePickerRenderer
    {
        public StandardDatePickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            this.Control.SetTextColor(Android.Graphics.Color.LightGray);
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.SetPadding(40, 40, 40, 40);

            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(80); //increase or decrease to changes the corner look  
            gd.SetColor(Android.Graphics.Color.Transparent);
            gd.SetStroke(3, Android.Graphics.Color.Rgb(28, 158, 180));

            this.Control.SetBackgroundDrawable(gd);            
        }
    }
}