namespace Visma.Sign.Api.Client.Dtos
{
    public class DocumentAffiliateDto
    {
        public string code { get; set; }

        public DocumentAffiliateDto(string code)
        {
            this.code = code;
        }
    }
}
