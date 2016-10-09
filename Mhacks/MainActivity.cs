using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Mhacks
{
    [Activity(Label = "Mhacks", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            StoredInfo.retrieveData();

            // Get our button from the layout resource,
            // and attach an event to it
            Button b_AddPrescrip = FindViewById<Button>(Resource.Id.addPrescrip);
            Button b_EditPrescrip = FindViewById<Button>(Resource.Id.editPrescrip);
            Button b_ViewPrescrip = FindViewById<Button>(Resource.Id.viewPrescrip);
            Button b_ClearData = FindViewById<Button>(Resource.Id.clearData);

            b_AddPrescrip.Click += delegate
            {
                StartActivity(typeof(AddPrescription));
            };

            b_EditPrescrip.Click += delegate
            {
                StartActivity(typeof(EditPrescriptions));
            };

            b_ViewPrescrip.Click += delegate
            {
                StartActivity(typeof(ViewPrescriptions));
            };

            b_ClearData.Click += delegate
            {
                StoredInfo.allPrescriptions = new System.Collections.Generic.List<MedicationItem>();
                StoredInfo.saveData();
            };
        }
    }
}

