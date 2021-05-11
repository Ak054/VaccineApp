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
using VaccineApp.Models;

namespace VaccineApp.Adapter
{
    public class BookingSpinnerAdapter : BaseAdapter<Booking>
    {
        private readonly Activity context;
        private readonly List<Booking> bookings;

        public BookingSpinnerAdapter(Activity context, List<Booking> bookings)
        {
            this.bookings = bookings;
            this.context = context;
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
                row = LayoutInflater.From(context).Inflate(Resource.Layout.spinner_row_booking, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.txtName);

            TimeSpan time = TimeSpan.FromMilliseconds(bookings[position].BookingDate);
            DateTime date = new DateTime(1970, 1, 1) + time;
            txt1.Text = date.ToLongDateString();


            return row;
        }
    }
}