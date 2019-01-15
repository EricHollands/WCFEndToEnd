using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeoLib.Data;
using System;

namespace GeoLib.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void test_zip_code_retrieval()
        {

            IMock<IZipCodeRepository> mockZipCodeRepository = new Mock<IZipCodeRepository>();

            ZipCode zipCode = new ZipCode()
            {
                City = "LINCOLN PARK",
                State = new State() { Abbreviation = "NJ" },
                Zip = "07035"
            };

            //mockZipCodeRepository.Object.Add(zipCode);
            //mockZipCodeRepository.Object.get


        }

    }
}
