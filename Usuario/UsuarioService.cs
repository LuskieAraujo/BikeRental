namespace BikeRental.Usuario;

public class UsuarioService
{
	private UsuarioRepository _repository = new UsuarioRepository();
	/*
	 * contexto: entregador / locatário
	 */
	public bool SalvarUsuario(Usuario usuario)
	{
		return usuario.Id.Equals(0)
			? _repository.InsertUser(usuario)
			: _repository.UpdateUser(usuario);
	}
	public bool SalvarDocumentoCNH(IFormFile cnh)
	{
		string destinoDocumento = Path.Combine(Directory.GetCurrentDirectory(), "..", "Documentos_CNH");
		var filepath = Path.Combine(destinoDocumento, cnh.FileName);
		try
		{
			using (var stream = new FileStream(filepath, FileMode.Create))
				cnh.CopyTo(stream);

			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
	public bool VerificarCnhValida(int idUsuario)
	{
		try
		{
			return _repository.GetTypeCNH(idUsuario).Contains("a");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
}
