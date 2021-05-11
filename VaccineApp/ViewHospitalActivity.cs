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
    [Activity(Label = "View Hospital Details")]
    public class ViewHospitalActivity : AppCompatActivity
    {
        Button btnBack;
        ListView listView;
        DataOperations operations;
        HospitalListAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_view_hospital);
            operations = new DataOperations();
           
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            listView = FindViewById<ListView>(Resource.Id.listHospital);

            btnBack.Click += BtnBack_Click; ;

            adapter = new HospitalListAdapter(this, operations.GetHospitals());
            listView.Adapter = adapter;

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}