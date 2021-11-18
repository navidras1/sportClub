using SportClubFaratechno.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SportClubFaratechno.Models.SportClubFaratechnoDB;

namespace SportClubFaratechno.Models
{
    public static class TheServiceProvider
    {
        public static IServiceProvider Instance { get; set; }
    }

    public static class SportClubReposDI<T> where T : class
    {
        public static IGenericRepository<T> OBJ
        {
            get
            {
                return TheServiceProvider.Instance.GetService<IGenericRepository<T>>();
            }
        }
    }
}
