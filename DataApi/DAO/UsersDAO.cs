using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataApi.Models;

namespace DataApi.DAO
{
    public class UsersDAO {
        private string connStr;

        private SqlCommand insertCommand(UserModel user) {
            SqlCommand command = new SqlCommand("INSERT INTO [Coffee].[dbo].[Users] VALUES (@email, @monday, @tuesday, @wednesday, @thursday, @friday)");

            command.Parameters.AddWithValue("@email", user.email);
            command.Parameters.AddWithValue("@monday", user.monday);
            command.Parameters.AddWithValue("@tuesday", user.tuesday);
            command.Parameters.AddWithValue("@wednesday", user.wednesday);
            command.Parameters.AddWithValue("@thursday", user.thursday);
            command.Parameters.AddWithValue("@friday", user.friday);

            return command;
        }
        public UsersDAO(string connStr) {
            this.connStr = connStr;
        }

        private SqlConnection getConnection() {
            return new SqlConnection(connStr);
        }
        
        public String storeUser(UserModel user) {

            using (SqlConnection conn = getConnection()) {
                SqlCommand command = insertCommand(user);
            
                command.Connection = conn;

                string result = "Success";
                try {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e) {
                    result = e.Message;
                }
                finally {
                    conn.Close();                 
                }
                return result;


            }

        }


    }
}
