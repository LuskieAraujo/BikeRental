using System.Data;

namespace BikeRental.Locacao;

public class LocacaoRepository
{
    private DataAccess da = new DataAccess();
    public Locacao GetRentInformation(int idUsuario)
    {
        try
        {
            var strSql = "";
			DataRow rent = da.ExecQuery(strSql).Rows[0];

            return new Locacao
			{
				IdPlano = (int)rent["idplano"],
				IdMoto = (int)rent["idmoto"],
				IdUsuario = (int)rent["idusuario"],
				Inicio = (DateTime)rent["inicio"],
				Termino = (DateTime)rent["termino"]
			};
		}
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Locacao();
        }
    }
    public bool InsertRent(Locacao locacao)
    {
        try
        {
			var strSql = "";
			return !da.ExecScalar(strSql).Equals(string.Empty);
		}
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public bool CloseRent(DateTime dataFechamento)
    {
        try
        {
            var strSql = "";
            return !da.ExecScalar(strSql).Equals(string.Empty);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
