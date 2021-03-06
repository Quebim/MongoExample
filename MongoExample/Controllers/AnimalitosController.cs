﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoExample.Controllers
{
    public class AnimalitosController : Controller
    {
        // GET: Animalitos
        public ActionResult Index()
        {
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var laListaDeAnimalitos = elRepositorio.ListarTodos("mongodb://bran:123@cluster0-shard-00-00-rirzj.azure.mongodb.net:27017,cluster0-shard-00-01-rirzj.azure.mongodb.net:27017,cluster0-shard-00-02-rirzj.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority", "prueba");
            return View(laListaDeAnimalitos);
        }

        public ActionResult DuenoDetails (string id)
        {
            var elIdOriginal = new ObjectId(id);
            ViewBag.ElAnimalitoConsultado = id;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var elPropietario = elRepositorio.ObtenerPropietarioDeAnimalito(elIdOriginal);
            if (elPropietario != null)
                elPropietario = new Modelo.MisColecciones.Propietario();
            return View(elPropietario);
        }

        // GET: Animalitos/Details/5
        public ActionResult Details(string id)
        {
            var elIdOriginal = new ObjectId(id);
            ViewBag.ElAnimalitoConsultado = id;
            var elRepositorio = new MongoExample.Negocio.Repositorio.Animalitos();
            var elAnimalito = elRepositorio.ObtenerAnimalitoPorId(elIdOriginal);
            return View(elAnimalito);
        }

        // GET: Animalitos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animalitos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animalitos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animalitos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animalitos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animalitos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
