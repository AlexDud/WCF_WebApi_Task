namespace WebApi.Models
{
    using System.Collections.Generic;

    public class Company
    {
        public Company()
        {
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}