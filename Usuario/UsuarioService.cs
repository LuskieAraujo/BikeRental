namespace BikeRental.Usuario;

public class UsuarioService
{
	private UsuarioRepository _repository = new UsuarioRepository();
	public bool SalvarUsuario(Usuario usuario)
	{
		if(usuario.Id.Equals(0) && (_repository.VerifyExistingUser("NumeroCnh", usuario.NumeroCnh) || _repository.VerifyExistingUser("Cnpj", usuario.Cnpj)))
			return false;

		return usuario.Id.Equals(0)
			? _repository.InsertUser(usuario) > 0
			: _repository.UpdateUser(usuario) > 0;
	}
	public bool SalvarDocumentoCNH(IFormFile cnh)
	{
		var extensaoArquivo = Path.GetExtension(cnh.FileName).ToLower();
		if (!extensaoArquivo.Equals(".png") && !extensaoArquivo.Equals(".bmp"))
			return false;

		string destinoDocumento = Path.Combine(Directory.GetCurrentDirectory(), "Documentos_CNH");
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
			return _repository.GetTypeCNH(idUsuario).Contains('a');
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
	public void RemoveUsers() => _repository.Remove();
}
