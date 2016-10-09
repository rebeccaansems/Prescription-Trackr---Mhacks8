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
    class ViewPrescriptions2 : Activity
    {
        public static int prescripNum;

        TextView medName, medAmount, numDoses, whatTime, doctorsName, medPurpose;
        Spinner howOftenSpinner;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ViewPrescrip);

            //Add values to how often spinner
            howOftenSpinner = FindViewById<Spinner>(Resource.Id.howOften);
            List<string> howOftenAmounts = new List<string>();
            howOftenAmounts.Add("Monthly");
            howOftenAmounts.Add("Weekly");
            howOftenAmounts.Add("Daily");
            howOftenAmounts.Add("Every 12 Hours");
            howOftenAmounts.Add("Every 6 Hours");
            howOftenAmounts.Add("Hourly");
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, howOftenAmounts);
            howOftenSpinner.Adapter = adapter;

            Button backButton = FindViewById<Button>(Resource.Id.back);

            medName = FindViewById<TextView>(Resource.Id.medName);
            medAmount = FindViewById<TextView>(Resource.Id.medAmount);
            numDoses = FindViewById<TextView>(Resource.Id.numberDoses);
            whatTime = FindViewById<TextView>(Resource.Id.whatTime);
            doctorsName = FindViewById<TextView>(Resource.Id.doctorsName);
            medPurpose = FindViewById<TextView>(Resource.Id.medPurpose);

            medName.Text = StoredInfo.allPrescriptions[prescripNum].medName;
            medAmount.Text = StoredInfo.allPrescriptions[prescripNum].medAmount;
            numDoses.Text = StoredInfo.allPrescriptions[prescripNum].numDoses.ToString();
            howOftenSpinner.SetSelection(StoredInfo.allPrescriptions[prescripNum].howOften);
            whatTime.Text = StoredInfo.allPrescriptions[prescripNum].whatTime;
            doctorsName.Text = StoredInfo.allPrescriptions[prescripNum].doctorsName;
            medPurpose.Text = StoredInfo.allPrescriptions[prescripNum].medPurpose;

            howOftenSpinner.Enabled = false;

            backButton.Click += BackButton_Click;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}