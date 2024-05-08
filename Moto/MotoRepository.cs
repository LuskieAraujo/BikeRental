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
			var strSql = "";
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
			var strSql = "";
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
			var strSql = "";
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
	/// <param name="placa"> Usado como filtro na consulta para obter uma moto.</param>
	/// <returns> Lista de motos cadastradas.</returns>
	public List<Moto> SelectBikes(string placa)
	{
		//return new List<Moto>().Where(x => x.Placa == placa).ToList();
		var strSql = string.Format("", placa);
		object list = da.ExecQuery(strSql);

		var retorno = new List<Moto>();
		foreach (var item in list)
		{
			retorno.Add(new Moto
			{
				Id = item.id,
				Ano = item.ano,
				Modelo = item.modelo,
				Placa = item.placa
			});
		}
		return retorno;
	}
	/// <summary>
	/// Consulta no banco de dados uma lista de motos sem filtro.
	/// </summary>
	/// <returns>Lista de motos cadastradas.</returns>
	public List<Moto> SelectBikes()
	{
		var strSql = "";
        object list = da.ExecQuery(strSql);

        var retorno = new List<Moto>();
        foreach (var item in list)
        {
            retorno.Add(new Moto
            {
                Id = item.id,
                Ano = item.ano,
                Modelo = item.modelo,
                Placa = item.placa
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
		object bike = da.ExecQuery(strSql);
		return new Moto()
		{
			Id = bike.id,
			Ano = bike.ano,
			Modelo = bike.modelo,
			Placa = bike.placa,
			Alugada = bike.alugada
		}
	}
}