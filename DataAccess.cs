using Npgsql;
using System.Data;

namespace BikeRental;

public class DataAccess
{
	private string _conn;
	public DataAccess() => _conn = "Host=localhost; Port=5432; Database=BikeRental; User Id=postgres; Password=41503987809Jl@;";
	/// <summary>
	/// Executa comando no banco de dados e retorna um resultado.
	/// </summary>
	/// <param name="sql">Comando a ser executado no banco de dados.</param>
	/// <returns></returns>
	public bool ExecScalar(string sql)
	{
		using (var conn = new NpgsqlConnection(_conn))
		{
			conn.Open();
			using (var cmd = new NpgsqlCommand(sql, conn))
				return !cmd.ExecuteScalar().Equals(string.Empty);
		}
	}
	/// <summary>
	/// Executa comando no banco de dados e retorna uma tabela como resultado. Exemplo: retorna uma consulta de dados.
	/// </summary>
	/// <param name="sql">Comando a ser executado no banco de dados.</param>
	/// <returns></returns>
	public DataTable ExecQuery(string sql)
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
