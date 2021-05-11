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
    [Activity(Label = "Edit Hospital Details")]
    public class EditHospitalActivity : AppCompatActivity
    {
        Button btnsave, btnback, btnfetch;
        EditText etname, etaddress, etcontact,etid;
        DataOperations operations;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_edit_hospital);

            operations = new DataOperations();

            etname = FindViewById<EditText>(Resource.Id.etHospitalName);
            etaddress = FindViewById<EditText>(Resource.Id.etAddress);
            etcontact = FindViewById<EditText>(Resource.Id.etContact);
            etid = FindViewById<EditText>(Resource.Id.etID);

            btnsave = FindViewById<Button>(Resource.Id.btnSave);
            btnback = FindViewById<Button>(Resource.Id.btnBack);
            btnfetch = FindViewById<Button>(Resource.Id.btnFetch);

            btnsave.Click += Btnsave_Click;
            btnback.Click += Btnback_Click;
            btnfetch.Click += Btnfetch_Click;
        }

        private void Btnfetch_Click(object sender, EventArgs e)
        {
            string id = etid.Text.Trim();
            string message;
            try
            {
                Hospital hospital = operations.GetHospital(int.Parse(id));
                if (hospital != null)
                {
                    message = "Hospital Record Fetched";
                    etname.Text = hospital.HospitalName;
                    etaddress.Text = hospital.Address;
                    etcontact.Text = hospital.ContactNo;
                }
                else
                {
                    message = "There is no such Hospital Details For Given ID";
                }
            }
            catch (Exception)
            {
                message = "Invalid Form of ID Given";
            }
            if (message.Length != 0)
            {
                Toast.MakeText(this, message, ToastLength.Long).Show();
            }
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            string id = etid.Text.Trim();
            string name = etname.Text.Trim();
            string address = etaddress.Text.Trim();
            string contact = etcontact.Text.Trim();
            string message;
            if (id.Length == 0 || name.Length == 0 || address.Length == 0 || contact.Length == 0)
            {
                message = "Please Enter Some Value in Boxes";
            }
            else
            {
                Hospital hospital = new Hospital
                {
                    HospitalID = int.Parse(id),
                    HospitalName = name,
                    Address = address,
                    ContactNo = contact
                };
                if (operations.UpdateHospital(hospital))
                {
                    message = "Hospital Details are Saved!!!";
                    etid.Text = "";
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