using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Moto;
public class MotoController : Controller
{
	private MotoService _service = new MotoService();

	// GET: MotoController/Details/5
	public ActionResult Details(int id)
	{
		try
		{
			return _service.DetalharMoto(id);
		}
		catch
		{
			return BadRequest();
		}
	}

	// POST: MotoController/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create([FromBody] Moto bike)
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

	// POST: MotoController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
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

	// POST: MotoController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
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