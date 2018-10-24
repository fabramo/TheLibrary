using System.Collections.Generic;

namespace FrontEnd.ViewModels
{
    public class BookViewModel
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public List<string> Authors { get; set; }

        public BookViewModel(string id, string title)
        {
            ID = id;
            Title = title;
            Authors = new List<string>();
        }
    }
}