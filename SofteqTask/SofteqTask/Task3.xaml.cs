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
    public partial class Task3 : ContentPage
    {
        public Task3()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            entryValues.Completed += EntryValuesCompleted;
        }

        private void EntryValuesCompleted(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;
            entry.Placeholder = "";
            char[] arr = MyFunctions.ToCharArray(entry.Text);
            int wordsCount = MyFunctions.WordCount(arr);

            if (wordsCount > 3 || wordsCount < 3)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input. You must input 3 values";
                lb.Text = "";
                return;
            }

            string[] numbers = MyFunctions.ToStringArray(arr, wordsCount);

            int A, B, N;
            try
            {
                A = Convert.ToInt32(numbers[0]);
                B = Convert.ToInt32(numbers[1]);
                N = Convert.ToInt32(numbers[2]);
            }
            catch
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input";
                lb.Text = "";
                return;
            }

            if(A < 1 || A > 9)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input of first value";
                lb.Text = "";
                return;
            }
            else if(B < 1 || B > 9)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input of second value";
                lb.Text = "";
                return;
            }
            else if(N < 10 || N > 99)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input of third value";
                lb.Text = "";
                return;
            }

            double result = MyFunctions.GetResultInThirdTask(A, B, N);
            lb.Text = $"{result}";
        }
    }
}