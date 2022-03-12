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
        private static IServiceProvider instance;

        public static IServiceProvider Instance { 
            get { 
                return instance.CreateScope().ServiceProvider;
            } 
            set {
                instance = value;
            } 
        }


        //public static IServiceProvider ScopedInstance
        //{
        //    get
        //    {
        //        return Instance.CreateScope().ServiceProvider;
        //    }
        //}
    }

    public static class SportClubReposDI<T> where T : class
    {
        public static IGenericRepository<T> OBJ
        {
            get
            {

                //var ss= TheServiceProvider.Instance.CreateScope();
                return TheServiceProvider.Instance.GetService<IGenericRepository<T>>();
            }
        }
    }
}
