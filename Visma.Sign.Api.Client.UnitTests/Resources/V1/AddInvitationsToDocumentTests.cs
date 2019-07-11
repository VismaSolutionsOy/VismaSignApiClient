using System.Net.Http;
using NUnit.Framework;
using Visma.Sign.Api.Client.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Dtos;
using Visma.Sign.Api.Client.UnitTests.Builders.Resources.V1;

namespace Visma.Sign.Api.Client.UnitTests.Resources.V1
{
    [TestFixture]
    class AddInvitationsToDocumentTests
    {
        [Test]
        public void AddingInvitations_WithGivenLocation_SetsUriCorrectly()
        {
            var sut = new AddInvitationsToDocumentBuilder()
                .WithLocation(new LocationDtoBuilder().WithLocation("https://sign.visma.net/api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a/"))
                .Build();

            var actual = sut.ResourceUri;

            Assert.AreEqual("api/v1/document/e59c8dc8-8848-4936-ac7c-50d9ed72085a/invitations", actual);
        }

        [Test]
        public void AddingInvitations_WithHttpMethod_IsExpected()
        {
            var sut = new AddInvitationsToDocumentBuilder().Build();

            var actual = sut.Method;

            Assert.AreEqual(HttpMethod.Post, actual);
        }

        [Test]
        public void AddingInvitations_WithInvitation_SetsContentCorrectly()
        {
            var sut = new AddInvitationsToDocumentBuilder()
                .WithInvitation(new InvitationDtoBuilder()
                    .WithEmail("test@visma.com")
                    .WithUserName("Test User")
                    .WithLanguage(Language.English)
                    .WithSignature(SignatureType.Strong)
                    .WithSignAsOrganization(false))
                .Build();

            var content = (StringContent)sut.Content;

            var actualContent = content.ReadAsStringAsync().Result;
            Assert.AreEqual("[{\"email\":\"test@visma.com\",\"signature_type\":\"strong\",\"name\":\"Test User\",\"sign_as_organization\":false,\"language\":\"en\"}]", actualContent);
            Assert.AreEqual("application/json; charset=utf-8", content.Headers.ContentType.ToString());
        }

        [Test]
        public void AddingInvitations_WithInvitationMessages_SetsContentCorrectly()
        {
            var sut = new AddInvitationsToDocumentBuilder()
                .WithInvitation(new InvitationDtoBuilder()
                    .WithLanguage(Language.Finnish)
                    .WithSignature(SignatureType.Hand)
                    .WithMessages(new InvitationMessageDto() {custom_sms = "sms", send_invitation_sms = true, separate_invite_parts = false}))
                .Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(
                "[{\"signature_type\":\"hand\",\"language\":\"fi\",\"messages\":{\"send_invitation_sms\":true,\"custom_sms\":\"sms\",\"separate_invite_parts\":false}}]",
                actual);
        }

        [Test]
        public void AddingInvitations_WithInvitationInviter_SetsContentCorrectly()
        {
            var sut = new AddInvitationsToDocumentBuilder()
                .WithInvitation(new InvitationDtoBuilder()
                    .WithLanguage(Language.Finnish)
                    .WithSignature(SignatureType.Hand)
                    .WithInviter(new InvitationInviterDto() {email = "john@visma.com", language = Language.Norwegian}))
                .Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(
                "[{\"signature_type\":\"hand\",\"language\":\"fi\",\"inviter\":{\"email\":\"john@visma.com\",\"language\":\"nb\"}}]", 
                actual);
        }

        [Test]
        public void AddingInvitations_WithInvitationOrder_SetsContentCorrectly()
        {
            var sut = new AddInvitationsToDocumentBuilder()
                .WithInvitation(new InvitationDtoBuilder()
                    .WithLanguage(Language.Swedish)
                    .WithSignature(SignatureType.Hand)
                    .WithOrder(new InvitationOrderDto() {require_before_sending_next_invitations = true}))
                .Build();

            var actual = sut.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(
                "[{\"signature_type\":\"hand\",\"language\":\"sv\",\"order\":{\"require_before_sending_next_invitations\":true}}]",
                actual);
        }
    }
}
