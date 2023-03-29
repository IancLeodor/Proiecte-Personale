using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.ResourceParameters;
using CourseLibrary.API.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
    [ApiController]// este configurat controlerul cu caracteristici si comportament care vizeaza experienta de dezvoltare la construirea API-urilor
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper=mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }
        
        //[HttpGet]
        //[HttpHead]
        //public ActionResult<IEnumerable<AuthorDto>>  GetAuthors() //ActionResult<T> daca tipul de returnare a metodei este definit in <T> alte bucati de cod pot deduce actiunile de tip  return returnaete
        //{
        //    //throw new Exception("Test exception");
        //    var authorsFromRepo = _courseLibraryRepository.GetAuthors();
        //    _mapper = mapper ??
        //        throw new ArgumentNullException(nameof(mapper));
        //}

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
           [FromQuery] AuthorsResourceParameters authorsResourceParameters) //ActionResult<T> daca tipul de returnare a metodei este definit in <T> alte bucati de cod pot deduce actiunile de tip  return returnaete
        {
            //throw new Exception("Test exception");
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);


            //var authors = new List<AuthorDto>();
            //foreach (var author in authorsFromRepo)// parcurgem fiecare autor din repository si adaugam un nou AuthorDto
            //{
            //  authors.Add(new AuthorDto()
            //{
            //Id = author.Id,
            //Name = $"{author.FirstName} {author. LastName}",
            //MainCategory = author.MainCategory,
            //Age = author.DateOfBirth.GetCurrentAge()

            //});
            //}

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
            //return Ok(authors);
        }
        [HttpGet("{authorId}",Name ="GetAuthor")]// id-ul depinde de sursa pe care dorim sa o accesam 
        public IActionResult GetAuthor(Guid authorId)
        {
            //if (!_courseLibraryRepository.AuthorExists(authorId))
           // {
               // return NotFound();
            //} verificam daca autorul exista 
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null) //daca autorul din repo este null 
            {
                return NotFound();// vom returna Not Found in caz contrar il vom returna din depozit
            }
            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
            //return Ok(authorFromRepo); // JSOn result este inlocuit cu OK
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {

            var authorEntity = _mapper.Map<Entities.Author>(author); //se trece prin entitati , Author este destinatia si author este parametru
            _courseLibraryRepository.AddAuthor(authorEntity);//apelam la depozit, metoda AddAuthor accepta authorEntity
            _courseLibraryRepository.Save();// s ar putea ca inregistrarile sa nu fie cuprinse in cod, daca baza de date va fi offline va genera o exceptie si va duce automat la o eroare interna 500. 
            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("GetAuthor", // ne permite sa returnam un raspuns cu un antet de locatie, iar acel antet va continr URI-ul unde poate fi gasit autorul nou creat
            new {authorId = authorToReturn.Id },
                authorToReturn);
        }

        [HttpOptions]//optiunile ne vor informa daca putem obtine sau nu resursa , sterge, posta 
        public IActionResult GetAuthorOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
        [HttpDelete("{author Id}")]
        public ActionResult DeleteAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            if (authorFromRepo == null)
            {
                return NotFound();
            }
            _courseLibraryRepository.DeleteAuthor(authorFromRepo);
            _courseLibraryRepository.Save();
            return NoContent();
        }
    }
}
