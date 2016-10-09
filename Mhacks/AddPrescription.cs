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
using System.IO;

namespace Mhacks
{
    [Activity(Label = "Mhacks", MainLauncher = false, Icon = "@drawable/icon")]
    class AddPrescription : Activity
    {
        EditText medName, medAmount, numDoses, whatTime, doctorsName, medPurpose;
        Spinner howOftenSpinner;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AddPrescrip);

            Button submitButton = FindViewById<Button>(Resource.Id.submit);
            Button backButton = FindViewById<Button>(Resource.Id.back);
            Button pictureMed = FindViewById<Button>(Resource.Id.pictureMed);
            Button picturePrecip = FindViewById<Button>(Resource.Id.picturePrescrip);

            medName = FindViewById<EditText>(Resource.Id.medName);
            medAmount = FindViewById<EditText>(Resource.Id.medAmount);
            numDoses = FindViewById<EditText>(Resource.Id.numberDoses);
            whatTime = FindViewById<EditText>(Resource.Id.whatTime);
            doctorsName = FindViewById<EditText>(Resource.Id.doctorsName);
            medPurpose = FindViewById<EditText>(Resource.Id.medPurpose);

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

            submitButton.Click += SubmitButton_Click;
            backButton.Click += BackButton_Click;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MedicationItem mitem = new MedicationItem();
            if (medName.Text.Equals("")) { mitem.medName = "N/A"; }
            else { mitem.medName = medName.Text; }
            if (medAmount.Text.Equals("")) { mitem.medAmount = "N/A"; }
            else { mitem.medAmount = medAmount.Text; }
            if (whatTime.Text.Equals("")) { mitem.whatTime = "N/A"; }
            else { mitem.whatTime = whatTime.Text; }
            mitem.howOften = (int)howOftenSpinner.SelectedItemId;
            if (numDoses.Text.Equals("")) { mitem.numDoses = 0; }
            else { mitem.numDoses = int.Parse(numDoses.Text); }
            if (doctorsName.Text.Equals("")) { mitem.doctorsName = "N/A"; }
            else { mitem.doctorsName = doctorsName.Text; }
            if (medPurpose.Text.Equals("")) { mitem.medPurpose = "N/A"; }
            else { mitem.medPurpose = medPurpose.Text; }

            StoredInfo.allPrescriptions.Add(mitem);
            StartActivity(typeof(MainActivity));
        }
        
        private void BackButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}