namespace BikeRental.Locacao;

public class Locacao
{
	public int IdUsuario { get; set; }
	public int IdMoto { get; set; }
	public int IdPlano { get; set; }
	public DateTime Inicio { get; set; }
	public DateTime PrevisaoTermino { get; set; }
	public DateTime Termino {  get; set; }
}
