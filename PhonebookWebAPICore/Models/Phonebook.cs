using System;
using System.Collections.Generic;

#nullable disable

namespace PhonebookWebAPICore.Models
{
    public partial class Phonebook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
