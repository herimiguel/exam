using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class Activity : BaseEntity{
        
        public int ActivityId {get; set;}
        public int UserId {get; set;}
        public string Title {get; set;}
        public DateTime Date {get; set;}

        public string Coordinator {get; set;}
        public string Description {get; set;}
        public string Time {get; set; }

        public string Duration {get; set;}

        [InverseProperty("Activity")]
        public List<GuestConnection> Guests {get; set;}
        public Activity(){
            Guests = new List<GuestConnection>();
        }
    }
    
}