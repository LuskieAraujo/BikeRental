namespace BikeRental.Locacao;

public class LocacaoRepository
{
    private DataAccess da = new DataAccess();
    public bool InsertRental(Locacao locacao)
    {
        try
        {
			var strSql = "";
			return da.ExecScalar(strSql);
		}
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
    public List<Locacao> SelectRentalsByBike(int idMoto)
    {
        return new List<Locacao>();
    }
    public List<Locacao> SelectRentalsByDelivery(int idEntregador)
    {
        return new List<Locacao>();
    }
}
