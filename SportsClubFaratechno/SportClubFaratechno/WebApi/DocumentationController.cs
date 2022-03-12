using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SportClubFaratechno.ComponentsLibrary;
using SportClubFaratechno.Models;
using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportClubFaratechno.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiExplorer;
        public DocumentationController(IApiDescriptionGroupCollectionProvider apiExplorer)
        {
            _apiExplorer = apiExplorer;
        }

        [HttpPost("Index")]
        public IActionResult Index()
        {
            //var res = _apiExplorer.ApiDescriptionGroups.Items.Select(pp=>new { pp.GroupName}).ToList();
            var res = _apiExplorer.ApiDescriptionGroups.Items[0].Items.Select(pp => pp.RelativePath).ToList();

            var AccessRepos = SportClubReposDI<Access>.OBJ;

            foreach (var i in res)
            {
                if(!AccessRepos.Find(pp=> pp.WebApiAddress.Contains(i)).Any())
                {
                    AccessRepos.Add(new Access {Name=i, SubmissionDate=DateTime.Now , SubmissionDateShamsi= PersianDate.NowGetWithSlash, WebApiAddress=i });
                }
            }
            


            return Ok(res);
        }
    }
}
