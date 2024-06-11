using System.Data;

namespace BikeRental.Plano;

public class PlanoRepository
{
	private DataAccess da = new DataAccess();
	public List<Plano> PlanList()
	{
		try
		{
			var strSql = "select \"Id\", \"Periodo\", \"Diaria\" FROM public.\"Plan\" order by \"Periodo\"";
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
	public Plano GetPlan(int idPlano)
	{
		try
		{
			var strSql = $"select \"Id\", \"Diaria\", \"Periodo\", \"PorcentagemMulta\", \"Dias\" from public.\"Plan\" where \"Id\" = {idPlano}";
			DataRow plan = da.ExecQuery(strSql).Rows[0];
			return new Plano
			{
				Id = (int)plan["id"],
				Diaria = (decimal)plan["diaria"],
				Periodo = plan["periodo"].ToString(),
				PorcentagemMulta = (decimal)plan["porcentagemMulta"],
				Dias = (int)plan["dias"]
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return new Plano();
		}
	}
}
