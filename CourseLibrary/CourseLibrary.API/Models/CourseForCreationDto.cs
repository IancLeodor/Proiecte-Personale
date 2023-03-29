using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    //[CourseTitleMustBeDifferentFromDescription(
    //ErrorMessage = "Title must be different from description.")]//proprietatea mesajului de eroare
    public class CourseForCreationDto:CourseForManipulationDto//: IValidatableObject
    {
        //[Required(ErrorMessage = "You should fill out a title.")]
        //[MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        //public string Title { get; set; }
        //[MaxLength(1500)]
        //public string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)//interfata pentru invalidarea unui obiect prin orice mod dorim
        //{
        //    if (Title == Description)
        //      {
        //        yield return new ValidationResult(//obiect pentru a transmite mesaje de erori si de a retransmite membrii proprietatilor  sau numele modelului
        //        "The provided description should be different from the title.",
        //        new[] { "CourseForCreationDto" });
        //    }
        //}
        //public string Description { get; set; }
    }
}
