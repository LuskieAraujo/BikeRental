namespace BikeRental.Plano;

public class PlanoService
{
	private PlanoRepository _repository = new PlanoRepository();
	
	public List<Plano> ListarPlanos()
	{
		return _repository.PlanList();
	}
}
