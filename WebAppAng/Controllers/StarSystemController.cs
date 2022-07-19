using BLL.Services.Abstract;
using BLL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StarSystemController : ControllerBase
    {
        private IDataProviderService _dataProviderService;
        private IStarSystemManagerService _starSystemManagerService;

        public StarSystemController(IStarSystemManagerService starSystemManagerService, IDataProviderService dataProviderService)
        {
            _dataProviderService = dataProviderService;
            _starSystemManagerService = starSystemManagerService;
        }

        [HttpGet]
        public IEnumerable<StarSystemViewModel> Get()
        {
            return _dataProviderService.StarSystems.ToList();
        }

        [HttpGet("{id}")]
        public StarSystem Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post(StarSystemViewModel starSystem)
        {
            _starSystemManagerService.Add(starSystem);

            return Ok(starSystem);
        }

        [HttpPut]
        public IActionResult Put(StarSystemViewModel starSystem)
        {
            _starSystemManagerService.Edit(starSystem);

            return Ok(starSystem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var starSystem = _dataProviderService.StarSystems.FirstOrDefault(x => x.Id == id);

            if (starSystem == null)
                return NotFound();

            _starSystemManagerService.Delete(starSystem);
            return Ok(starSystem);
        }
    }
}
