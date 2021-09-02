using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        public string TagName { get; set; }
        //Navigation property
        //public User User { get;set; }
    }
}
