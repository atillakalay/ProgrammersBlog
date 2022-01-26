using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results.ComplexTypes;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get;  }
        public Exception Exception { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
