﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Visma.Sign.Api.Client.Settings;

namespace Visma.Sign.Api.Client
{
    public sealed class OrganizationApiRequest : IApiRequest
    {
        private readonly ICredentials m_credentials;
        private readonly IEndpoint m_endpoint;
        private readonly ITimeProvider m_time;
        private readonly HashAlgorithm m_macHash;
        private readonly HashAlgorithm m_contentHash;

        public OrganizationApiRequest(ICredentials credentials, IEndpoint endpoint, ITimeProvider time)
        {
            m_credentials = credentials;
            m_endpoint = endpoint;
            m_time = time;
            m_macHash = new HMACSHA512(Convert.FromBase64String(credentials.Secret()));
            m_contentHash = new MD5CryptoServiceProvider();
        }


        public Task<HttpRequestMessage> Create(ResourceBase value) 
            => CreateRequest(value);


        private async Task<HttpRequestMessage> CreateRequest(ResourceBase value)
        {
            var request = new HttpRequestMessage(value.Method, m_endpoint.Uri() + value.ResourceUri);

            if (value.Content != null)
            {
                request.Content = value.Content;
                request.Content.Headers.ContentMD5 = m_contentHash.ComputeHash(await value.Content.ReadAsByteArrayAsync());
            }

            request.Headers.Date = m_time.UtcNow();
            request.Headers.Authorization = CreateAuthorization(value, request);

            return request;
        }

        private AuthenticationHeaderValue CreateAuthorization(ResourceBase value, HttpRequestMessage request) 
            => new AuthenticationHeaderValue(
                "Onnistuu",
                m_credentials.Identifier() + ":" +
                Convert.ToBase64String(
                    m_macHash.ComputeHash(
                        Encoding.UTF8.GetBytes(
                            string.Join(
                                "\n",
                                request.Method.ToString(),
                                Base64Content(request.Content), 
                                ContentType(request.Content),
                                GetRequestTime(request), 
                                "/" + value.ResourceUri)
                        )
                    )
                )
            );

        private string Base64Content(HttpContent content)
            => Convert.ToBase64String(
                content != null
                    ? content.Headers.ContentMD5
                    : m_contentHash.ComputeHash(new byte[] { }));

        private static string ContentType(HttpContent content)
            => content != null
                ? content.Headers.ContentType.ToString()
                : "";

        private string GetRequestTime(HttpRequestMessage request)
            => request.Headers.Date.GetValueOrDefault(m_time.UtcNow()).ToString("r");
    }
}
