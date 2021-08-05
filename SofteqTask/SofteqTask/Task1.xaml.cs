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

            string[] numbers = new string[wordsCount];
            string buffer = "";
            for(int i = 0, iForNumbers = 0; i < arr.Length; i++)
            {
                if(i == arr.Length - 1 && arr[i] != ' ')
                {
                    buffer += arr[i];
                    numbers[iForNumbers] = buffer;
                    iForNumbers++;
                    buffer = "";
                }
                else if(arr[i] != ' ')
                {
                    buffer += arr[i];
                }
                else if(i > 0 && arr[i] == ' ' && arr[i - 1] != ' ')
                {
                    numbers[iForNumbers] = buffer;
                    iForNumbers++;
                    buffer = "";
                }
            }

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