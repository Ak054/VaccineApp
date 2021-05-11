using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaccineApp.Data;
using VaccineApp.Models;

namespace VaccineApp.Adapter
{
    public class BookingListAdapter : BaseAdapter<Booking>
    {
        private readonly Activity context;
        private readonly List<Booking> bookings;
        private DataOperations operations;

        public BookingListAdapter(Activity context, List<Booking> bookings)
        {
            this.bookings = bookings;
            this.context = context;
            this.operations = new DataOperations();
        }

        public override int Count
        {
            get { return bookings.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Booking this[int position]
        {
            get { return bookings[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_row_booking, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.txtName);
            TextView txt2 = row.FindViewById<TextView>(Resource.Id.txtAddress);
            TextView txt3 = row.FindViewById<TextView>(Resource.Id.txtContact);
            TextView txt4 = row.FindViewById<TextView>(Resource.Id.txtBookingDate);

            Hospital hospital = operations.GetHospital(bookings[position].HospitalID);
            txt1.Text = hospital.HospitalName;
            txt2.Text = hospital.Address;
            txt3.Text = hospital.ContactNo;
            TimeSpan time = TimeSpan.FromMilliseconds(bookings[position].BookingDate);
            DateTime date = new DateTime(1970,1,1) + time;
            txt4.Text = "Booking Date: " + date.ToLongDateString();


            return row;
        }
    }
}