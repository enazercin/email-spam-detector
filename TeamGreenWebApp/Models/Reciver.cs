using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamGreenWebApp.Models
{
    public class Reciver
    {
        public Reciver()
        {
            Mail = new Collection<Mail>();
        }

        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string MailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive  { get; set; }
        public ICollection<Mail> Mail { get; set; }
    }
}
