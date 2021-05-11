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

namespace VaccineApp
{
    [Activity(Label = "My Vaccine Booking")]
    public class ViewBookingActivity : AppCompatActivity
    {
        string username;
        DataOperations operations;
        ListView listBookings;        
        BookingListAdapter adapter;
        Button btnBack;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_view_booking);
            username = Intent.GetStringExtra("UserName");

            operations = new DataOperations();

            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            listBookings = FindViewById<ListView>(Resource.Id.listBookings);

            btnBack.Click += BtnBack_Click;

            adapter = new BookingListAdapter(this, operations.GetUserBookings(username));
            listBookings.Adapter = adapter;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}