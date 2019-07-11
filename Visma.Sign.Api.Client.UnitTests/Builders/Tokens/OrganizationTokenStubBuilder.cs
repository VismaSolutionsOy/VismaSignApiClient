using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Visma.Sign.Api.Client.Tokens;

namespace Visma.Sign.Api.Client.UnitTests.Builders.Tokens
{
    sealed class OrganizationTokenStubBuilder
    {
        private string m_get = "";
        private List<string> m_getInOrder = new List<string>();

        public OrganizationTokenStubBuilder WithGet(string value)
        {
            m_get = value;
            return this;
        }

        public OrganizationTokenStubBuilder WithGetInOrder(params string[] value)
        {
            m_getInOrder.AddRange(value);
            return this;
        }

        public IOrganizationToken Build()
        {
            var stub = Substitute.For<IOrganizationToken>();

            if (m_getInOrder.Any())
            {
                stub.Get(Arg.Any<string>()).Returns(m_getInOrder.First(), m_getInOrder.Skip(1).ToArray());
            }
            else
            {
                stub.Get(Arg.Any<string>()).Returns(m_get);
            }

            return stub;
        }
    }
}
