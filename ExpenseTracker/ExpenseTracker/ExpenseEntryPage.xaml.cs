using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
    
    public partial class ExpenseEntryPage : ContentPage
    {

        public ExpenseEntryPage()
        {
            InitializeComponent();
          
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (string.IsNullOrWhiteSpace(expense.Filename))
            {
                var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.expenses.txt");
                File.WriteAllText(filename, editor.Text);
            }
            else
            {
                //Update
                File.WriteAllText(expense.Filename, editor.Text);
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if(File.Exists(expense.Filename))
            {
                File.Delete(expense.Filename);
            }
            await Navigation.PopModalAsync();
        }
    }
}