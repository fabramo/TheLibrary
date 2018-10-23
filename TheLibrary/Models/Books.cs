using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace FrontEnd.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter title")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "5 < length < 10")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter author")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "5 < length < 10")]
        public string Author { get; set; }
    }

    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}