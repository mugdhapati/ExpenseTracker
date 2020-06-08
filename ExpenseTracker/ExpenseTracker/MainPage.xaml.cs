﻿using ExpenseTracker.Models;
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



        public MainPage()
        {
            InitializeComponent();


        }


        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expenseBudgetPath = Path.Combine
                (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               "ExpenseBudget.txt");
            File.WriteAllText(expenseBudgetPath, budget.Text);

            await Navigation.PushModalAsync(new ExpenseEntryPage
            {
                Budget = budget.Text
            });
        }


        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
           
        }
    }
}