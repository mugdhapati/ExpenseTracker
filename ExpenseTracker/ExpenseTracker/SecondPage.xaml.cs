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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage(String parameter)
        {
            InitializeComponent();

            MainLabel.Text = parameter;
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {

        }

    }
}