using System.ComponentModel.DataAnnotations;

namespace BikeRental.Locacao;

public class Locacao
{
	[Required]
	public int IdUsuario { get; set; }
	[Required]
	public int IdMoto { get; set; }
	[Required]
	public int IdPlano { get; set; }
	[Required]
	public DateTime Inicio { get; set; }
	[Required]
	public DateTime PrevisaoTermino { get; set; }
	public DateTime Termino {  get; set; }
}
