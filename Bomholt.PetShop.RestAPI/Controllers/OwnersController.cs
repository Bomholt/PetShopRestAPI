using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bomholt.PetShop.RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Owners")]
    public class OwnersController : Controller
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this._ownerService = ownerService;
        }

        // GET: api/Owners
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetAll();
        }

        // GET: api/Owners/5
        [HttpGet("{id}", Name = "Get")]
        public Owner Get(int id)
        {
            return _ownerService.GetById(id);
        }
        
        // POST: api/Owners
        [HttpPost]
        public void Post([FromBody]Owner value)
        {
            _ownerService.CreateNew(value);
        }
        
        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Owner value)
        {
            value.ID = id;
            _ownerService.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteById(id);
        }
    }
}
