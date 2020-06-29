using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onit.Data;
using Onit.Models;
using Onit.Other;

namespace Onit.Controllers
{
    public class ArrivisController : Controller
    {
        private readonly OnitContext _context;       
        public ArrivisController(OnitContext context)
        {
            _context = context;
        }

        // GET: Arrivis
        public async Task<IActionResult> Index()
        {
            var onitContext = _context.Arrivi.Include(a => a.Carello).Include(a => a.Locazione).Include(a=>a.Locazione.Area);
            var areaList = _context.Aree.ToList();
            ViewBag.AreaList = new SelectList(areaList, "Id", "Codice");
            ViewData["AreaId"] = new SelectList(areaList, "Id", "Codice");
            return View(await onitContext.ToListAsync());
        }
        public ActionResult Insertion()
        {
            ViewData["LocazioneId"] = new SelectList(
                (from s in _context.Locazioni.Include(s => s.Area).ToList()
                 select new{Id = s.Id,FullName = "Area {" + s.Area.Codice + "} Locazione {" + s.Codice + "}"
                 }), "Id", "FullName");
            var areaList = _context.Aree.ToList();
            ViewData["AreaId"] = new SelectList(areaList, "Id", "Codice");
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Codice", "Codice");
            var arrivi = _context.Arrivi.Include(c=>c.Carello)
                         .Include(c=>c.Carello.ComponentiDelCarello)
                         .ThenInclude(c=>c.Componente)
                         .ToList();
            return View(arrivi);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveArrivo(
            string CodiceLocazione, string AreaId, string Matricola, string Descrizione,
            string Identificativo, CustomComponent[] CustomComponent)
        {
            string result = "Error! c'è un problema!";
            if (!string.IsNullOrEmpty(Matricola) && !string.IsNullOrEmpty(Descrizione) &&
                    CustomComponent != null && !string.IsNullOrEmpty(Identificativo) &&
                    !string.IsNullOrEmpty(CodiceLocazione) && !string.IsNullOrEmpty(AreaId))
            {
                Carello carello = new Carello();
                carello.Matricola = Matricola;
                _context.Carelli.Add(carello);
                _context.SaveChangesAsync();

                int idCarello = carello.Id;

                //Aggiungere un controllo per sapere se la locazione esiste già
                Locazione locazione = new Locazione();
                locazione.Codice = CodiceLocazione;
                locazione.AreaId = int.Parse(AreaId);
                _context.Locazioni.Add(locazione);
                _context.SaveChangesAsync();

                int locazioneId = locazione.Id;

                Arrivi arrivi = new Arrivi();
                arrivi.Identificativo = Identificativo;
                arrivi.Descrizione = Descrizione;
                arrivi.Date = DateTime.Now;
                arrivi.CarelloId = idCarello;
                arrivi.LocazioneId = locazioneId;
                _context.Arrivi.Add(arrivi);
                _context.SaveChangesAsync();

                ComponenteDelCarello cdc;
                Componente compo;
                foreach (var item in CustomComponent)
                {
                    cdc = new ComponenteDelCarello();
                    compo = _context.Componente.FirstOrDefault(c => c.Codice == item.Codice);
                    cdc.ComponenteId = compo.Id;
                    cdc.CarelloId = idCarello;
                    cdc.Qty = item.Qty;
                    _context.ComponentiDeiCarelli.Add(cdc);
                }
                _context.SaveChanges();
                result = "Success!";
            }
            return Json(result);
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveArriviAsync(
            string codiceLocazione, int AreaId ,string matricola ,string descrizione,
            string identificativo , CustomComponent[] componenteDelCarellos)
        {
            string result = "Error! c'è un problema!";
            if (!string.IsNullOrEmpty(matricola) && !string.IsNullOrEmpty(descrizione) &&
                    componenteDelCarellos != null && !string.IsNullOrEmpty(identificativo) && 
                    !string.IsNullOrEmpty(codiceLocazione) && AreaId!=0)
            {
                Carello carello = new Carello();
                carello.Matricola = matricola;
                _context.Carelli.Add(carello);
                await _context.SaveChangesAsync();

                int idCarello = carello.Id;

                //Aggiungere un controllo per sapere se la locazione esiste già
                Locazione locazione = new Locazione();
                locazione.Codice = codiceLocazione;
                locazione.AreaId = AreaId;
                _context.Locazioni.Add(locazione);
                await _context.SaveChangesAsync();

                int locazioneId = locazione.Id;
                
                Arrivi arrivi = new Arrivi();
                arrivi.Identificativo = identificativo;
                arrivi.Descrizione = descrizione;
                arrivi.Date = DateTime.Now;
                arrivi.CarelloId = idCarello;
                arrivi.LocazioneId = locazioneId;
                _context.Arrivi.Add(arrivi);
                await _context.SaveChangesAsync();

                ComponenteDelCarello cdc;
                Componente compo;
                foreach (var item in componenteDelCarellos)
                {                   
                    cdc = new ComponenteDelCarello();
                    compo = await _context.Componente.FirstOrDefaultAsync(c => c.Codice == item.Codice);
                    cdc.ComponenteId = compo.Id;
                    cdc.CarelloId = idCarello;
                    cdc.Qty = item.Qty;
                    _context.ComponentiDeiCarelli.Add(cdc);
                }
                await _context.SaveChangesAsync();
                result = "Success!";
            }
            return Json(result);
        } */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveArrivi(CustomArriviViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Carello carello = new Carello();
                    carello.Matricola = model.MatricolaCarello;
                    _context.Carelli.Add(carello);
                    await _context.SaveChangesAsync();

                    int idCarello = carello.Id;

                    //Aggiungere un controllo per sapere se la locazione esiste già
                    Locazione locazione = new Locazione();
                    locazione.Codice = model.CodiceLocazione;
                    locazione.AreaId = model.AreaId;

                    _context.Locazioni.Add(locazione);
                    await _context.SaveChangesAsync();

                    int locazioneId = locazione.Id;

                    Arrivi arrivi = new Arrivi();
                    arrivi.Identificativo = model.Identificativo;
                    arrivi.Descrizione = model.Descrizione;
                    arrivi.Date = model.Date;
                    arrivi.CarelloId = idCarello;
                    arrivi.LocazioneId = locazioneId;
                    _context.Arrivi.Add(arrivi);
                    await _context.SaveChangesAsync();


                    return RedirectToAction("AddComponente",new { id =idCarello });
                }
                catch (Exception ex){ throw ex;}
            }        
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", model) });
        }

