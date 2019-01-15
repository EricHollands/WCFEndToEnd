﻿
using GeoLib.Contracts;
using GeoLib.Data;
using GeoLib.Services;
using NSubstitute;
using NUnit.Framework;


namespace GeoLib.Tests
{
    [TestFixture]
    public class ManagerTests
    {
        [Test]
        public void test_zip_code_retrieval()
        {

            ZipCode zipCode = new ZipCode()
            {
                City = "LINCOLN PARK",
                State = new State() { Abbreviation = "NJ" },
                Zip = "07035"
            };

            var mockZipCodeRepository = Substitute.For<IZipCodeRepository>();
            mockZipCodeRepository.GetByZip("07035").Returns(zipCode);

            IGeoService geoService = new GeoManager(mockZipCodeRepository);

            ZipCodeData data = geoService.GetZipCodeInfo("07035");

            Assert.That(zipCode.City.ToUpper(), Is.EqualTo("LINCOLN PARK"));
            Assert.That(zipCode.State.Abbreviation, Is.EqualTo("NJ"));
            Assert.That(zipCode.Zip, Is.EqualTo("07035"));
            
        }

    }
}
