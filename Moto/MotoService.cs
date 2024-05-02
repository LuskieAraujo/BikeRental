namespace BikeRental.Moto;

public class MotoService
{
	private MotoRepository _repository = new MotoRepository();
	
	public bool SalvarDadosMoto(Moto moto)
	{
		return moto.Id.Equals(0)
			? _repository.InsertBike(moto)
			: _repository.UpdateBike(moto);
	}
	public bool DeletarMoto(int id)
	{
		return _repository.DeleteBike(id);
	}
	/// <summary>
	/// Retorna uma lista de motos, filtrada (por placa) ou não.
	/// </summary>
	/// <param name="placa">Opcional. Usado como filtro na consulta para obter uma moto.</param>
	/// <returns> Lista de motos cadastradas.</returns>
	public List<Moto> ConsultaMotos(string placa = "")
	{
		return placa.Equals(string.Empty) ? _repository.SelectBikes() : _repository.SelectBikes(placa);
	}
}