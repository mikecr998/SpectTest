using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SpectTest.Controls
{
    public class CustomEntry : ContentView
    {
        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(CustomEntry), 0);

        public static BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(CustomEntry), new Thickness(5));

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomEntry), Color.Transparent);

        public static BindableProperty ImageSourceProperty =
            BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(CustomEntry), default(ImageSource));

        public static BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(CustomEntry), string.Empty);

        public static BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(CustomEntry), Color.Red);

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomEntry), string.Empty, BindingMode.TwoWay);

        public static BindableProperty PasswordProperty =
            BindableProperty.Create(nameof(Password), typeof(bool), typeof(CustomEntry), false);

        public static BindableProperty KeyboardTypeProperty =
            BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard), typeof(CustomEntry), Keyboard.Default);



        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }
        public ImageSource Source
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }
        public string Text
        {
            get => base.GetValue(TextProperty)?.ToString();
            set => base.SetValue(TextProperty, value);
        }
        public bool Password
        {
            get => (bool)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }
        public Keyboard KeyboardType
        {
            get => (Keyboard)GetValue(KeyboardTypeProperty);
            set => SetValue(KeyboardTypeProperty, value);
        }
    }
}
