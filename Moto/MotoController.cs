using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Moto;
[ApiController]
[Route("[controller]")]
public class MotoController : ControllerBase
{
	private MotoService _service = new MotoService();
	[HttpGet("/BikeDetail")]
	public ActionResult Details(int id)
	{
		try
		{
			return Ok(_service.DetalharMoto(id));
		}
		catch
		{
			return BadRequest();
		}
	}
	[HttpGet("/BikesList")]
	public ActionResult List()
	{
		try
		{
			return Ok(_service.ConsultaMotos());
		}
		catch
		{
			return BadRequest();
		}
	}
	[HttpGet("/BikesFilteredList")]
	public ActionResult Filter(string placa)
	{
		try
		{
			return Ok(_service.ConsultaMotos(placa));
		}
		catch
		{
			return BadRequest();
		}
	}
	[HttpPost("/IncludeBike")]
	public ActionResult Create([FromBody] Moto bike)
	{
		try
		{
			//if (!ModelState.IsValid) return BadRequest(ModelState);
			return _service.SalvarDadosMoto(bike) ? Ok() : Conflict();
		}
		catch
		{
			return BadRequest();
		}
	}

	[HttpPut("/EditBike")]
	public ActionResult Edit([FromBody] Moto bike)
	{
		try
		{
			return _service.SalvarDadosMoto(bike) ? Ok() : Conflict();
		}
		catch
		{
			return BadRequest();
		}
	}

	[HttpDelete("/DeleteBike")]
	public ActionResult Delete(int id)
	{
		try
		{
			return _service.DeletarMoto(id) ? Ok() : Conflict();
		}
		catch
		{
			return BadRequest();
		}
	}
}