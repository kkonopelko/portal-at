using Portal.Automation.Api.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portal.Automation.Api.Clients
{
    public class HpClient : BaseClient
    {
        public async Task<RestResponse<List<Character>>> GetAllCharactersAsync()
        {
            var request = new RestRequest(ApiUrl.AllCharactersApiUrl);

            return await ExecuteAsync<List<Character>>(request);
        }

        public async Task<RestResponse<List<Character>>> GetCharacterByIdAsync(Guid id)
        {
            var request = new RestRequest(ApiUrl.CharacterByIdApiUrl(id));

            return await ExecuteAsync<List<Character>>(request);
        }

        public async Task<RestResponse<List<Spell>>> GetSpellsAsync()
        {
            var request = new RestRequest(ApiUrl.SpellsApiUrl);

            return await ExecuteAsync<List<Spell>>(request);
        }
    }
}
