using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using VaccineApp.Data;
using Android.Content;

namespace VaccineApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button btnLogin, btnRegister;
        EditText etUser, etPassword;
        DataOperations operation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            operation = new DataOperations();
            etUser = FindViewById<EditText>(Resource.Id.etUserName);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterUserActivity));
            Finish();
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            string username = etUser.Text.Trim();
            string password = etPassword.Text;
            string message = "";
            if (username.Length == 0 || password.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else
            {
                if(username.Equals("admin") && password.Equals("admin@1234"))
                {
                    message = "Welcome Admin!!!";
                    Intent intent = new Intent(this, typeof(AdminHomeActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else if (operation.ValidUser(username, password))
                {
                    message = "Welcome " + username;
                    Intent intent = new Intent(this, typeof(UserHomeActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    message = "Invalid User Name and Password";
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}