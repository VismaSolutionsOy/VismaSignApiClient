using System;
using NUnit.Framework;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;

namespace Visma.Sign.Api.Client.UnitTests.Dtos
{
    [TestFixture]
    class LocationDtoTests
    {
        [Test]
        public void AskingLocation_WithGivenUri_IsSame()
        {
            var expected = new Uri("https://vismasign.fi/");
            var sut = new LocationDtoBuilder().WithLocation(expected).Build();

            var actual = sut.Location;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("https://sign.visma.net/api/v1/document/", "api/v1/document/")]
        [TestCase("https://sign.visma.net/api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a/cancel", "api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a/cancel")]
        [TestCase("https://sign.visma.net", "")]
        public void AskingResource_WithGivenUrl_IsExpected(string uri, string expected)
        {
            var sut = new LocationDtoBuilder().WithLocation(uri).Build();

            var actual = sut.Resource;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AskingUuid_WithoutLocationContaining_IsEmpty()
        {
            var sut = new LocationDtoBuilder().WithLocation("https://sign.visma.net/").Build();

            var actual = sut.Uuid;

            Assert.AreEqual("", actual);
        }

        [Test]
        public void AskingUuid_WithUuidBeingLastPartOfUri_IsExpected()
        {
            var sut = new LocationDtoBuilder().WithLocation("https://sign.visma.net/api/v1/category/e59c8dc8-8848-4936-ac7c-50d9ed72085a").Build();

            var actual = sut.Uuid;

            Assert.AreEqual("e59c8dc8-8848-4936-ac7c-50d9ed72085a", actual);
        }

        [Test]
        public void AskingUuid_WithUuidBeingInTheMiddleOfUri_IsExpected()
        {
            var sut = new LocationDtoBuilder().WithLocation("https://sign.visma.net/api/v1/invitation/2076243e-351d-4b29-86ad-c2b02d7f867d/signature").Build();

            var actual = sut.Uuid;

            Assert.AreEqual("2076243e-351d-4b29-86ad-c2b02d7f867d", actual);
        }

        [Test]
        public void AskingUuid_WithoutUuidBeingDefined_IsExpected()
        {
            var sut = new LocationDtoBuilder().WithLocation("https://sign.visma.net/api/v1/document/").Build();

            var actual = sut.Uuid;

            Assert.AreEqual("", actual);
        }
    }
}
