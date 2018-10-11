using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RadioButtonListView
{
    public class RadioButton : StackLayout
    {
        Label lblEmpty = new Label { TextColor = Color.Black, Text = "◯", VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };
        Label lblFilled = new Label { TextColor = Color.Accent, Text = "●", IsVisible = false, Scale = 0.9, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

        private bool _isDisabled;

        public RadioButton()
        {
            //if (Device.RuntimePlatform != Device.iOS)
            //lblText.FontSize = lblText.FontSize *= 1.5;
            lblEmpty.FontSize = 24;
            lblFilled.FontSize = 20;
            Orientation = StackOrientation.Horizontal;
            this.Children.Add(new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    lblEmpty,
                    lblFilled
                },
               // MinimumWidthRequest = GlobalSetting.Size * 1.66,
            });
          //  this.Children.Add(lblText);
            this.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(Tapped) });
        }







        public event EventHandler Clicked;


        public ICommand ClickCommand { get; set; }


        public object CommandParameter { get; set; }
     

        public object Value { get; set; }
      
        public bool IsChecked { get => lblFilled.IsVisible; set { lblFilled.IsVisible = value; SetValue(IsCheckedProperty, value); } }
       
        public bool IsDisabled { get => _isDisabled; set { _isDisabled = value; this.Opacity = value ? 0.6 : 1; } }
     
       
        public View ContentView { get; set; }
    

      

     
      
        public double CircleSize { get => lblEmpty.FontSize; set => SetCircleSize(value); }
       
       

        public Color Color { get => lblFilled.TextColor; set => lblFilled.TextColor = value; }
      
        public Color CircleColor { get => lblEmpty.TextColor; set => lblEmpty.TextColor = value; }
      

        #region BindableProperties
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(RadioButton), false, propertyChanged: (bo, ov, nv) => (bo as RadioButton).IsChecked = (bool)nv);
        public static readonly BindableProperty ContentViewProperty = BindableProperty.Create(nameof(ContentView), typeof(View), typeof(RadioButton),null, propertyChanged: (bo, ov, nv) =>  (bo as RadioButton).HandleContentView((View)nv));
       // [Obsolete("This property is depreciated, use TextFontSize instead", true)] public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(RadioButton), 20.0, propertyChanged: (bo, ov, nv) => (bo as RadioButton).FontSize = (double)nv);
       // public static readonly BindableProperty TextFontSizeProperty = BindableProperty.Create(nameof(TextFontSize), typeof(double), typeof(RadioButton), 20.0, propertyChanged: (bo, ov, nv) => (bo as RadioButton).TextFontSize = (double)nv);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(RadioButton), Color.Default, propertyChanged: (bo, ov, nv) => (bo as RadioButton).Color = (Color)nv);
        public static readonly BindableProperty CircleColorProperty = BindableProperty.Create(nameof(CircleColor), typeof(Color), typeof(RadioButton), Color.Default, propertyChanged: (bo, ov, nv) => (bo as RadioButton).CircleColor = (Color)nv);
        //public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(RadioButton), Color.Default, propertyChanged: (bo, ov, nv) => (bo as RadioButton).TextColor = (Color)nv);
        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create(nameof(ClickCommand), typeof(ICommand), typeof(RadioButton), null, propertyChanged: (bo, ov, nv) => (bo as RadioButton).ClickCommand = (ICommand)nv);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(RadioButton), propertyChanged: (bo, ov, nv) => (bo as RadioButton).CommandParameter = nv);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        #endregion

       
        void Tapped()
        {
            if (IsDisabled) return;
            IsChecked = !IsChecked;
            Clicked?.Invoke(this, new EventArgs());
            ClickCommand?.Execute(CommandParameter ?? Value);
        }



        private void HandleContentView(View view)
        {
            if(this.Children.Count > 1)
            {
                this.Children.Remove(Children.LastOrDefault());
            }
            view.VerticalOptions = LayoutOptions.Center;
            view.HorizontalOptions = LayoutOptions.FillAndExpand;

            Children.Add(view);

        }


      
        void SetCircleSize(double value)
        {
            lblEmpty.FontSize = value;
            lblFilled.FontSize = value * .92;
            if (this.Children.Count > 0)
                this.Children[0].MinimumWidthRequest = value * 1.66;
        }



    }
}
