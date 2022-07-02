using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace Majorca2022
{
    public partial class App : Application
    {
         Stopwatch stopwatch = new Stopwatch();


        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {         
            stopwatch.Start();
        }

        protected override void OnResume()
        {
            stopwatch.Reset();
        }
    }
}
