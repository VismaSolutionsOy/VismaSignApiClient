namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class SignClientBuilder
    {
        private IApiRequest m_request = new ApiRequestStubBuilder().Build();
        private IApiResponse m_response = new ApiResponseStubBuilder<object>().Build();

        public SignClientBuilder WithRequest(IApiRequest value)
        {
            m_request = value;
            return this;
        }

        public SignClientBuilder WithResponse(IApiResponse value)
        {
            m_response = value;
            return this;
        }

        public SignClient Build()
            => new SignClient(m_request, m_response);
    }
}
