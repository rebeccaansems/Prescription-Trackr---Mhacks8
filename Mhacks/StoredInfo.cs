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
        public static List<MedicationItem> allPrescriptions;

        public StoredInfo() { allPrescriptions = new List<MedicationItem>(); }

    }
}