using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Swiks.API.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected ActionResult<string> AddErrors(ICollection<ValidationFailure> errors)
        {
            var errorList = new List<string>();

            foreach (var error in errors) errorList.Add(error.ErrorMessage);

            return BadRequest(errorList);
        }
    }
}
