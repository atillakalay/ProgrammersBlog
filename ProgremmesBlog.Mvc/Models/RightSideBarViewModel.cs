using System.Collections.Generic;
using Entities.Concrete;

namespace ProgrammersBlog.Mvc.Models
{
    public class RightSideBarViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
