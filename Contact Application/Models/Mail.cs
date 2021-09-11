using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact_Application.Models
{
    public class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MailID { get; set; }
        public string MailAddress { get; set; }

        //Navigation property
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }

    }
}
