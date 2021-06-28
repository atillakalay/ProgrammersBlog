using Core.Utilities.Results.ComplexTypes;

namespace Core.Entities.Abstract
{
   public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
