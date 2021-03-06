using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class User : BaseEntity {
        public int UserId {get; set;}
        public string first_name {get; set;}
        public string last_name {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}
        
        [InverseProperty("Guest")]
        public List<GuestConnection> ActivitiesAttending {get; set;}

        public User(){
            ActivitiesAttending = new List<GuestConnection>();
        }
    }
    
}