using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Fleet_Manager
{
    public class Vehicle
    {
        //Private fields
        private string _make;
        private string _model;
        private int _year;
        private double _mileage;
        private double _LastServiceMileage;

        //Public properties
        public string Make
        {
            get => _make; //accessor method to get the value of _make
            set => _make = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Make cannot be empty.")
                : value.Trim();
        }
        public string Model
        {             
            get => _model;
            set => _model = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Model cannot be empty.")
                : value.Trim();
        }

        public int Year
        {
            get => _year;
            set => _year = (value < 1884 || value > DateTime.Now.Year + 1)
                ? throw new ArgumentOutOfRangeException(nameof(value), "Year must be between 1884 and next year.")
                : value;
        }

        public double Mileage
        {
            get => _mileage;
            set => _mileage = (value >= 0)
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "Mileage cannot be negative.");
        }

        public double LastServiceMileage
        {
            get => _LastServiceMileage;
            set => _LastServiceMileage = (value >= 0 && value <= Mileage) //Ensures that last service mileage is non-negative and it is not greater than current mileage
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value), "Last service mileage must be between 0 and current mileage.");
        }

        //Constructors
        //Default constructor
        public Vehicle(string make, string model, int year, double mileage)
        {
            Make = make;
            Model = model;
            Year = year;
            Mileage = mileage;
            LastServiceMileage = mileage; //Initial services at the current mileage
        }

        //Methods:
        //Add Mileage
        public void AddMileage(double miles)
        {
            if (miles < 0)
                throw new ArgumentOutOfRangeException(nameof(miles), "Miles Must be positive.");
            Mileage += miles;
        }

        //Boolean for needs service
        public bool NeedsService() => (Mileage - LastServiceMileage) >= 10000; //Assuming service is required every 10000 miles

        //Void for Perform Service
        public void PerfomService() => LastServiceMileage = Mileage; //Updates the last service mileage to the current mileage.

        //String for Get Summary
        public string GetSummary()
        {
            string status = NeedsService() ? "Service Due" : "Good";
            return $"{Year} {Make} {Model} - Mileage: {Mileage:N0} - Status: {status}";
        }
    }
}
