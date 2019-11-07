using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace WS6_Cars_Object_Persistance
{
    static class CarQueries
    {
        // DB Connection details
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "postgres";
        private const string DB = "cars";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" +  DB;
        static private NpgsqlConnection connection;
        static private NpgsqlCommand selectAllCars = null;
        static private NpgsqlCommand insertCar = null;

        static CarQueries()
        {
            try
            {
               connection = new NpgsqlConnection(CONNECTION_STRING);
               connection.Open(); // Here we open connection
            } catch (NpgsqlException ex)
            {
                // An exception !! Handle me correctly
                throw new NpgsqlException($"Error in database connection ({ ex.Message }).");
            }
        
        }

        static public List<Vehicle> getAllCars()
        {
            List<Vehicle> list = new List<Vehicle>();
            using (selectAllCars = new NpgsqlCommand("SELECT * FROM cars", connection))
            {
                selectAllCars.Prepare(); // Prepare the select query that gets all cars from the database

                using (NpgsqlDataReader results = selectAllCars.ExecuteReader())
                {
                    bool success;

                    while (results.Read())
                    {
                        list.Add(new Car(results.GetString(0), results.GetString(1), results.GetString(2), results.GetInt32(3), out success));
                    }
                }
            }
            
            return list;
        }

        static public void AddCar(Vehicle car)
        {
            using (insertCar = new NpgsqlCommand("INSERT INTO Cars(platenr, colour, model, year) " +
            "VALUES (@platenr, @colour, @model, @year)", connection))
            {
                insertCar.Parameters.AddWithValue("platenr", car.GetPlateNumber());
                insertCar.Parameters.AddWithValue("colour", car.GetColour());
                insertCar.Parameters.AddWithValue("model", car.GetModel());
                insertCar.Parameters.AddWithValue("year", car.GetYear());
                insertCar.ExecuteNonQuery();
            }
        }
    }
}
