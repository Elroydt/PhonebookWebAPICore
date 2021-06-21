using PhonebookWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookWebAPICore.IServices
{
    public interface IPhonebookService
    {
        IEnumerable<Phonebook> GetPhonebook();
        Phonebook GetPhonebookById(int id);
        Phonebook AddPhonebook(Phonebook phonebook);
        Phonebook UpdatePhonebook(Phonebook phonebook);
        Phonebook DeletePhonebook(int id);
        IEnumerable<Phonebook> SearchPhonebook(string strName);
    }
}
