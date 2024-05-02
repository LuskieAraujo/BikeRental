namespace BikeRental.Moto;

public class MotoRepository
{
	/// <summary>
	/// Insere no banco de dados uma moto nova.
	/// </summary>
	/// <param name="bike">Dados da moto a ser cadastrada.</param>
	/// <returns>Moto cadastrada (sim/não)</returns>
	public bool InsertBike(Moto bike)
	{
		try
		{
			return true;
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
			return true;
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
			return true;
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
		return new List<Moto>();
	}
	/// <summary>
	/// Consulta no banco de dados uma lista de motos sem filtro.
	/// </summary>
	/// <returns>Lista de motos cadastradas.</returns>
	public List<Moto> SelectBikes()
	{
		return new List<Moto>();
	}
}