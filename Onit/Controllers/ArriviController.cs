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
    public class ArriviController : Controller
    {
        private readonly OnitContext _context;       
        public ArriviController(OnitContext context)
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

        // GET : InserimentoArrivo
        public ActionResult InserimentoArrivo()
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

        // POST  di un inserimento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Json ([FromBody] DbViewArriviComponente dbView)
        {
            string result = "Error! c'è un problema!";
            if (!string.IsNullOrEmpty(dbView.Matricola) && !string.IsNullOrEmpty(dbView.Descrizione) &&
                    dbView.ComponenteCarello != null && !string.IsNullOrEmpty(dbView.Identificativo) &&
                    !string.IsNullOrEmpty(dbView.CodiceLocazione) && dbView.AreaId !=0)
            {

                //controllo per sapere se il carello esiste già
                Carello carello = _context.Carelli.FirstOrDefault(c => c.Matricola == dbView.Matricola);

                //se non esiste lo aggiungiamo
                if(carello == null)
                {
                    carello = new Carello();
                    carello.Matricola = dbView.Matricola;
                    _context.Carelli.Add(carello);
                    await _context.SaveChangesAsync();
                }
                int idCarello = carello.Id;

                //controllo per sapere se la locazione esiste già
                Locazione locazione = _context.Locazioni.FirstOrDefault(l => l.AreaId == dbView.AreaId
                                                                        && l.Codice == dbView.CodiceLocazione);
                //se non esiste la aggiungiamo 
                if (locazione == null)
                {
                    locazione = new Locazione();
                    locazione.Codice = dbView.CodiceLocazione;
                    locazione.AreaId = dbView.AreaId;
                    _context.Locazioni.Add(locazione);
                    await _context.SaveChangesAsync();
                }               
                int locazioneId = locazione.Id;

                //Verifica se è gia stato effetuato questa accetazione
                Arrivi arrivi = _context.Arrivi.Find(idCarello,locazioneId);
                if (arrivi == null)
                {
                    arrivi.Identificativo = dbView.Identificativo;
                    arrivi.Descrizione = dbView.Descrizione;
                    arrivi.Date = DateTime.Now;
                    arrivi.CarelloId = idCarello;
                    arrivi.LocazioneId = locazioneId;
                    _context.Arrivi.Add(arrivi);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //manda in error 500 se si cerca di inserire un carello gia presente e una locazione gia presente
                }

                //aggiornamento delle componente di questo carello
                ComponenteDelCarello cdc;
                Componente compo;
                foreach (var item in dbView.ComponenteCarello)
                {
                    cdc = new ComponenteDelCarello();
                    compo = _context.Componente.FirstOrDefault(c => c.Codice == item.ComponenteId);
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
