
namespace BikeRental.Moto;
public class Moto
{
	public int Id { get; set; }
	public string Ano { get; set; }
	public string Modelo { get; set; }
	public string Placa { get; set; }
	public bool Alugada { get; set; }
	public List<Locacao.Locacao> HistoricoLocacoes { get; set; }
}