using CourseLibrary.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.ValidationAttributes
{
    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var course = (CourseForManipulationDto)validationContext.ObjectInstance;
            if (course.Title == course.Description)
            {
                //if (course.Title == course.Description)
                //{
                //    return new ValidationResult(
                //    "The provided description should be different from the title.",
                //    new[] { nameof(CourseForCreationDto) });
                //}

                return new ValidationResult(ErrorMessage,
                    new[] { nameof(CourseForCreationDto) });
            }
            return ValidationResult.Success;//declaram ca validarea pentru aceasta regula a fost reusita. 
        }
    }
}
