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
}
