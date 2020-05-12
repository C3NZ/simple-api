using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sample_api.Models 
{
    public class User 
    {
        public long ID { get; set; }

        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
