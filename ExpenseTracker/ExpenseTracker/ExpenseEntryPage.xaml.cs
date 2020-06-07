using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseEntryPage : ContentPage
    {
        public string Budget { get; set; }

        public ExpenseEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BudgetLabel.Text = $"BudgetExpense is {Budget}";




            var expenseDataFiles = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "*.expenses.txt");

            var expenses = new List<Expenses>();


            foreach (var dataFile in expenseDataFiles)
            {
                //fruits \n 10 \n food
                /*File.Delete(dataFile);
                continue;*/
                var data = File.ReadAllText(dataFile);
                string[] dataSplit = data.Split('\n');


                var expense = new Expenses
                {
                    Name = dataSplit[0],
                    Amount = Convert.ToDecimal(dataSplit[1]),
                    Category = dataSplit[2],
                    DateOfPurchase = Convert.ToDateTime(dataSplit[3])
                    
                };

                expenses.Add(expense);
            }

            listview.ItemsSource = expenses;
        }


        private async void OnAddExpensesClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseModel
            {
                BindingContext = new Expenses()
            });
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {

        }
    }
}

