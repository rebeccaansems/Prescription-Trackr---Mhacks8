using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mhacks
{
    [Activity(Label = "Mhacks", MainLauncher = false, Icon = "@drawable/icon")]
    class AddPrescription : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AddPrescrip);

            //Add values to how often spinner
            Spinner howOftenSpinner = FindViewById<Spinner>(Resource.Id.howOften);
            List<string> howOftenAmounts = new List<string>();
            howOftenAmounts.Add("Monthly");
            howOftenAmounts.Add("Weekly");
            howOftenAmounts.Add("Daily");
            howOftenAmounts.Add("Every 12 Hours");
            howOftenAmounts.Add("Every 6 Hours");
            howOftenAmounts.Add("Hourly");
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, howOftenAmounts);
            howOftenSpinner.Adapter = adapter;

        }
    }
}