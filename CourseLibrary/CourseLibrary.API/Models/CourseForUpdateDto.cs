﻿using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    //[CourseTitleMustBeDifferentFromDescription(
       // ErrorMessage = "Title must be different from description.")]
    public class CourseForUpdateDto:CourseForManipulationDto
    {
        //[Required(ErrorMessage = "You should fill out a title.")]
        //[MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        //public string Title { get; set; }
        //[Required(ErrorMessage = "You should fill out a description.")]
        //[MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]
        //public string Description { get; set; }
        [Required(ErrorMessage = "You should fill out a description.")]
        public override string Description { get => base.Description; set => base.Description = value; }
    }
}