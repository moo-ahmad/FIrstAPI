using FirstAPI.BLL.Interface;
using FirstAPI.BLL.Service;
using FirstAPI.DAL.Interface;
using FirstAPI.Models.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIrstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person> _repository;
        private readonly IPersonService _personService;

       public PersonController(IRepository<Person> repository, IPersonService personService)
        {
            _repository = repository;
            _personService = personService;
        }
        
        [HttpPost("AddPerson")]
        public async Task<object> AddPerson([FromBody] Person person)
        {
            try
            {
                await _personService.AddPerson(person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete("DeletePerson")]
        public bool DeletePerson(string userEmail)
        {
            try
            {
                _personService.DeletePersonByEmail(userEmail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("UpdatePerson")]
        public bool UpdatePerson(Person person)
        {
            try
            {
                _personService.UpdatePerson(person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetAllPersonByName")]
        public object GetAllPersonByName(string userName)
        {
            var data = _personService.GetPersonByUserName(userName);

            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
                );
            return json;
        }

        [HttpGet("GetAllPersons")]
        public object GetAllPersons()
        {
            var data = _personService.GetAllPersons();

            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
                );
            return json;
        }
    }
}
