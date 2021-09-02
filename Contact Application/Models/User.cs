﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        //barem neki podatak ce biti u bazi i onda kasnije preko edita se moze dodati ostalo
        //[Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //Navigation property
        public int TagID { get; set; }
        [ForeignKey("TagID")]
        public Tag Tag{get; set;}
        public IList<Number> Number{get; set;}
        public IList<Mail> Mail{ get; set; }
       
    }
}
