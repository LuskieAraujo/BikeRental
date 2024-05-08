using BikeRental.Locacao;

namespace BikeRental.Usuario;
public class Usuario
{
	public int Id { get; set; }
	public bool Admin { get; set; }
	public string Nome { get; set; }
	public string Cnpj { get; set; }
	public DateTime DataNascimento { get; set; }
	public string NumeroCnh { get; set; }
	public int TipoCnh { get; set; }
	public List<Locacao.Locacao> HistoricoLocacao { get; set; }
}