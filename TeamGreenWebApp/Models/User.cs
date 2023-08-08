using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamGreenWebApp.Models
{
    public class User
    {
        public User()
        {
            Mail = new Collection<Mail>();
            Reciver = new Collection<Reciver>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Mail> Mail { get; set; }
        public ICollection<Reciver> Reciver { get; set; }

    }
}
