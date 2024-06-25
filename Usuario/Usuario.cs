using System.ComponentModel.DataAnnotations;

namespace BikeRental.Usuario;
public class Usuario
{
	public int Id { get; set; }
	[Required]
	public bool Admin { get; set; }
	[Required]
	public string Nome { get; set; }
	[Required]
	public string Cnpj { get; set; }
	[Required]
	public DateTime DataNascimento { get; set; }
	[Required]
	public string NumeroCnh { get; set; }
	[Required]
	public int TipoCnh { get; set; }
	public string NomeArquivoCnh { get; set; }
	public List<Locacao.Locacao>? HistoricoLocacao { get; set; }
}