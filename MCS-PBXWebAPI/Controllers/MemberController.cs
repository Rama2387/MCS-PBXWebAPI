using AuthenticationApi.Dtos;
using MCS_PBXWebAPI.Models;
using MCSBusinessLayer;
using MCSDataLayer;
using MCSWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Text.Json.Serialization;


namespace MCSWeb.Controllers
{
    
    public class MemberController : ControllerBase
    {
        private readonly MemberBO memberBO;
        public MemberController()
        {
            memberBO = new MemberBO();
            //memberBO = _memberBO;
        }
        [AllowAnonymous]
        [HttpPost("getallmembers")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllMembers([FromBody] PBXMessage message)
        {
           // string sunsiteid=message.ttPBXMessTop
            IActionResult response = Unauthorized();    
            return response;

        }
        // GET: MemberController
        //public ActionResult Index()
        //{

        //   // int a = Convert.ToInt32("a");
        //    return View();
        //}
        //public IHttpActionResult GetAllMembers()
        //{
        //    var lstMembers = memberBO.GetAllMembers(SqlQueries.GET_ALL_MEMBERS);
        //    return lstMembers
        //}

        // GET: MemberController/Details/5

        //public HttpResponseMessage GetAllMembers()
        //{
        //    var res = memberBO.GetAllMembers(SqlQueries.GET_ALL_MEMBERS);
        //    //return Ok(JsonConvert.SerializeObject(res, Formatting.Indented, new DataTableConverter()));
        //    return Request.CreateResponse(HttpStatusCode.OK, res);
        //}

        // GET: MemberController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: MemberController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: MemberController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: MemberController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: MemberController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: MemberController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
