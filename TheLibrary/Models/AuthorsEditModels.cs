using System.Collections.Generic;
using System.Web.Mvc;

namespace FrontEnd.Models
{
    public class AuthorEditModels
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }

        public string State { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }

        public bool IsAlive { get; set; }
    }

}