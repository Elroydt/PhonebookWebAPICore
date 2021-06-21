using Microsoft.EntityFrameworkCore;
using PhonebookWebAPICore.IServices;
using PhonebookWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookWebAPICore.Services
{
    public class PhonebookService : IPhonebookService
    {

        APICoreDBContext dbContext;

        public PhonebookService(APICoreDBContext _db)
        {
            dbContext = _db;
        }
        public Phonebook AddPhonebook(Phonebook phonebook)
        {
            if (phonebook != null)
            {
                dbContext.Phonebooks.Add(phonebook);
                dbContext.SaveChanges();
                return phonebook;
            }
            return null;
        }

        public Phonebook DeletePhonebook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phonebook> GetPhonebook()
        {
            var phonebook = dbContext.Phonebooks.ToList();
            return phonebook;
        }

        public Phonebook GetPhonebookById(int id)
        {
            var phonebook = dbContext.Phonebooks.FirstOrDefault(x => x.Id == id);
            return phonebook;
        }

        public IEnumerable<Phonebook> SearchPhonebook(string strName)
        {
            var phonebook = dbContext.Phonebooks.Where(x => x.Name.StartsWith(strName) || strName == null).ToList();
            return phonebook;
        }

        public Phonebook UpdatePhonebook(Phonebook phonebook)
        {
            dbContext.Entry(phonebook).State = EntityState.Modified;
            dbContext.SaveChanges();
            return phonebook;
        }
    }
}
