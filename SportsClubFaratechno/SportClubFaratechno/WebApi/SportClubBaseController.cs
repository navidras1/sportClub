using Microsoft.AspNetCore.Mvc;
using SportClubFaratechno.Models;
using SportClubFaratechno.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SportClubFaratechno.WebApi
{
    public class SportClubBaseController : ControllerBase
    {
        protected SportClubProcedures SCP { get; set; } = TheServiceProvider.Instance.GetService<SportClubProcedures>();

    }
}
