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
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int BookingID { get; set; }

        public int HospitalID { get; set; }

        public string HospitalName { get; set; }

        public string UserName { get; set; }

        public long BookingDate { get; set; }
    }
}