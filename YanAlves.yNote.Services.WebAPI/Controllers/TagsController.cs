using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YanAlves.yNote.Application.Interfaces;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Services.WebAPI.Controllers
{
    [RoutePrefix("v1/Tags")]
    public class TagsController : ApiController
    {
        private readonly ITagAppService _tagAppService;
        public TagsController(ITagAppService tagAppService)
        {
            this._tagAppService = tagAppService;
        }

        [HttpGet]
        [Route("ObterTags")]
        public HttpResponseMessage ObterTags()
        {
            var statusCode = HttpStatusCode.OK;
            var tags = Mapper.Map<ICollection<Tag>>(this._tagAppService.ObterTodos());

            return Request.CreateResponse(statusCode, tags);
        }
    }
}