using System;
using SQLite;

namespace SpectTest.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        private int ID { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
