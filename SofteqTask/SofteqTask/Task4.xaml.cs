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
    public partial class Task4 : ContentPage
    {
        public Task4()
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

            if (wordsCount > 2 || wordsCount < 2)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input. You must input 2 values";
                lb.Text = "";
                return;
            }

            string[] numbers = MyFunctions.ToStringArray(arr, wordsCount);

            int whiteRotsCount, blackRotsCount;
            try
            {
                whiteRotsCount = Convert.ToInt32(numbers[0]);
                blackRotsCount = Convert.ToInt32(numbers[1]);
            }
            catch
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input";
                lb.Text = "";
                return;
            }

            if (whiteRotsCount < 1 || whiteRotsCount > 1000)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input of first value";
                lb.Text = "";
                return;
            }
            else if (blackRotsCount < 1 || blackRotsCount > 1000)
            {
                entry.Text = "";
                entry.Placeholder = "Incorerct input of second value";
                lb.Text = "";
                return;
            }

            double result = MyFunctions.GetResultInFourthTask(whiteRotsCount, blackRotsCount);
            lb.Text = $"Min count of motions = {result}";
        }
    }
}