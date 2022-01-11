﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenOnion.Server.DataLayer.DomainModels
{
    public class User
    {
        public User(/*string name, string password*/)
        {
            //this.name = name;
            //this.password = password;
        }

        [Key]
        [Required]
        private string userId;

        public string projectId { get; set; }

        public string companyId { get; set; }

        private List<Ticket> tickets;

        [Required]
        private string username;

        [Required]
        private string firstName;

        private string lastName;
        private string aboutMe;

        [Required]
        private string password;

        public string UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string AboutMe { get => aboutMe; set => aboutMe = value; }
        public string Password { get => password; set => password = value; }
        public List<Ticket> Tickets { get => tickets; set => tickets = value; }
    }
}
