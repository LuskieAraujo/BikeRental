using Npgsql;
using System.Data;

namespace BikeRental;

public class DataAccess
{
	private string _conn;
	public DataAccess() => _conn = "Host=my_host;Username=my_username;Password=my_password;Database=my_database";
	public bool ExecScalar(string sql)
	{
		using (var conn = new NpgsqlConnection(_conn))
		{
			conn.Open();
			using (var cmd = new NpgsqlCommand(sql, conn))
				return !cmd.ExecuteScalar().Equals(string.Empty);
		}
	}
	public object ExecQuery(string sql)
	{
		using (var conn = new NpgsqlConnection(_conn))
		{
			conn.Open();
			using (var cmd = new NpgsqlCommand(sql, conn))
			using (var reader = cmd.ExecuteReader())
			{
				DataTable dt = new DataTable();
				dt.Load(reader);
				return dt;
			}
		}
	}
}
