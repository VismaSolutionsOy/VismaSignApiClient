using System.Runtime.Serialization;

namespace Visma.Sign.Api.Client.Dtos
{
    public enum Language
    {
        [EnumMember(Value = LanguageString.Finnish)]
        Finnish,
        [EnumMember(Value = LanguageString.English)]
        English,
        [EnumMember(Value = LanguageString.Swedish)]
        Swedish,
        [EnumMember(Value = LanguageString.Norwegian)]
        Norwegian,
        [EnumMember(Value = LanguageString.Danish)]
        Danish
    }

    internal static class LanguageString
    {
        internal const string Finnish = "fi";
        internal const string English = "en";
        internal const string Swedish = "sv";
        internal const string Norwegian = "nb";
        internal const string Danish = "da";
        
        internal static string Get(Language value)
        {
            switch (value)
            {
                case Language.Finnish:
                    return Finnish;

                case Language.English:
                    return English;

                case Language.Swedish:
                    return Swedish;

                case Language.Norwegian:
                    return Norwegian;
                    
                case Language.Danish:
                    return Danish;
                    
                default:
                    return "";
            }
        }
    }
}
