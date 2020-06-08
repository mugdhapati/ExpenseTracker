
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseModel : ContentPage
    {

        public string Budget { get; set; }
        public DateTime SelectedDate { get; set; }
        public ExpenseModel()
        {
            InitializeComponent();

           pickerCategory.ItemsSource = Expenses.CATEGORIES;
        }


        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expensePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                LocalApplicationData),
                $"{Path.GetRandomFileName()}.expenses.txt");



            var expenses = new Expenses
            {

                Name = nameLabel.Text,
                Amount = Convert.ToDecimal(amountLabel.Text),
                DateOfPurchase = SelectedDate,
                Category = pickerCategory.SelectedItem.ToString()

            };


            File.WriteAllText(expensePath, expenses.toString());

            Navigation.PopModalAsync();

            /*await Navigation.PushModalAsync(new ExpenseEntryPage
            {
                
                Budget= File.ReadAllText
               ("data/user/0/com.companyname.expensetrackingapp/files/.local/share/ExpenseBudget.txt")
               
            }); */

        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void MainDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;

        }


    }
}