using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GS.DataBase.Entities
{
    public class User
    {
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
