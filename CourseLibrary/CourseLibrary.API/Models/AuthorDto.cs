using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // nu returnam nume si prenume , returnam cele doua concatenate intr-un singur camp
        public int Age { get; set; }
        public string MainCategory { get; set; }
    }
}
