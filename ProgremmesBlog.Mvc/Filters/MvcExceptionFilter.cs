using System;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;

namespace ProgrammersBlog.Mvc.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IModelMetadataProvider _metadataProvider;

        public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                context.ExceptionHandled = true;
                var mvcErrorModel = new MvcErrorModel
                {
                    Message = $"Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu. Sorunu en kısa sürede çözeceğiz."
                };
                var result = new ViewResult { ViewName = "Error" };
                result.StatusCode = 500;
                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
                result.ViewData.Add("MvcErrorModel",mvcErrorModel);
                context.Result = result;
            }
        }
    }
}
