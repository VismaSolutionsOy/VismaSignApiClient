﻿using System.Net.Http;

namespace Visma.Sign.Api.Client.Resources.V1
{
    public sealed class GetDocumentFile : ResourceBase
    {
        public static GetDocumentFile FromDocument(string uuid, int order)
            => new GetDocumentFile(uuid, order);

        private GetDocumentFile(string uuid, int order)
            : base($"api/v1/document/{UrlEncode(uuid)}/files/{order}", HttpMethod.Get)
        {}

    }
}