        // GET: Arrivis/Details/5
        public async Task<IActionResult> Details(int? CarelloId, int? LocazioneId)
        {
            if (CarelloId == null || LocazioneId == null)
            {
                return NotFound();
            }

            var arrivi = await _context.Arrivi.FindAsync(CarelloId,LocazioneId);
            if (arrivi == null)
            {
                return NotFound();
            }
            return View(arrivi);
        }

        // GET: Arrivis/AddComponente
        public IActionResult AddComponente(int id)
        {
            ViewBag.idCarello = id;
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice");
            return View();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComponente([Bind("Qty,CarelloId,ComponenteId")] ComponenteDelCarello componenteDelCarello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componenteDelCarello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", componenteDelCarello.CarelloId);
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice", componenteDelCarello.ComponenteId);
            return View(componenteDelCarello);
        } */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> json(ComponenteDelCarello componenteDelCarello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componenteDelCarello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", componenteDelCarello.CarelloId);
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice", componenteDelCarello.ComponenteId);
            return View(componenteDelCarello);
        }

        // GET: Arrivis/Create
        public IActionResult Create()
        {
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola");
            ViewData["LocazioneId"] = new SelectList((from s in _context.Locazioni.Include(s => s.Area).ToList()
                                                      select new
                                                      {
                                                          Id = s.Id,
                                                          FullName = "Area {" + s.Area.Codice + "} Locazione {" + s.Codice + "}"
                                                      }), "Id", "FullName");
            var areaList = _context.Aree.ToList();
            ViewData["AreaId"] = new SelectList(areaList, "Id", "Codice");
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Codice", "Codice");
            return View();
        }


        // GET: Arrivis/Edit/5
        public async Task<IActionResult> Edit(int? CarelloId, int? LocazioneId)
        {
            if (CarelloId == null || LocazioneId==null)
            {
                return NotFound();
            }

            var arrivi = await _context.Arrivi.FindAsync(CarelloId,LocazioneId);
            if (arrivi == null)
            {
                return NotFound();
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", arrivi.CarelloId);
            ViewData["LocazioneId"] = new SelectList(_context.Locazioni, "Id", "Codice", arrivi.LocazioneId);
            return View(arrivi);
        }

        // POST: Arrivis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? CarelloId, int? LocazioneId, [Bind("Identificativo,Descrizione,Date,CarelloId,LocazioneId")] Arrivi arrivi)
        {
            if (CarelloId != arrivi.CarelloId || LocazioneId != arrivi.LocazioneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrivi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArriviExists(arrivi.CarelloId ,arrivi.LocazioneId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", arrivi.CarelloId);
            ViewData["LocazioneId"] = new SelectList(_context.Locazioni, "Id", "Codice", arrivi.LocazioneId);
            return View(arrivi);
        }

        // GET: Arrivis/Delete/5
        public async Task<IActionResult> Delete(int? CarelloId, int? LocazioneId)
        {
            if (CarelloId == null || LocazioneId==null)
            {
                return NotFound();
            }

            var arrivi = await _context.Arrivi.FindAsync(CarelloId, LocazioneId);
                
            if (arrivi == null)
            {
                return NotFound();
            }

            return View(arrivi);
        }

        // POST: Arrivis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? CarelloId, int? LocazioneId)
        {
            var arrivi = await _context.Arrivi.FindAsync(CarelloId , LocazioneId);
            _context.Arrivi.Remove(arrivi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArriviExists(int? CarelloId, int? LocazioneId)
        {
            return ((_context.Arrivi.Find(CarelloId,LocazioneId)!=null));
        }
    }
}
