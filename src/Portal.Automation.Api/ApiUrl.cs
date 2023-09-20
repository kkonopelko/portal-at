using System;

namespace Portal.Automation.Api
{
    public class ApiUrl
    {
        public static string AllCharactersApiUrl => $"{BaseApiUrl}/characters";

        public static string SpellsApiUrl => $"{BaseApiUrl}/spells";

        public static string CharacterByIdApiUrl(Guid id) => $"{BaseApiUrl}/character/{id}";

        public static string BaseApiUrl => "https://hp-api.onrender.com/api";
    }
}
