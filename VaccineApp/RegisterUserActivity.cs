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
    [Activity(Label = "Register User")]
    public class RegisterUserActivity : AppCompatActivity
    {
        Button btncreate;
        EditText etuser, etpass, etconfirm,etaddress,etname;
        DataOperations operations;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_register);
            operations = new DataOperations();

            etuser = FindViewById<EditText>(Resource.Id.etUserName);
            etpass = FindViewById<EditText>(Resource.Id.etPassword);
            etconfirm = FindViewById<EditText>(Resource.Id.etConfirm);
            etname = FindViewById<EditText>(Resource.Id.etName);
            etaddress = FindViewById<EditText>(Resource.Id.etAddress);

            btncreate = FindViewById<Button>(Resource.Id.btnCreate);
            btncreate.Click += Btncreate_Click;
        }

        private void Btncreate_Click(object sender, EventArgs e)
        {
            string username = etuser.Text.Trim();
            string pass = etpass.Text;
            string cpass = etconfirm.Text;
            string name = etname.Text;
            string address = etaddress.Text;
            string message = "";
            if (username.Length == 0 || pass.Length == 0 || cpass.Length == 0 || name.Length == 0 || address.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else if (pass.Equals(cpass))
            {
                User user = new User();
                user.UserName = username;
                user.Password = pass;
                user.Address = address;
                user.Name = name;
                if (operations.CreateNewUser(user))
                {
                    message = "New User is Created";
                    Intent intent = new Intent(this, typeof(UserHomeActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    message = "There is Some Error in Creating in User";
                    message = operations.ErrorMessage;
                }
            }
            else
            {
                message = "Confirm Password must be match with Password";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}