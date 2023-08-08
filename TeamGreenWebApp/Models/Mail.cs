using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamGreenWebApp.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string MailHeader { get; set; }
        public string MailContent { get; set; }
        public virtual User User { get; set; }
        public virtual Reciver Reciver { get; set; }

        [ForeignKey("ReciverId")]
        public int ReciverId { get; set; }
        public bool IsSpam { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int? UserId { get; set; }

    }
}
