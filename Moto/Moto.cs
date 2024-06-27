
using System.ComponentModel.DataAnnotations;

namespace BikeRental.Moto;
public class Moto
{
	public int Id { get; set; }
	[Required]
	public int Ano { get; set; }
	[Required]
	public string Modelo { get; set; }
	[Required]
	public string Placa { get; set; }
	[Required]
	public bool Alugada { get; set; }
	public List<Locacao.Locacao> HistoricoLocacoes { get; set; }
}