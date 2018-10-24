using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class BookEditModel
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Please enter title")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "5 < length < 10")]
        public string Title { get; set; }

        public string[] SelectedAuthors { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }

}