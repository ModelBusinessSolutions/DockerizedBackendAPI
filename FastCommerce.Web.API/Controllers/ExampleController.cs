using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using App.Business.DTOs;
using App.Business.ExampleManager.Concrete;
using App.Web.API.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        public IExampleManager _exampleManager { get; set; }
        public ExampleController(IExampleManager exampleManager)
        {
            _exampleManager = exampleManager;
        }


        [HttpGet("getExampleValue")]
        public async Task<HttpResponseMessage> getExampleValue()
        {
            Response<ExampleDto> httpResponse = new Response<ExampleDto>();
            try
            {
                httpResponse.RequestState = true;
                httpResponse.ErrorState =  _exampleManager.getExampleValue();
            }
            catch (Exception ex)
            {
                httpResponse.ErrorState = true;
                httpResponse.ErrorList.Add(ex.Adapt<ApiException>());
            }
            return httpResponse;
        }

    }
}
