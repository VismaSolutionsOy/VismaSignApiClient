using System;
using System.Collections.Generic;
using System.Text;

namespace Visma.Sign.Api.Client.Dtos
{
    public class DocumentDto
    {
        public string name { get; set; }
        public string category_uuid { get; set; }
        public string category { get; set; }
        public string invitations_valid_until { get; set; }
        public List<DocumentAffiliateDto> affiliates { get; set; }

        public DocumentDto(string name)
        {
            this.name = name;
        }

        public void SetValidUntil(DateTime? value) 
            => invitations_valid_until = value?.ToString("yyyy-MM-dd");

        public void AddAffiliate(string code)
        {
            if (affiliates == null)
            {
                affiliates = new List<DocumentAffiliateDto>();
            }

            affiliates.Add(new DocumentAffiliateDto(code));
        }
    }
}
