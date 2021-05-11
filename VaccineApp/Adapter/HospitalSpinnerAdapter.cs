using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaccineApp.Models;

namespace VaccineApp.Adapter
{
    public class HospitalSpinnerAdapter : BaseAdapter<Hospital>
    {
        private readonly Activity context;
        private readonly List<Hospital> hospitals;

        public HospitalSpinnerAdapter(Activity context, List<Hospital> hospitals)
        {
            this.hospitals = hospitals;
            this.context = context;
        }

        public override int Count
        {
            get { return hospitals.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Hospital this[int position]
        {
            get { return hospitals[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.spinner_row_hospital, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.txtName);
            txt1.Text = hospitals[position].HospitalName;

            return row;
        }
    }
}