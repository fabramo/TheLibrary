using System.Collections.Generic;
using System.Web.Mvc;

namespace FrontEnd.ViewModels
{
    public class AuthorViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string State { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}