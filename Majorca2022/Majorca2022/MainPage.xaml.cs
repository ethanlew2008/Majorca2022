using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Recognition;
using Xamarin.Forms;
using Xamarin.Essentials;
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
        Stopwatch sleep = new Stopwatch(); double sleephours = 0;

        //Thread thread = new Thread(new Thread());

        bool before = false;
        bool devmode = false;
        bool pregunta = false;
        bool majorca = false;
        bool alicante = false;
        public MainPage()
        {
            InitializeComponent();
            if (month == 8 && day < 07 && year == 2022 || month < 8 && year == 2022) { before = true; FlyDayButton.Text = "Days"; }
            else { FlyDayButton.Text = "Flight"; }
            
            if (hour > 6 && hour < 20) { BackgroundImageSource = "SerenAppDay.jpg"; Box.TextColor = Color.Black; }
            else { BackgroundImageSource = "SerenAppNight.png"; Box.TextColor = Color.White; }

            Box.Text = "1.Majorca\n2.Alicante";
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            input += "1"; Box.Text = input;
            if(pregunta == false) { majorca = true; TimeCount(); pregunta = true; }
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            input += "2"; Box.Text = input;
            if(pregunta == false) { alicante = true; pregunta = true; TimeCount(); }
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
            try { PhoneDialer.Open("112"); }
            catch (Exception) { Box.Text = "Any Emergency: 112"; }
        }

        public void GBPButton_Clicked(object sender, EventArgs e)
        {            
            double maj = 0;

            try { Convert.ToInt32(input); } catch (Exception) { Box.Text = "Number Too Big"; input = ""; return; }

            maj = Convert.ToDouble(input) / 1.20;
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
            if(rng == 2) { Box.Text = "Heads"; } else { Box.Text = "Tails"; }
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
                    percentage = flightmins - 140; percentage /= 140; percentage *= 100; percentage = 100 + percentage;
                    percentage = Convert.ToInt32(percentage);
                    TimeSpan spWorkMin = TimeSpan.FromMinutes(flightmins);
                    string workHours = spWorkMin.ToString(@"hh\:mm");                     
                    Box.Text = workHours;
                    Box.Text += "\n"; Box.Text += percentage; Box.Text += "% Left";
                }
            }
            else
            {
                input = ""; Box.Text = "";               
                DateTime futurDate = Convert.ToDateTime("07/08/2022"); DateTime TodayDate = DateTime.Now;
                if (Convert.ToInt32((futurDate - TodayDate).TotalDays) < 3) { int temp = Convert.ToInt32((futurDate - TodayDate).TotalDays); temp = Convert.ToInt32(temp * 24); Box.Text += temp + " Hours"; return; } 
                Box.Text += Convert.ToInt32((futurDate - TodayDate).TotalDays); Box.Text += " Days";
            }
            
        }

        public  void TimeCount()
        {   
            Box.Text = "";input = "";
            int mallorcahour = 0;
            int londonhour = 0;
            string minstring = Convert.ToString(DateTime.Now.Minute);

            if (before) { londonhour = DateTime.Now.Hour; mallorcahour = londonhour + 1; }
            else { mallorcahour = DateTime.Now.Hour; londonhour = mallorcahour - 1; }

                if (londonhour >= 24) { londonhour -= 24; }
                if (mallorcahour >= 24) { mallorcahour -= 24; }

                if(minstring.Length == 1 && Convert.ToInt32(minstring) >= 10) { minstring += "0"; } 
                if(minstring.Length == 1 && Convert.ToInt32(minstring) < 10) { minstring = ""; minstring += "0"; minstring += DateTime.Now.Minute; }

                if (londonhour < 0) { londonhour *= -1; }
                if (mallorcahour < 0) { mallorcahour *= -1; }

                
            Box.Text += "London:" + londonhour + ":"; if(minstring == "") { Box.Text += minstring; } else { Box.Text += minstring; }
            if (alicante) { Box.Text += "\nAlicante:"; } else { Box.Text += "\nMajorca:"; }
            Box.Text +=  mallorcahour + ":"; if (minstring == "") { Box.Text += minstring; } else { Box.Text += minstring; } 
        }

        private void SleepButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            if (!sleep.IsRunning) { sleep.Start(); Box.Text = "Goodnight"; SleepButton.Text = "End"; BackgroundImageSource = "SerenAppNight.png"; Box.TextColor = Color.White; }
            else
            {
                sleep.Stop();
                Box.Text = "Good Morning\n";
                sleephours = sleep.ElapsedMilliseconds / 1000; sleephours /= 60;
                
                TimeSpan spWorkMin = TimeSpan.FromMinutes(sleephours);
                string workHours = spWorkMin.ToString(@"hh\:mm");
                Box.Text += "You Slept " + workHours;
                Box.Text += "\nYou took " + Convert.ToInt32(sleephours * 16) + " Breaths";
                SleepButton.Text = "Sleep";

                int hour = DateTime.Now.Hour;
                if (hour > 6 && hour < 20) { BackgroundImageSource = "SerenAppDay.jpg"; Box.TextColor = Color.Black; }
                else { BackgroundImageSource = "SerenAppNight.png"; Box.TextColor = Color.White; }
            }
        }

       

        
    }
}
