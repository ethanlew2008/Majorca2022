using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Majorca2022
{
    public partial class MainPage : ContentPage
    {
        string input = "";

        int buttonpress = 0;
        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;

        bool before = false;

        public MainPage()
        {
            InitializeComponent();
            if(month == 8 && day <20 && year == 2022 || month < 8 && year == 2022) { DayCount(); before = false; FlyDayButton.Text = "Days"; }
            BackgroundColor = Color.White;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            input += "1"; Box.Text = input;
            buttonpress++;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            input += "2"; Box.Text = input;
            buttonpress++;
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            input += "3"; Box.Text = input;
            buttonpress++;
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            input += "4"; Box.Text = input;
            buttonpress++;
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            input += "5"; Box.Text = input;
            buttonpress++;
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            input += "6"; Box.Text = input;
            buttonpress++;
        }

        private void Button7_Clicked(object sender, EventArgs e)
        {
            input += "7"; Box.Text = input;
            buttonpress++;
        }

        private void Button8_Clicked(object sender, EventArgs e)
        {
            input += "8"; Box.Text = input;
            buttonpress++;
        }

        private void Button9_Clicked(object sender, EventArgs e)
        {
            input += "9"; Box.Text = input;
            buttonpress++;
        }

        private void Dotbutton_Clicked(object sender, EventArgs e)
        {
            input += "."; Box.Text = input;
            buttonpress++;
        }

        private void Button0_Clicked(object sender, EventArgs e)
        {
            input += "0"; Box.Text = input;
            buttonpress++;
        }

        private void ButtonDel_Clicked(object sender, EventArgs e)
        {
            string ostr = "";
            try { ostr = input.Remove(input.Length - 1, 1); } catch (Exception) { return; }
            input = ostr; Box.Text = input;
            buttonpress++;
        }

        private void FlyDayButton_Clicked(object sender, EventArgs e)
        {
            if (before) { DayCount(); }
        }

        private void SOSButton_Clicked(object sender, EventArgs e)
        {

        }

        private void GBPButton_Clicked(object sender, EventArgs e)
        {

        }

        private void TimeButton_Clicked(object sender, EventArgs e)
        {

        }

        private void FlipButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            Random random = new Random(); int rng = random.Next(1, 3);
            if(rng == 2) { Box.Text = "Heads"; } else { Box.Text = "Tails"; }
        }

        private void StatsButton_Clicked(object sender, EventArgs e)
        {
            input = ""; Box.Text = "";
            Box.Text += buttonpress; Box.Text += " Button Presses";
        }

        private void DayCount()
        {
            input = "";
            DateTime futurDate = Convert.ToDateTime("07/08/2022"); DateTime TodayDate = DateTime.Now;
            Box.Text += Convert.ToInt32((futurDate - TodayDate).TotalDays); Box.Text += " Days";
        }

        private void TimeCount()
        {

        }
    }
}
