namespace Visma.Sign.Api.Client.UnitTests.Builders
{
    sealed class ApiResponseBuilder
    {
        private IHttpClient m_client = new HttpClientStubBuilder().Build();

        public ApiResponseBuilder WithClient(IHttpClient value)
        {
            m_client = value;
            return this;
        }

        public ApiResponse Build()
            => new ApiResponse(m_client);
    }
}
