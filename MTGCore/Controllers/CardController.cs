﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTGCore.Models;
using MTGCore.Services;
using Newtonsoft.Json;

namespace MTGCore.Controllers
{
    public class CardController : Controller
    {
        private MTGService _mtgService;

        public CardController(MTGService mtgservice)
        {
            _mtgService = mtgservice;
        }

        public async Task<ActionResult> Index(int Page)
            {
            var response = await _mtgService.GetCardsByPage(Page);

            if (response == null)
                return NotFound();

            return View(response);
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id) 
        {
            var response = await _mtgService.GetCardByID(id);

            if (response == null)
                return NotFound();

            return View(response);

        }
    }
}