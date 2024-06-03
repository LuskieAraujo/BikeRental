using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Usuario;

public class UsuarioController : ControllerBase
{
	private UsuarioService _service = new UsuarioService();
	public ActionResult NewUser(Usuario user)
	{
		try
		{
			return Ok(_service.SalvarUsuario(user));
		}
		catch
		{
			return BadRequest();
		}
	}
	public ActionResult EditUser(Usuario user)
	{
		try
		{
			return Ok(_service.SalvarUsuario(user));
		}
		catch
		{
			return BadRequest();
		}
	}
	public ActionResult AddDocument(IFormFile document)
	{
		try
		{
			return document != null || document.Length != 0
				? Ok(_service.SalvarDocumentoCNH(document))
				: BadRequest();
		}
		catch
		{
			return BadRequest();
		}
	}
}
