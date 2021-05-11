using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VaccineApp.Models;

namespace VaccineApp.Data
{
    public class DataOperations
    {
        private readonly SQLiteConnection conn;

        public string ErrorMessage { get; set; }

        public DataOperations()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(Path.Combine(path, "vaccine.db"));
            CheckAndCreateTable();
            
        }

        public void CheckAndCreateTable()
        {
            try
            {
                conn.CreateTable<User>();
                conn.CreateTable<Hospital>();
                conn.CreateTable<Booking>();
            }
            catch (Exception)
            {
                
            }
        }

        public bool CreateNewUser(User user)
        {
            try
            {
                conn.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool ValidUser(string username, string password)
        {
            List<User> users = conn.Query<User>("Select * from User");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName.Equals(username) && users[i].Password.Equals(password))
                {
                    return true;
                }

            }
            return false;
        }

        public bool AddHospital(Hospital hospital)
        {
            try
            {
                conn.Insert(hospital);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateHospital(Hospital hospital)
        {
            try
            {
                conn.Update(hospital);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public List<Hospital> GetHospitals()
        {
            List<Hospital> hospitals = conn.Query<Hospital>("Select * from Hospital");
            return hospitals;
        }

        public Hospital GetHospital(int hospitalid)
        {
            List<Hospital> hospitals = GetHospitals();
            Hospital hospital = null;
            foreach (Hospital hosp in hospitals)
            {
                if (hosp.HospitalID == hospitalid)
                {
                    hospital = hosp;
                    break;
                }
            }
            return hospital;
        }

        public bool DeleteHospital(Hospital hospital)
        {
            try
            {
                conn.Delete(hospital);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Booking> GetBookings()
        {
            List<Booking> bookings = conn.Query<Booking>("Select * from Booking");
            return bookings;
        }

        public bool CheckHospitalBooking(int hospitalid)
        {
            List<Booking> bookings = GetBookings();
            foreach (Booking booking in bookings)
            {
                if (booking.HospitalID == hospitalid)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SaveBooking(Booking booking)
        {
            try
            {
                conn.Insert(booking);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool CancelBooking(Booking booking)
        {
            try
            {
                conn.Delete(booking);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Booking> GetUserBookings(string username)
        {
            List<Booking> userbookings = new List<Booking>();
            List<Booking> bookings = GetBookings();
            foreach(Booking booking in bookings)
            {
                if (booking.UserName.Equals(username))
                {
                    userbookings.Add(booking);
                }
            }
            return userbookings;
        }
    }
}