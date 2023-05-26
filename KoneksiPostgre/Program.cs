using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Username=postgres;Password=12345678;Database=PBOA;Port=5432;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        //string cmdText = "CREATE TABLE mahasiswa (id SERIAL PRIMARY KEY, nim INT, nama VARCHAR)";
        //NpgsqlCommand command = new NpgsqlCommand(cmdText, connection);
        //command.ExecuteNonQuery();

        NpgsqlCommand command = new NpgsqlCommand();
        command.Connection = connection;

        //command.CommandText = "CREATE TABLE mahasiswa (id SERIAL PRIMARY KEY, nama VARCHAR)";

        //command.CommandText = "INSERT INTO mahasiswa(nim, nama) VALUES(1000, 'Budi');";

        //command.CommandText = "INSERT INTO mahasiswa(nama) VALUES(@nama)";

        //command.Parameters.AddWithValue("nama", "Budi");
        //command.Prepare();
        //command.ExecuteNonQuery();
        //command.Parameters.Clear();

        command.Parameters.AddWithValue("nama", "Andi");
        command.Prepare();
        command.ExecuteNonQuery();
        command.Parameters.Clear();

        command.CommandText = "SELECT * FROM mahasiswa";
        NpgsqlDataReader reader;

        reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nama = reader.GetString(1);
            Console.WriteLine($"{id} {nama}");
        }

        connection.Close();
    }
}
