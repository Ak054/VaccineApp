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
    [Activity(Label = "AdminHomeActivity")]
    public class AdminHomeActivity : AppCompatActivity
    {
        Button btnAdd, btnEdit, btnDelete, btnView, btnLog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_admin_home);
            btnAdd = FindViewById<Button>(Resource.Id.btnAddHospital);
            btnEdit = FindViewById<Button>(Resource.Id.btnEditHospital);
            btnDelete = FindViewById<Button>(Resource.Id.btnDeleteHospital);
            btnView = FindViewById<Button>(Resource.Id.btnViewHospital);
            btnLog = FindViewById<Button>(Resource.Id.btnLogOut);

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
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
            StartActivity(typeof(ViewHospitalActivity));
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DeleteHospitalActivity));
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(EditHospitalActivity));
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AddHospitalActivity));
        }
    }
}