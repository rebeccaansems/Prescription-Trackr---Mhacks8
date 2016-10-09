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
    class EditPrescriptions : Activity
    {
        Button[] buttons;
        Button back;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EditPerscrip);

            back = FindViewById<Button>(Resource.Id.back);

            back.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            Button perscrip0 = FindViewById<Button>(Resource.Id.perscrip0);
            Button perscrip1 = FindViewById<Button>(Resource.Id.perscrip1);
            Button perscrip2 = FindViewById<Button>(Resource.Id.perscrip2);
            Button perscrip3 = FindViewById<Button>(Resource.Id.perscrip3);
            Button perscrip4 = FindViewById<Button>(Resource.Id.perscrip4);
            Button perscrip5 = FindViewById<Button>(Resource.Id.perscrip5);
            Button perscrip6 = FindViewById<Button>(Resource.Id.perscrip6);
            Button perscrip7 = FindViewById<Button>(Resource.Id.perscrip7);
            Button perscrip8 = FindViewById<Button>(Resource.Id.perscrip8);
            Button perscrip9 = FindViewById<Button>(Resource.Id.perscrip9);

            buttons = new Button[10] {perscrip0, perscrip1, perscrip2, perscrip3, perscrip4, perscrip5, perscrip6, perscrip7, perscrip8, perscrip9 };
            
            for (int i=0; i<10; i++)
            {
                if(i < StoredInfo.allPrescriptions.Count)
                {
                    buttons[i].Text = StoredInfo.allPrescriptions[i].medName + ": " + StoredInfo.allPrescriptions[i].doctorsName;
                }
                else
                {
                    buttons[i].Visibility = ViewStates.Gone;
                }

            }
        }

    }
}