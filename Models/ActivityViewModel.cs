using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class ActivityViewModel : BaseEntity{

        [Required(ErrorMessage= "Required")]
        [MinLength(2)]
        [Display(Name= "Title")]
        public string Title {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date {get; set;}

        [Required(ErrorMessage= "Required")]
        [MinLength(2)]
        [Display(Name= "Description")]
        public string Description {get; set;}


        [Required(ErrorMessage= "Required")]
        [MinLength(2)]
        [Display(Name= "Time")]
        public string Time {get; set;}
        
        [Required(ErrorMessage= "Required")]
        [MinLength(2)]
        [Display(Name= "Coordinator")]
        public string Coordinator {get; set;}


        [Required(ErrorMessage= "Required")]
        [Display(Name= "Duration")]
        public string Duration {get; set;}

        public int UserId {get; set;}
        public int ActivityId {get; set;}
    }
    
}