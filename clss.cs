using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

class DatabaseManager
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public DatabaseManager()
    {
        server = "YOUR_MYSQL_SERVER";
        database = "YOUR_DATABASE_NAME";
        uid = "YOUR_MYSQL_USERNAME";
        password = "YOUR_MYSQL_PASSWORD";
        string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        connection = new MySqlConnection(connectionString);
    }

    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public void AddMember(Member member)
    {
        string query = "INSERT INTO members (MemberName, CostInAMonth, TotalCost) VALUES (@MemberName, @CostInAMonth, @TotalCost)";
        if (this.OpenConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MemberName", member.MemberName);
                cmd.Parameters.AddWithValue("@CostInAMonth", member.CostInAMonth);
                cmd.Parameters.AddWithValue("@TotalCost", member.TotalCost);
                cmd.ExecuteNonQuery();
            }
            this.CloseConnection();
        }
    }

    // Implement other CRUD operations (Update, Delete, View) similarly.
}
