using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Moto;
public class MotoController : Controller
{
	// GET: MotoController
	public ActionResult Index()
	{
		return View();
	}

	// GET: MotoController/Details/5
	public ActionResult Details(int id)
	{
		return View();
	}

	// GET: MotoController/Create
	public ActionResult Create()
	{
		return View();
	}

	// POST: MotoController/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}

	// GET: MotoController/Edit/5
	public ActionResult Edit(int id)
	{
		return View();
	}

	// POST: MotoController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(int id, IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}

	// GET: MotoController/Delete/5
	public ActionResult Delete(int id)
	{
		return View();
	}

	// POST: MotoController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(int id, IFormCollection collection)
	{
		try
		{
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}
}