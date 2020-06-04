using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
   
    public partial class SecondPage : ContentPage
    {

        public SecondPage(string parameter)
        {
            InitializeComponent();

            MainLabel.Text = parameter;

            var expenses = new List<Expense>();

            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "*.expense.txt");

            foreach (var filename in files)
            {
                var expense = new Expense
                {
                    Text = File.ReadAllText(filename),
                    Filename = filename,
                    PurchaseDate = File.GetCreationTime(filename)
                };
                expenses.Add(expense);
            }
            listView.ItemsSource = expenses.OrderBy(n => n.PurchaseDate).ToList();

        }

        

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseEntryPage());
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem !=null)
            {
                await Navigation.PushModalAsync(new ExpenseEntryPage
                {
                    BindingContext = (Expense)e.SelectedItem
                });
            }
        }
    }
}