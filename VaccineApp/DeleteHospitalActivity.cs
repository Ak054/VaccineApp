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
    [Activity(Label = "Delete Hospital")]
    public class DeleteHospitalActivity : AppCompatActivity
    {
        Button btndelete, btnback;
        EditText etid;
        DataOperations operations;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_delete_hospital);

            operations = new DataOperations();

            etid = FindViewById<EditText>(Resource.Id.etID);

            btnback = FindViewById<Button>(Resource.Id.btnBack);
            btndelete = FindViewById<Button>(Resource.Id.btnDelete);

            btnback.Click += Btnback_Click;
            btndelete.Click += Btndelete_Click;
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            string id = etid.Text.Trim();
            string message = "";
            try
            {
                Hospital hospital = operations.GetHospital(int.Parse(id));
                if (hospital != null)
                {
                    if (operations.CheckHospitalBooking(hospital.HospitalID))
                    {
                        Android.Support.V7.App.AlertDialog.Builder winBuild = new Android.Support.V7.App.AlertDialog.Builder(this);
                        winBuild.SetTitle("Message!!!");
                        winBuild.SetMessage("There are Booking associated with this Hospital. So Deletion not Possible");
                        winBuild.SetNegativeButton("Close", (c, v) =>
                        {
                            winBuild.Dispose();
                        });
                        winBuild.Show();
                    }
                    else
                    {
                        Android.Support.V7.App.AlertDialog.Builder winBuild = new Android.Support.V7.App.AlertDialog.Builder(this);
                        winBuild.SetTitle("Confirmation!!!");
                        winBuild.SetMessage("Are You Sure to Remove This Record with Text: " + hospital.HospitalName);
                        winBuild.SetPositiveButton("Delete Record", (c, v) =>
                        {
                            if (operations.DeleteHospital(hospital))
                            {
                                message = "Details of Hospital are Removed";
                            }
                            else
                            {
                                message = "There is Problem in Deletion Process";
                            }
                            Toast.MakeText(this, message, ToastLength.Long).Show();
                        });
                        winBuild.SetNegativeButton("Exit", (c, v) =>
                        {
                            winBuild.Dispose();
                        });
                        winBuild.Show();
                    }
                }
                else
                {
                    message = "There is no such Hospital Details For Given ID";
                }
            }
            catch (Exception)
            {
                message = "Invalid Form of ID Given. It must be number";
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
    }
}