using System.Data;

namespace BikeRental.Moto;

public class MotoRepository
{
	private DataAccess da = new DataAccess();
	/// <summary>
	/// Insere no banco de dados uma moto nova.
	/// </summary>
	/// <param name="bike">Dados da moto a ser cadastrada.</param>
	/// <returns>Moto cadastrada (sim/não)</returns>
	public bool InsertBike(Moto bike)
	{
		try
		{
			var strSql = 
				$"insert into public.\"Bike\" (\"Ano\", \"Modelo\", \"Placa\") " +
				$"values ('{bike.Ano}', '{bike.Modelo}', '{bike.Placa}')";
            
			return da.ExecScalar(strSql);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
	/// <summary>
	/// Atualiza os dados da moto no banco de dados de acordo com os valores passados.
	/// </summary>
	/// <param name="bike">Dados da moto a ser alterada.</param>
	/// <returns>Dados da moto atualizados (sim/não)</returns>
	public bool UpdateBike(Moto bike)
	{
		try
		{
			var strSql =
				$"update public.\"Bike\" set \"Ano\" = '{bike.Ano}', \"Modelo\" = '{bike.Modelo}', \"Placa\" = '{bike.Placa}' " +
				$"where \"Id\" = {bike.Id}";
			return da.ExecScalar(strSql);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
	/// <summary>
	/// Deleta do banco de dados uma moto específica.
	/// </summary>
	/// <param name="Id">Identificador da moto cadastrada.</param>
	/// <returns>Moto deletada (sim/não)</returns>
	public bool DeleteBike(int Id)
	{
		try
		{
			var strSql = $"delete from public.\"Bike\" " +
				$"where \"Id\" = {Id}";
            return da.ExecScalar(strSql);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
	/// <summary>
	/// Consulta no banco de dados uma lista de motos, filtrada por placa.
	/// </summary>
	/// <param name="placa"> Usado como filtro na consulta para obter uma moto. Pode pesquisar por %placa% .</param>
	/// <returns> Lista de motos cadastradas.</returns>
	public List<Moto> SelectBikes(string placa)
	{
		try
		{
			var strSql = $"select \"Id\", \"Ano\", \"Modelo\", \"Placa\" from public.\"Bike\" " +
				$"where \"Placa\"' like '%{placa}%'";
			DataTable list = da.ExecQuery(strSql);

			var retorno = new List<Moto>();
			foreach (DataRow item in list.Rows)
			{
				retorno.Add(new Moto
				{
					Id = (int)item["id"],
					Ano = (int)item["ano"],
					Modelo = item["modelo"].ToString(),
					Placa = item["placa"].ToString()
				});
			}
			return retorno;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return new List<Moto>();
		}
	}
	/// <summary>
	/// Consulta no banco de dados uma lista de motos sem filtro.
	/// </summary>
	/// <returns>Lista de motos cadastradas.</returns>
	public List<Moto> SelectBikes()
	{
		var strSql = "select \"Id\", \"Ano\", \"Modelo\", \"Placa\" from public.\"Bike\" limit 100";
		DataTable list = da.ExecQuery(strSql);

		var retorno = new List<Moto>();
		foreach (DataRow bike in list.Rows)
		{
			retorno.Add(new Moto
			{
				Id = (int)bike["id"],
				Ano = (int)bike["ano"],
				Modelo = bike["modelo"].ToString(),
				Placa = bike["placa"].ToString()
			});
		}
		return retorno;
	}
    /// <summary>
    /// Consulta no banco de dados todas as informações da moto.
    /// </summary>
    /// <returns>Lista de motos cadastradas.</returns>
    public Moto BikeDetails(int id)
	{
		var strSql = "";
		DataRow bike = da.ExecQuery(strSql).Rows[0];

		return new Moto()
		{
			Id = (int)bike["id"],
			Ano = (int)bike["ano"],
			Modelo = bike["modelo"].ToString(),
			Placa = bike["placa"].ToString(),
			Alugada = (bool)bike["alugada"]
		};
	}
}