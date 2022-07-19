using BLL.Services.Abstract;
using BLL.ViewModels;
using DAL.Concrete;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpaceObjectController : ControllerBase
    {
        private IDataProviderService _dataProviderService;
        private ISpaceObjectsManagerService _spaceObjectsManagerService;

        public SpaceObjectController(ISpaceObjectsManagerService spaceObjectsManagerService, IDataProviderService dataProviderService)
        {
            _dataProviderService = dataProviderService;
            _spaceObjectsManagerService = spaceObjectsManagerService;
        }

        [HttpGet]
        public IEnumerable<SpaceObjectViewModel> Get()
        {
            return _dataProviderService.SpaceObjects.ToList();
        }

        [HttpGet("{id}")]
        public SpaceObject Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post(SpaceObjectViewModel spaceObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _spaceObjectsManagerService.Add(spaceObject);

            return Ok(spaceObject);
        }

        [HttpPut]
        public IActionResult Put(SpaceObjectViewModel spaceObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _spaceObjectsManagerService.Edit(spaceObject);

            return Ok(spaceObject);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var spaceObject = _dataProviderService.SpaceObjects.FirstOrDefault(x => x.Id == id);

            if (spaceObject == null)
                return NotFound();

            _spaceObjectsManagerService.Delete(spaceObject);
            return Ok(spaceObject);
        }
    }
}
