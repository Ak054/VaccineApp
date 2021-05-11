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
using VaccineApp.Data;
using VaccineApp.Models;

namespace VaccineApp
{
    [Activity(Label = "Add New Hospital")]
    public class AddHospitalActivity : AppCompatActivity
    {
        Button btnsave, btnback;
        EditText etname, etaddress, etcontact;
        DataOperations operations;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_hospital);
            operations = new DataOperations();

            etname = FindViewById<EditText>(Resource.Id.etHospitalName);
            etaddress = FindViewById<EditText>(Resource.Id.etAddress);
            etcontact = FindViewById<EditText>(Resource.Id.etContact);

            btnsave = FindViewById<Button>(Resource.Id.btnSave);
            btnback = FindViewById<Button>(Resource.Id.btnBack);

            btnsave.Click += Btnsave_Click;
            btnback.Click += Btnback_Click;
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            string name = etname.Text.Trim();
            string address = etaddress.Text.Trim();
            string contact = etcontact.Text.Trim();
            string message = "";
            if(name.Length == 0 || address.Length == 0 || contact.Length == 0)
            {
                message = "Please Enter Some Value in Boxes";
            }
            else
            {
                Hospital hospital = new Hospital();
                hospital.HospitalName = name;
                hospital.Address = address;
                hospital.ContactNo = contact;
                if(operations.AddHospital(hospital))
                {
                    message = "Hospital Details are Saved!!!";
                    etname.Text = "";
                    etaddress.Text = "";
                    etcontact.Text = "";
                }
                else
                {
                    message = operations.ErrorMessage;
                }
            }
                Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}