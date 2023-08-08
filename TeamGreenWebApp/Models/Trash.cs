using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamGreenWebApp.Models
{
    public class Trash
    {
        public int Id { get; set; }
        public virtual Mail Mail { get; set; }
        public int MailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
