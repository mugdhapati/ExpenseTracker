using System;
using System.Collections.Generic;
using System.Globalization;
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
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseEntryPage());
        }

    }
}