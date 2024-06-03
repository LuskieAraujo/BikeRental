namespace BikeRental.Locacao;

public class LocacaoService
{
    private LocacaoRepository _repository = new LocacaoRepository();

    public List<Locacao> MotoHistoricoLocacao(int idMoto)
    {
        return _repository.SelectRentalsByBike(idMoto);
    }
    public List<Locacao> EntregadorHistoricoLocacao(int idEntregador)
    {
        return _repository.SelectRentalsByDelivery(idEntregador);
    }
    public Reserva.Reserva ReservarLocacao()
    {
        return new Reserva.Reserva
        {
            Motos = new Moto.MotoService().ListarModelos(),
            Planos = new Plano.PlanoService().ListarPlanos()
        };
    }
    public bool EfetuarLocacao(Locacao rent)
    {
        try
        {


        }
        catch
        {
            return false;
        }
    }
}
