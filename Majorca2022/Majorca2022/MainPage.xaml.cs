using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Recognition;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;
using System.IO;

namespace Majorca2022
{
    

    public partial class MainPage : ContentPage
    {
        string input = "";

        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        int hour = DateTime.Now.Hour;
        int flightmins = 0;

        Stopwatch flight = new Stopwatch(); double percentage = 0;

        bool before = false;
        bool devmode = false;
        public MainPage()
        {
            InitializeComponent();
            if (month == 8 && day < 07 && year == 2022 || month < 8 && year == 2022) { before = true; DayCount(); FlyDayButton.Text = "Days"; }
            else { TimeCount(); FlyDayButton.Text = "Flight"; }
            
            if (hour > 7 && hour < 19) { BackgroundImageSource = "SerenAppDay.jpg"; Box.TextColor = Color.Black; }
            else { BackgroundImageSource = "SerenAppNight.png"; Box.TextColor = Color.White; }           
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            input += "1"; Box.Text = input;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            input += "2"; Box.Text = input;
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            input += "3"; Box.Text = input;
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            input += "4"; Box.Text = input;
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            input += "5"; Box.Text = input;
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            input += "6"; Box.Text = input;
        }

        private void Button7_Clicked(object sender, EventArgs e)
        {
            input += "7"; Box.Text = input;
        }

        private void Button8_Clicked(object sender, EventArgs e)
        {
            input += "8"; Box.Text = input;
        }

        private void Button9_Clicked(object sender, EventArgs e)
        {
            input += "9"; Box.Text = input;
        }

        private void Dotbutton_Clicked(object sender, EventArgs e)
        {
            input += "."; Box.Text = input;
        }

        private void Button0_Clicked(object sender, EventArgs e)
        {
            input += "0"; Box.Text = input;
        }

        private void ButtonDel_Clicked(object sender, EventArgs e)
        {
            string ostr = "";
            try { ostr = input.Remove(input.Length - 1, 1); } catch (Exception) { return; }
            input = ostr; Box.Text = input;
        }

        private void FlyDayButton_Clicked(object sender, EventArgs e)
        {
            DayCount();
        }

        private void SOSButton_Clicked(object sender, EventArgs e)
        {
            input = ""; 
            Box.Text = "Any Emergency 112";
        }

        private void GBPButton_Clicked(object sender, EventArgs e)
        {
            
            double maj = 0;

            try { Convert.ToInt32(input); }
            catch (Exception) { Box.Text = "Number Too Big"; input = ""; return; }
           
            maj = Convert.ToDouble(input) / 1.16;
            string cultures = maj.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-GB"));
            Box.Text = "That's About " + cultures;
            input = "";
        }

        private void TimeButton_Clicked(object sender, EventArgs e)
        {
            TimeCount();
        }

        private void FlipButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            Random random = new Random(); int rng = random.Next(1, 3);
            if(rng == 2) { Box.Text = "Heads"; }
            else { Box.Text = "Tails"; }
        }

        private void DayCount()
        {
            input = "";

            if(Box.Text == "1622") { devmode = true; FlyDayButton.Text = "Flight"; }

            if (!before || devmode == true)
            {
                if (!flight.IsRunning) { flight.Restart(); Box.Text = "Flight Started"; }
                else
                {
                    if(flight.ElapsedMilliseconds <= 0) { Box.Text = "Welcome"; input = ""; flight.Stop(); return; }
                    flightmins = 8400000 - Convert.ToInt32(flight.ElapsedMilliseconds);
                    flightmins /= 1000; flightmins /= 60;
                    TimeSpan spWorkMin = TimeSpan.FromMinutes(flightmins);
                    string workHours = spWorkMin.ToString(@"hh\:mm");
                    percentage = flightmins / 140; percentage *= 100;
                    percentage = Convert.ToInt32(percentage); percentage = 100 - percentage; 
                    Box.Text = workHours;
                    Box.Text += "\n"; Box.Text += percentage; Box.Text += "% Left";
                }
            }
            else
            {
                input = ""; Box.Text = "";
                DateTime futurDate = Convert.ToDateTime("07/08/2022"); DateTime TodayDate = DateTime.Now;
                Box.Text += Convert.ToInt32((futurDate - TodayDate).TotalDays); Box.Text += " Days";
            }
            
        }

        public  void TimeCount()
        {   
                Box.Text = "";input = "";               
                int mallorcahour;
                int londonhour;

                if (before) { londonhour = DateTime.Now.Hour; mallorcahour = londonhour + 1; }
                else { mallorcahour = DateTime.Now.Hour; londonhour = mallorcahour - 1; }

                if (londonhour > 24) { londonhour -= 24; }
                if (mallorcahour > 24) { mallorcahour -= 24; }

                Box.Text += "London:" + londonhour + ":" + DateTime.Now.Minute;
                Box.Text += "\nMajorca:" + mallorcahour + ":" + DateTime.Now.Minute;                    
        }
        
       
    }
}
