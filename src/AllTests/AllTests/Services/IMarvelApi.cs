using AllTests.Configs;
using AllTests.Models;
using Refit;
using System.Threading.Tasks;

namespace AllTests.Services {

    public interface IMarvelApi {

        [Get("/characters?ts={config.Ts}&apikey={config.ApiPublicKey}&hash={config.Hash}&offset={offset}&limit={limit}")]
        Task<ApiResponse<MarvelApiResponse<Character>>> GetAllCharacters(MarvelApiConfig config, int offset = 0, int limit = 20);

        [Get("/characters/{characrterId}?ts={config.Ts}&apikey={config.ApiPublicKey}&hash={config.Hash}&offset={offset}&limit={limit}")]
        Task<ApiResponse<MarvelApiResponse<Character>>> GetCharacter(MarvelApiConfig config, int characrterId, int offset = 0, int limit = 20);

    }

}
