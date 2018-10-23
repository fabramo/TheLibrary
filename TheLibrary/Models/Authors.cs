using System.Data.Entity;

namespace FrontEnd.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public bool IsAlive { get; set; }
    }

}