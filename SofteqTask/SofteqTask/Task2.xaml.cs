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
    public partial class Task2 : ContentPage
    {
        public Task2()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }

        /*protected override void OnAppearing()
        {
            Label lb = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), TextColor = Color.Black, Margin = new Thickness(10, 0) };
            stackLayout1.Children.Add(lb);
        }*/

        private void EditorValuesCompleted(object sender, EventArgs e)
        {
            Editor editor = ((Editor)sender);
            editor.Placeholder = "";
            char[] arr = MyFunctions.ToCharArray(editor.Text);
            int wordsCountInFirstLine = MyFunctions.WordCountInFirstLine(arr);

            if(wordsCountInFirstLine > 2 || wordsCountInFirstLine < 2)
            {
                editor.Text = "";
                editor.Placeholder = "Incorerct input. You must input 2 values in firs line";
                lb.Text = "";
                return;
            }

            int wordsCount = MyFunctions.WordCount(arr);

            string[] numbers = MyFunctions.ToStringArray(arr, wordsCount);

            int wheelCount, tireCount;
            try
            {
                wheelCount = Convert.ToInt32(numbers[0]);
                tireCount = Convert.ToInt32(numbers[1]);
                for(int i = 2; i < numbers.Length; i++)//проверка значений колёс
                {
                    int a = Convert.ToInt32(numbers[i]);
                }
            }
            catch
            {
                editor.Text = "";
                editor.Placeholder = "Incorerct input";
                lb.Text = "";
                return;
            }

            if(wheelCount < 4 || wheelCount > 10 || wheelCount % 2 == 1)
            {
                editor.Text = "";
                editor.Placeholder = "Incorerct wheel count";
                lb.Text = "";
                return;
            }
            else if(tireCount < wheelCount || tireCount > 20)
            {
                editor.Text = "";
                editor.Placeholder = "Incorerct tire count";
                lb.Text = "";
                return;
            }

            if(wheelCount != wordsCount - 2)
            {
                editor.Text = "";
                editor.Placeholder = "Incorerct wheel count.";
                lb.Text = "";
                return;
            }

            int[] configurationOfWheels = new int[wheelCount];

            for (int i = 2; i < numbers.Length; i++)
            {
                configurationOfWheels[i - 2] = Convert.ToInt32(numbers[i]);
            }
            int maxInConfiguration = configurationOfWheels.Max();

            double sum = 0;
            foreach (int x in configurationOfWheels)
            {
                sum += maxInConfiguration / (double)x;
            }

            double result = tireCount * maxInConfiguration;

            double maxKilometers = result / sum;

            lb.Text = $"Max Kilometers = {string.Format("{0:0.000}", maxKilometers)}";
        }



        private void EditorValuesTextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}