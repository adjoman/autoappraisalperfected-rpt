using testAAP.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using AutoAppraisalPerfectedReport.Models;

namespace testAAP.DB
{
    public class AppraisalsContext
    {
        public string ConnectionString { get; set; }

        public AppraisalsContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Client> GetAllClients()
        {
            List<Client> list = new List<Client>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Client()
                        {
                            customer_name = reader.GetString("customer_name"),
                            customer_scope_of_work = reader.GetString("customer_scope_of_work")
                        });
                    }
                }
            }

            return list;
        }

        public List<Photo> getPhotoByClientID(string clientID)
        {
            List<Photo> list = new List<Photo>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT vehicle_photos_photoname as photo FROM vehicle_photos where vehicle_photos_customer_id='" + clientID + "'", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Photo()
                        {
                            photo = "https://s3.amazonaws.com/aap-public/" + reader.GetString("photo")
                        });
                    }
                }
            }

            return list;
        }

        public Report getReport(string clientID)
        {
            Report list = new Report();

            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand command = new MySqlCommand("getReport", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new MySqlParameter("customer_id", clientID));
                command.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list = new Report();

                    list.basicInfo.make     = MySQLDBExtension.GetStringSafe(reader, "make");
                    list.basicInfo.year     = MySQLDBExtension.GetStringSafe(reader, "year");
                    list.basicInfo.vin      = MySQLDBExtension.GetStringSafe(reader, "vin");
                    list.basicInfo.model    = MySQLDBExtension.GetStringSafe(reader, "model");
                    list.basicInfo.color    = MySQLDBExtension.GetStringSafe(reader, "color");
                    list.basicInfo.mileage  = MySQLDBExtension.GetStringSafe(reader, "mileage");
                    list.basicInfo.location = MySQLDBExtension.GetStringSafe(reader, "location");

                    var transType = MySQLDBExtension.GetStringSafe(reader, "transmission_type");
                    if (!string.IsNullOrEmpty(transType))
                    {
                        if (transType == "0")
                        {
                            list.transmission.transmission_type = "Automatic";
                        }
                        else
                        {
                            list.transmission.transmission_type = "Manual";
                        }
                    }

                    list.signature.fairmarketvalue  = MySQLDBExtension.GetStringSafe(reader, "fairmarketvalue");
                    list.client.customer_name       = MySQLDBExtension.GetStringSafe(reader, "customer_name");
                    list.comments.testdrive_comment = MySQLDBExtension.GetStringSafe(reader, "testdrive_comment");
                    list.comments.engine_comment    = MySQLDBExtension.GetStringSafe(reader, "engine_comment");
                    list.comments.transmission_comment = MySQLDBExtension.GetStringSafe(reader, "transmission_comments");
                    list.comments.steering_comment = MySQLDBExtension.GetStringSafe(reader, "steering_comments");
                    list.comments.brake_comment = MySQLDBExtension.GetStringSafe(reader, "brakes_comments");
                    list.comments.rearend_comment = MySQLDBExtension.GetStringSafe(reader, "rearend_comments");
                }

                command.Connection.Close();
            }

            return list;
        }

        public Report getTestReport()
        {
            Report list = new Report();

            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand command = new MySqlCommand("getSampleReport", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list = new Report();

                    list.basicInfo.make             = MySQLDBExtension.GetStringSafe(reader,"make");
                    list.basicInfo.year             = MySQLDBExtension.GetStringSafe(reader,"year");
                    list.basicInfo.vin              = MySQLDBExtension.GetStringSafe(reader,"vin");
                    list.basicInfo.mileage          = MySQLDBExtension.GetStringSafe(reader,"mileage");
                    list.signature.fairmarketvalue  = MySQLDBExtension.GetStringSafe(reader,"fairmarketvalue");
                    list.client.customer_name       = MySQLDBExtension.GetStringSafe(reader,"customer_name");
                }

                command.Connection.Close();
            }

            return list;
        }

        public Client GetClientByID(string clientID)
        {
            Client list = new Client();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer where customer_id='" + clientID + "'", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new Client()
                        {
                            customer_name = reader.GetString("customer_name"),
                            customer_scope_of_work = reader.GetString("customer_scope_of_work")
                        };
                    }
                }
            }

            return list;
        }

    }

}
