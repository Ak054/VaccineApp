using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaccineApp.Adapter;
using VaccineApp.Data;
using VaccineApp.Models;

namespace VaccineApp
{
    [Activity(Label = "Cancel Vaccine Booking")]
    public class CancelBookingActivity : AppCompatActivity
    {
        Button btnDelete, btnBack;
        private Spinner spinner;
        DataOperations operations;
        BookingSpinnerAdapter adapter;
        List<Booking> bookings;

        string username;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_cancel_booking);
            operations = new DataOperations();

            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            spinner = FindViewById<Spinner>(Resource.Id.spinnerBooking);

            username = Intent.GetStringExtra("UserName");

            btnDelete.Click += BtnDelete_Click;
            btnBack.Click += BtnBack_Click;

            bookings = operations.GetUserBookings(username);
            adapter = new BookingSpinnerAdapter(this, bookings);
            spinner.Adapter = adapter;

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (bookings!= null && bookings.Count() > 0)
            {
                Booking booking = bookings[spinner.SelectedItemPosition];
                if(operations.CancelBooking(booking))
                {
                    message = "Booking is Cancelled";
                    Finish();
                }
                else
                {
                    message = "Booking is not Cancelled";
                }
            }
            else
            {
                message = "There is No Booking For Cancel";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}