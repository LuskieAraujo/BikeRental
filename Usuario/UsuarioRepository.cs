using System.Collections.Generic;
using System.Data;

namespace BikeRental.Usuario;

public class UsuarioRepository
{
	private DataAccess da = new DataAccess();
	public int InsertUser(Usuario user)
	{
		try
		{
			var strSql = $"insert into public.\"User\" (\"Admin\", \"Nome\", \"Cnpj\", \"DataNascimento\", \"NumeroCnh\", \"TipoCnh\") " +
				$"values ({user.Admin},  '{user.Nome}', '{user.Cnpj}', '{user.DataNascimento}', '{user.NumeroCnh}', {user.TipoCnh})";

			return da.ExecRowsAffected(strSql);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return 0;
		}
	}
	public bool VerifyExistingUser(string param, string value)
	{
		try
		{
			var strSql = $"select 1 from public.\"User\" where \"{param}\" = '{value}'";
			return !da.ExecScalar(strSql).Equals(string.Empty);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return true;
		}
	}
	public int UpdateUser(Usuario user)
	{
		try
		{
			var strSql = $"update public.\"User\" set \"Admin\" = {user.Admin}, \"Nome\" = '{user.Nome}', \"Cnpj\" = '{user.Cnpj}', \"DataNascimento\" = '{user.DataNascimento}', " +
				$"\"NumeroCnh\" = '{user.NumeroCnh}', \"TipoCnh\" = '{user.TipoCnh}', \"NomeArquivoCnh\" = '{user.NomeArquivoCnh}'" +
				$"where \"Id\" = {user.Id};";

			return da.ExecRowsAffected(strSql);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return 0;
		}
	}
	public void Remove()
	{
		da.ExecScalar("delete from public.\"User\"");
	}
	//public bool DeleteUser(int id)
	//{
	//	try
	//	{
	//		var strSql = $"delete from public.\"User\" where \"Id\" = {id}";
	//		return da.ExecScalar(strSql);
	//	}
	//	catch (Exception ex)
	//	{
	//		Console.WriteLine(ex.Message);
	//		return false;
	//	}
	//}
	//public Usuario SelectUserByCnpj(string cnpj)
	//{
	//	try
	//	{
	//		var strSql = $"select \"Id\", \"Admin\", \"Nome\", \"Cnpj\", \"DataNascimento\", \"NumeroCnh\", \"TipoCnh\" from public.\"User\" " +
	//			$"where \"Cnpj\" = '{cnpj}'";
	//		DataRow user = da.ExecQuery(strSql).Rows[0];

	//		return new Usuario
	//		{
	//			Id = (int)user["id"],
	//			Admin = (bool)user["admin"],
	//			Nome = user["nome"].ToString(),
	//			Cnpj = user["cnpj"].ToString(),
	//			DataNascimento = (DateTime)user["datanascimento"],
	//			NumeroCnh = user["numerocnh"].ToString(),
	//			TipoCnh = user["tipocnh"].ToString()
	//		};
	//	}
	//	catch (Exception ex)
	//	{
	//		Console.WriteLine(ex.Message);
	//		return new Usuario();
	//	}
	//}
	//public Usuario SelectUserByCnh(string cnh)
	//{
	//	try
	//	{
	//		var strSql = $"select \"Id\", \"Admin\", \"Nome\", \"Cnpj\", \"DataNascimento\", \"NumeroCnh\", \"TipoCnh\" from public.\"User\" " +
	//			$"where \"NumeroCnh\" = '{cnh}'";
	//		DataRow user = da.ExecQuery(strSql).Rows[0];

	//		return new Usuario
	//		{
	//			Id = (int)user["id"],
	//			Admin = (bool)user["admin"],
	//			Nome = user["nome"].ToString(),
	//			Cnpj = user["cnpj"].ToString(),
	//			DataNascimento = (DateTime)user["datanascimento"],
	//			NumeroCnh = user["numerocnh"].ToString(),
	//			TipoCnh = user["tipocnh"].ToString()
	//		};
	//	}
	//	catch (Exception ex)
	//	{
	//		Console.WriteLine(ex.Message);
	//		return new Usuario();
	//	}
	//}
	public string GetTypeCNH(int idUsuario)
	{
		try
		{
			var strSql = $"select \"TipoCnh\" from public.\"User\" where \"Id\" = {idUsuario}";
			return da.ExecScalar(strSql);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return string.Empty;
		}
	}
}
