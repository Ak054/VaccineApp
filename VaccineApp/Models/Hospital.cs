using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VaccineApp.Models
{
    public class Hospital
    {
        [PrimaryKey, AutoIncrement]
        public int HospitalID { get; set; }
        
        public string HospitalName { get; set; }

        public string Address { get; set; }

        public string ContactNo { get; set; }
    }
}