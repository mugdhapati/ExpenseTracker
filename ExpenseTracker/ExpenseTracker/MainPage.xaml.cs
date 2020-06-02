using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseTracker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Expense.txt");
        public MainPage()
        {

            
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            

            File.WriteAllText(_fileName, Budget.Text);

            await Navigation.PushModalAsync(new SecondPage
            {
                budget = Budget.Text
            });

           
                
            
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if(File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            Budget.Text = string.Empty;
        }
    }
}
