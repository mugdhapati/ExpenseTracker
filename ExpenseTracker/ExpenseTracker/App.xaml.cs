using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           

            var expenseBudgetPath = Path.Combine
                (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "ExpenseBudget.txt");

            File.Delete(expenseBudgetPath);



            if (File.Exists(expenseBudgetPath))
            {
                var budget = File.ReadAllText(expenseBudgetPath);

                MainPage = new ExpenseEntryPage
                {
                    Budget = budget
                };
            }
            else
            {
                MainPage = new MainPage();
            }

        }
    

       protected override void OnStart()
        {
       }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
