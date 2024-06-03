using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Locacao;
[ApiController]
[Route("[controller]")]
public class LocacaoController : ControllerBase
{
	private LocacaoService _service = new LocacaoService();
	[HttpGet]
	public ActionResult NewRent()
	{
		try
		{
			return Ok(_service.ReservarLocacao());
		}
		catch
		{
			return BadRequest();
		}
	}
	public ActionResult CreateRent(Locacao locacao)
	{
		try
		{
			return Ok();
		}
		catch
		{
			return BadRequest();
		}
	}
	public ActionResult CloseRent()
	{
		try
		{
			return Ok();
		}
		catch
		{
			return BadRequest();
		}
	}
}