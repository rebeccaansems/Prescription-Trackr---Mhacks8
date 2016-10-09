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
    class StoredInfo
    {
        public static List<MedicationItem> allPrescriptions = new List<MedicationItem>();

        public static void saveData()
        {
            var prefs = Application.Context.GetSharedPreferences("Mhacks", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt("NumberOfPrescriptions", allPrescriptions.Count);
            prefEditor.Commit();

            for (int i = 0; i < allPrescriptions.Count; i++)
            {
                string data = allPrescriptions[i].medName + "|";
                data += allPrescriptions[i].medAmount + "|";
                data += allPrescriptions[i].whatTime + "|";
                data += allPrescriptions[i].doctorsName + "|";
                data += allPrescriptions[i].prescripCode + "|";
                data += allPrescriptions[i].medPurpose + "|";
                data += allPrescriptions[i].howOften + "|";
                data += allPrescriptions[i].numDoses;

                prefEditor.PutString("Prescription" + i, data);
                prefEditor.Commit();
            }
        }

        public static void retrieveData()
        {
            allPrescriptions = new List<MedicationItem>();

            var prefs = Application.Context.GetSharedPreferences("Mhacks", FileCreationMode.Private);
            int numberPrescriptions = prefs.GetInt("NumberOfPrescriptions", 0);
            for (int i = 0; i < numberPrescriptions; i++)
            {
                string prescripData = prefs.GetString("Prescription" + i, null);
                if (prescripData != null)
                {
                    MedicationItem mItem = new MedicationItem();
                    string[] prescripDataPoints = prescripData.Split('|');
                    mItem.medName = prescripDataPoints[0];
                    mItem.medAmount = prescripDataPoints[1];
                    mItem.whatTime = prescripDataPoints[2];
                    mItem.doctorsName = prescripDataPoints[3];
                    mItem.prescripCode = prescripDataPoints[4];
                    mItem.medPurpose = prescripDataPoints[5];
                    mItem.howOften = int.Parse(prescripDataPoints[6]);
                    mItem.numDoses = int.Parse(prescripDataPoints[7]);

                    allPrescriptions.Add(mItem);
                }
            }
        }
    }
}
