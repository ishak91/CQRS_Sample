using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Web.CustomerFeature.AddCutomerCommand;
using static Web.CustomerFeature.GetAllCustomerQuery;
using static Web.CustomerFeature.GetCustomerQuery;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var resposne= await _mediator.Send(new GetAllCustomerRequest());
            return View(resposne);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCutomerRequest addCutomer)
        {
             await _mediator.Send(addCutomer);
            return RedirectToAction("Index");
        }

        [HttpGet("id")]
        public async Task<IActionResult> ViewCustomer(int id)
        {
            var response= await _mediator.Send(new GetCustomerRequest {
                Id=id
            });
            return View(response);
        }
    }
}