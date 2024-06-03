using System.Data;

namespace BikeRental.Plano;

public class PlanoRepository
{
	private DataAccess da = new DataAccess();
	public List<Plano> PlanList()
	{
		try
		{
			var strSql = $"select \"Id\", \"Periodo\", \"Diaria\" FROM public.\"Plan\" order by \"Periodo\"";
			DataTable list = da.ExecQuery(strSql);
			var plans = new List<Plano>();

			foreach(DataRow row in list.Rows)
			{
				plans.Add(new Plano
				{
					Id = (int)row["id"],
					Diaria = (decimal)row["diaria"],
					Periodo = row["periodo"].ToString()
				});
			}
			
			return plans;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return new List<Plano>();
		}
	}
}
