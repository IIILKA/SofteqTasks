using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SofteqTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Task1 : ContentPage
    {
        public Task1()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            entryValues.Completed += EntryValues_Completed;
        }

        private void EntryValues_Completed(object sender, EventArgs e)
        {
            char[] arr = MyFunctions.ToCharArray(entryValues.Text);
            int wordsCount = MyFunctions.WordCountInFirstLine(arr);

            string[] numbers = MyFunctions.ToStringArray(arr, wordsCount);

            double x;
            Label lb = null;
            foreach(string s in numbers)
            {
                try
                {
                    x = Convert.ToDouble(s);
                    double result = Math.Pow(x, 4) + (4 * Math.Pow(x, 3)) + (-20 * Math.Pow(x, 2)) + 13.44;
                    lb = new Label { FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), TextColor = Color.Black, Margin = new Thickness(10, 0) };
                    lb.Text = $"f({x}) = {string.Format("{0:0.000}", result)}";
                    stackLayout1.Children.Add(lb);
                }
                catch
                {
                    lb = new Label { FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), TextColor = Color.Black, Margin = new Thickness(10, 0) };
                    lb.Text = $"incorrect input: {s}";
                    stackLayout1.Children.Add(lb);
                }
            }

        }
    }
}