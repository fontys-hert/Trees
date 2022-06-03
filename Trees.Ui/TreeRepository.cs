using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Ui
{
    internal class TreeRepository
    {
        private string connectionString = "Server=localhost;Database=Trees;User Id=sa;Password=p4ssw0rd!;";

        public (Tree cedar, Tree birch) RetrieveHeightFromDatabase()
        {
            Tree cedar = new Tree("cedar", 30, 55);
            Tree birch = new Tree("birch", 100, 100);
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT Name, Height FROM Tree", connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var name = reader.GetString(0);
                var height = reader.GetInt32(1);

                if (name == "birch")
                {
                    birch = new Tree(name, 100, 100, height);
                }

                if (name == "cedar")
                {
                    cedar = new Tree(name, 30, 55, height);
                }
            }

            return (cedar, birch);
        }

        public void SaveToDatabase(Tree birch, Tree cedar)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            ClearTreesFromDatabase(connection);
            InsertTree(birch, connection);
            InsertTree(cedar, connection);
        }

        private void ClearTreesFromDatabase(SqlConnection connection)
        {
            var command = new SqlCommand("DELETE FROM Tree", connection);

            command.ExecuteNonQuery();
        }

        private void InsertTree(Tree tree, SqlConnection connection)
        {
            var command = new SqlCommand("INSERT INTO Tree (Name, Height) VALUES (@name, @height);", connection);
            command.Parameters.Add(new SqlParameter { ParameterName = "@name", Value = tree.Name });
            command.Parameters.Add(new SqlParameter { ParameterName = "@height", Value = tree.HeightCurrent });

            command.ExecuteNonQuery();
        }
    }
}
