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

namespace VaccineApp
{
    [Activity(Label = "User Home")]
    public class UserHomeActivity : AppCompatActivity
    {
        Button btnAdd, btnCancel, btnView, btnLog;
        TextView textView;
        string username;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_user_home);

            username = Intent.GetStringExtra("UserName");

            btnAdd = FindViewById<Button>(Resource.Id.btnAddBooking);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancelBooking);
            btnView = FindViewById<Button>(Resource.Id.btnViewBooking);
            btnLog = FindViewById<Button>(Resource.Id.btnLogOut);
            textView = FindViewById<TextView>(Resource.Id.textView1);

            textView.Text = "Welcome " + username + "!!!";
            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
            btnView.Click += BtnView_Click;
            btnLog.Click += BtnLog_Click;
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewBookingActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CancelBookingActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {            
            Intent intent = new Intent(this, typeof(AddBookingActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }
    }
}