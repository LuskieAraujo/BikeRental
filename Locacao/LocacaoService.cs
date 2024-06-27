using BikeRental.Moto;
using BikeRental.Plano;
using BikeRental.Usuario;

namespace BikeRental.Locacao;

public class LocacaoService
{
	private LocacaoRepository _repository = new LocacaoRepository();

	public List<Locacao> HistoricoLocacaoMoto(int idMoto)
	{
		return _repository.SelectRentalsByBike(idMoto);
	}
	public List<Locacao> HistoricoLocacaoEntregador(int idEntregador)
	{
		return _repository.SelectRentalsByDelivery(idEntregador);
	}
	public Reserva.Reserva ReservarLocacao()
	{
		return new Reserva.Reserva
		{
			Motos = new MotoService().ListarModelos(),
			Planos = new PlanoService().ListarPlanos()
		};
	}
	public decimal FecharLocacao(int idUsuario, DateTime dataFechamento)
	{
		var locacao = _repository.GetRentInformation(idUsuario);
		var plano = new PlanoService().ObterPlano(locacao.IdPlano);

		var diferenca = locacao.PrevisaoTermino - dataFechamento;
		if(diferenca.Days > 0)
		{
			// fechou antes do prazo
			var diasUsados = (plano.Dias - diferenca.Days) * plano.Diaria;
			var multaContratual = (diferenca.Days * plano.Diaria) * plano.PorcentagemMulta;
			return diasUsados + multaContratual;
		}
		else if (diferenca.Days < 0)
		{
			// fechou depois do prazo
			return (plano.Diaria * plano.Dias) + (diferenca.Days * 50);
		}
		else
		{
			// fechou no dia previsto
			return plano.Diaria * plano.Dias;
		}
	}
	public bool EfetuarLocacao(Locacao rent, int qtdeDias)
	{
		try
		{
			if (!new UsuarioService().VerificarCnhValida(rent.IdUsuario))
				return false;

			rent.Inicio = DateTime.Today.AddDays(1);
			rent.PrevisaoTermino = rent.Inicio.AddDays(qtdeDias);
			return _repository.InsertRent(rent);
		}
		catch
		{
			return false;
		}
	}
}
