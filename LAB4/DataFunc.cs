using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{
    public class DataFunc
    {
        Database database = new Database();
        public DataTable dt = new DataTable();

        public void GetByID(int id) {
            string sql = $"SELECT * FROM TableOne WHERE ID = {id}";

            database.openConnection();
            SqlCommand command = new SqlCommand(sql, database.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            database.closeConnection();
        }

        public void GetByName(string name)
        {
            string sql = $"SELECT * FROM TableOne WHERE name = '{name}'";

            database.openConnection();
            SqlCommand command = new SqlCommand(sql, database.getConnection());
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetValue(0)}, {reader.GetValue(1)}, {reader.GetValue(2)}");
                }
            }

            reader.Close();
            database.closeConnection();
        }

        public void Add(int id, string name, string message)
        {
            string sql = $"INSERT INTO TableOne VALUES ({id}, '{name}', '{message}')";

            database.openConnection();
            SqlCommand command = new SqlCommand(sql, database.getConnection());
            command.ExecuteNonQuery();

            database.closeConnection();

        }

        public void Update(int id, string message)
        {
            string sql = $"UPDATE TableOne SET message = '{message}' WHERE ID = {id}";

            database.openConnection();
            SqlCommand command = new SqlCommand(sql, database.getConnection());
            command.ExecuteNonQuery();

            database.closeConnection();

        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM TableOne WHERE ID = {id}";

            database.openConnection();
            SqlCommand command = new SqlCommand(sql, database.getConnection());
            command.ExecuteNonQuery();

            database.closeConnection();

        }
    }
}
