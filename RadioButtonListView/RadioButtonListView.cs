using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections;

namespace RadioButtonListView
{
    public class RadioButtonListView : ListView
    {
        public RadioButtonListView() 
        {
            Cells = new List<RadioButtonViewCell>();
            ItemSelected += Handle_ItemSelected;

        }

        private List<RadioButtonViewCell> Cells;

        public Color CircleColor { get; set; } = Color.Black;

        public Color SelectedColor { get; set; } = Color.Black;

     



        protected override void SetupContent(Cell content, int index)
        {
            var con = content as RadioButtonViewCell;
            Cells.Add(con);
            con.Button.ClickCommand = new Command(ToggleClick);
            con.Button.CommandParameter = index;
            con.Button.Color = SelectedColor;
            con.Button.CircleColor = CircleColor;
            con.Tag = index;
            if (index == SelectedIndex) HandleCells(index);
           
            base.SetupContent(con, index);
        }

        private void ToggleClick(object obj)
        {
            SelectedIndex = (int)obj;
            //HandleCells((int)obj);
        }

        protected override void UnhookContent(Cell content)
        {
            base.UnhookContent(content);
        }


        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
            "SelectedIndex", typeof(int), typeof(RadioButtonListView), 0, propertyChanged: OnSelectedIndexChanged);

        static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as RadioButtonListView).HandleCells((int)newValue);
        }

        public  int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }


        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is null) return;
            var ar = ItemsSource.Cast<object>().ToArray();
            var index = Array.FindIndex(ar, (obj) => obj == e.SelectedItem);
            SelectedIndex = index;
            ((ListView)sender).SelectedItem = null;
        }



        private void HandleCells(int index)
        {
            Cells.ForEach((obj) =>
            {
                if(obj.Tag == index)
                {
                    obj.Button.IsChecked = true;

                }
                else obj.Button.IsChecked = false;
            });
        }

    }



  


    


    public class RadioButtonViewCell : ViewCell
    {

        public new View View { get => base.View;
            set 
            {
                var stack = new StackLayout() { Padding = Padding,Orientation = StackOrientation.Horizontal,BackgroundColor = BackgroundColor, Margin = Margin };
                var btn = new RadioButton() { VerticalOptions = LayoutOptions.Center };
                stack.Children.Add(btn);
                stack.Children.Add(value);
                base.View = stack;
                Button = btn;
            }
        }

        public RadioButton Button { get; set; }

        public int Tag { get; set; }


        public Color BackgroundColor { get; set; } = Color.Transparent;

        public Thickness Padding { get; set; } = 10;

        public Thickness Margin { get; set; }
      

    }


}
