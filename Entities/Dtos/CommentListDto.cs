using System.Collections.Generic;
using Entities.Concrete;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CommentListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}
