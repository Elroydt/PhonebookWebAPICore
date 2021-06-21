using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhonebookWebAPICore.IServices;
using PhonebookWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private readonly IPhonebookService phonebookService;
        public PhonebookController(IPhonebookService phonebook)
        {
            phonebookService = phonebook;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Phonebook/GetPhonebook")]
        public IEnumerable<Phonebook> GetPhonebook()
        {
            return phonebookService.GetPhonebook();
        }

        [HttpPost]
        //[Route("[action]")]
        //[Route("api/Phonebook/AddPhonebook")]
        public Phonebook AddPhonebook(Phonebook phonebook)
        {
            return phonebookService.AddPhonebook(phonebook);
        }

        [HttpGet("{Id}")]
        //[Route("[action]")]
        //[Route("api/Phonebook/GetPhonebookId/{Id}")]
        public Phonebook GetPhonebookeId(int id)
        {
            return phonebookService.GetPhonebookById(id);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Phonebook/EditPhonebook")]
        public Phonebook EditPhonebook(Phonebook phonebook)
        {
            return phonebookService.UpdatePhonebook(phonebook);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Phonebook/SearchPhonebook")]
        public IEnumerable<Phonebook> SearchPhonebook(string strName)
        {
            return phonebookService.SearchPhonebook(strName);
        }
    }
}
