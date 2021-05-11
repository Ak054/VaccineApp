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
    [Activity(Label = "Vaccine Booking")]
    public class AddBookingActivity : AppCompatActivity
    {
        Button btnSave, btnBack;
        DatePicker dateBooking;
        Spinner spinnerHospital;
        DataOperations operations;
        HospitalSpinnerAdapter adapter;
        List<Hospital> hospitals;
        int year, month, day;
        string username;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_booking);
            operations = new DataOperations();

            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            dateBooking = FindViewById<DatePicker>(Resource.Id.dateBooking);
            spinnerHospital = FindViewById<Spinner>(Resource.Id.spinnerHospital);
            DateTime current = DateTime.Now.AddDays(1);
            DateTime begin = new DateTime(1970, 1, 1);
            dateBooking.MinDate = (long)((current - begin).TotalMilliseconds);

            username = Intent.GetStringExtra("UserName");

            btnSave.Click += BtnSave_Click;
            btnBack.Click += BtnBack_Click;
            dateBooking.DateChanged += DateBooking_DateChanged;

            hospitals = operations.GetHospitals();
            adapter = new HospitalSpinnerAdapter(this, hospitals);
            spinnerHospital.Adapter = adapter;

        }

        private void DateBooking_DateChanged(object sender, DatePicker.DateChangedEventArgs e)
        {
            year = e.Year;
            month = e.MonthOfYear;
            day = e.DayOfMonth;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(year == 0 )
            {
                Toast.MakeText(this, "Please Choose Any Date", ToastLength.Long).Show();
            }
            else
            {
                DateTime bookingDate = new DateTime(year, month, day);
                DateTime begin = new DateTime(1970, 1, 1);
                Hospital hospital = hospitals[spinnerHospital.SelectedItemPosition];
                Booking booking = new Booking();
                booking.UserName = username;
                booking.HospitalID = hospital.HospitalID;
                booking.HospitalName = hospital.HospitalName;
                booking.BookingDate = (long)(bookingDate - begin).TotalMilliseconds;
                if(operations.SaveBooking(booking))
                {
                    Toast.MakeText(this, "Vaccine Booking is Done", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "There is an Error in Booking", ToastLength.Long).Show();
                }
            }
            
            
        }
    }
}