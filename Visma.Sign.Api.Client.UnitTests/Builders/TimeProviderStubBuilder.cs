using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;

namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class TimeProviderStubBuilder
    {
        private DateTime m_utcNow = new DateTime(2000, 1, 1);
        private List<DateTime> m_utcNowInOrder = new List<DateTime>();

        public TimeProviderStubBuilder WithUtcNow(int year, int month, int day)
            => WithUtcNow(new DateTime(year, month, day));

        public TimeProviderStubBuilder WithUtcNow(DateTime value)
        {
            m_utcNow = value;
            return this;
        }

        public TimeProviderStubBuilder WithUtcNowInOrder(params DateTime[] value)
        {
            m_utcNowInOrder.AddRange(value);
            return this;
        }

        public ITimeProvider Build()
        {
            var stub = Substitute.For<ITimeProvider>();

            if (m_utcNowInOrder.Any())
            {
                stub.UtcNow().Returns(m_utcNowInOrder.First(), m_utcNowInOrder.Skip(1).ToArray());
            }
            else
            {
                stub.UtcNow().Returns(m_utcNow);
            }

            return stub;
        }
    }
}
