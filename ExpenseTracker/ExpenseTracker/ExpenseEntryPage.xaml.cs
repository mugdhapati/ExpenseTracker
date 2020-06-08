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
            decimal totalSum = 0;
            BudgetLabel.Text = $"BudgetExpense is {Budget}";

            var expenseDataFiles = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "*.expenses.txt").ToList();

            var expenses = new List<Expenses>();


            foreach (var dataFile in expenseDataFiles)
            {
               /*File.Delete(dataFile);
                 continue;*/

                var data = File.ReadAllText(dataFile);
                //Console.WriteLine(data);
                string[] dataSplit = data.Split('\n');


                var expense = new Expenses
                {
                    Name = dataSplit[0],
                    Amount = Convert.ToDecimal(dataSplit[1]),
                    Category = dataSplit[2],
                    DateOfPurchase = Convert.ToDateTime(dataSplit[3]),
                    CategoryIcon = Expenses.CATEGORY_URL_MAP[dataSplit[2]]
                };

                expenses.Add(expense);
                totalSum = totalSum + expense.Amount;
            }

            decimal remainingAmount = Convert.ToDecimal(Budget) - totalSum;

            RemainingAmountLabel.Text = $"Remaining Budget is {remainingAmount}";

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

