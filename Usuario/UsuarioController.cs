using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Usuario;
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
	private UsuarioService _service = new UsuarioService();
	[HttpPost("IncluirUsuario")]
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
	[HttpPut("AlterarUsuario")]
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
	[HttpPost("ImportarArquivo")]
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
	[HttpDelete]
	public void RemoveTestUsers() =>_service.RemoveUsers();
}
