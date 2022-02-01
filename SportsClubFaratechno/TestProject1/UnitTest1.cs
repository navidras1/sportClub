using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SportClubFaratechno.Models.Repository.SportClubProcedures sportClubProcedures = new SportClubFaratechno.Models.Repository.SportClubProcedures();
            var res = sportClubProcedures.GetListofSporsBySalonId(new SportClubFaratechno.Models.GetListofSporsBySalonIdModel { SalonId = 1 });
            var a = 2;
            Assert.Pass();
        }
    }
}