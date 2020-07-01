﻿using System;
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Json ([FromBody] DbViewArriviComponente dbView)
        {
            string result = "Error! c'è un problema!";
            if (!string.IsNullOrEmpty(dbView.Matricola) && !string.IsNullOrEmpty(dbView.Descrizione) &&
                    dbView.ComponenteCarello != null && !string.IsNullOrEmpty(dbView.Identificativo) &&
                    !string.IsNullOrEmpty(dbView.CodiceLocazione) && dbView.AreaId !=0)
            {
                Carello carello = new Carello();
                carello.Matricola = dbView.Matricola;
                _context.Carelli.Add(carello);
                await _context.SaveChangesAsync();

                int idCarello = carello.Id;

                //Aggiungere un controllo per sapere se la locazione esiste già
                Locazione locazione = _context.Locazioni.FirstOrDefault(l => l.AreaId == dbView.AreaId
                                                                        && l.Codice == dbView.CodiceLocazione);
                if (locazione == null)
                {
                    locazione = new Locazione();
                    locazione.Codice = dbView.CodiceLocazione;
                    locazione.AreaId = dbView.AreaId;
                    _context.Locazioni.Add(locazione);
                    await _context.SaveChangesAsync();
                }               
                int locazioneId = locazione.Id;

                Arrivi arrivi = new Arrivi();
                arrivi.Identificativo = dbView.Identificativo;
                arrivi.Descrizione = dbView.Descrizione;
                arrivi.Date = DateTime.Now;
                arrivi.CarelloId = idCarello;
                arrivi.LocazioneId = locazioneId;
                _context.Arrivi.Add(arrivi);
                await _context.SaveChangesAsync();

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
        public async Task<IActionResult> json([FromBody]CustomComponent customComponent)
        {
            ComponenteDelCarello componenteDelCarello = new ComponenteDelCarello();
            componenteDelCarello.ComponenteId = _context.Componente.FirstOrDefault
                                                (c => c.Codice == customComponent.ComponenteId).Id;
            //componenteDelCarello.CarelloId = customComponent.CarelloId;
            componenteDelCarello.Qty = customComponent.Qty;
            if (ModelState.IsValid)
            {
                var esiste = await _context.ComponentiDeiCarelli
                                .FindAsync(componenteDelCarello.CarelloId, componenteDelCarello.ComponenteId);
                try
                {
                    if(esiste != null)
                    {
                        esiste.Qty += componenteDelCarello.Qty;
                        _context.ComponentiDeiCarelli.Update(esiste);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.ComponentiDeiCarelli.Add(componenteDelCarello);
                        await _context.SaveChangesAsync();
                    }
                    return View();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            ViewData["CarelloId"] = new SelectList(_context.Carelli, "Id", "Matricola", componenteDelCarello.CarelloId);
            ViewData["ComponenteId"] = new SelectList(_context.Componente, "Id", "Codice", componenteDelCarello.ComponenteId);
            return RedirectToAction(nameof(Create));
        }

    */


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