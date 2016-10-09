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
using Android.Graphics;
using System.IO;

namespace Mhacks
{
    class MedicationItem
    {

        public string medName, medAmount, whatTime, doctorsName, medPurpose;
        public int howOften, numDoses;
        public Bitmap picMed, pickPrescip;

    }
}