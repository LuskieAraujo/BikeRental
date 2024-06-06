using BikeRental.Locacao;

namespace BikeRental.Moto;

public class MotoService
{
	private MotoRepository _repository = new MotoRepository();
	
	/// <summary>
	/// Retorna uma lista de motos, filtrada (por placa) ou não.
	/// </summary>
	/// <param name="placa">Opcional. Usado como filtro na consulta para obter uma moto.</param>
	/// <returns> Lista de motos cadastradas.</returns>
	public List<Moto> ConsultaMotos(string placa = "")
	{
		return placa.Equals(string.Empty)
			? _repository.SelectBikes()
			: _repository.SelectBikes(placa);
	}
	public bool SalvarDadosMoto(Moto moto)
	{
		return moto.Id.Equals(0)
			? _repository.InsertBike(moto)
			: !moto.Alugada && _repository.UpdateBike(moto);
	}
	public bool DeletarMoto(int id)
	{
		return new LocacaoService().MotoHistoricoLocacao(id).Count == 0
			? _repository.DeleteBike(id)
			: false;
	}
	public Moto DetalharMoto(int id)
	{
		var bike = _repository.BikeDetails(id);
		bike.HistoricoLocacoes.AddRange(new LocacaoService().MotoHistoricoLocacao(bike.Id));
		return bike;
	}
	public List<Moto> ListarModelos()
	{
		return _repository.SelectModels();
	}
}