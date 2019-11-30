using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Tindyr.Controllers
{
    //we have mediatr as a 'built-in' variable of any controller that inherits from BaseController so we dont ask for this dependency all the time from the project :)
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
