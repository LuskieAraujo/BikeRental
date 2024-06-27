using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Locacao;
[ApiController]
[Route("[controller]")]
public class LocacaoController : ControllerBase
{
	private LocacaoService _service = new LocacaoService();
	[HttpGet]
	public ActionResult GetRentOptions()
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
	[HttpPost("EfetuarLocacao")]
	public ActionResult CreateRent(Locacao locacao, int qtdeDiasPlano)
	{
		try
		{
			return Ok(_service.EfetuarLocacao(locacao, qtdeDiasPlano));
		}
		catch
		{
			return BadRequest();
		}
	}
	[HttpPut]
	public ActionResult CloseRent(int idUsuario, DateTime dataEntrega)
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