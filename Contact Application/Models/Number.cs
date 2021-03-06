using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact_Application.Models
{
    public class Number
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumberID { get; set; }
        public string PhoneNumber { get; set; }
        //Navigation property
        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }
        public int ContactID { get; set; }
    }
}