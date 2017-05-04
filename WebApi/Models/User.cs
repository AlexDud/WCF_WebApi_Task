﻿namespace WebApi.Models
{
    public class User
    {
        public User()
        {
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}