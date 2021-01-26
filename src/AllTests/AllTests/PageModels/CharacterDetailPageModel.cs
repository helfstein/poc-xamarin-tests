using AllTests.Configs;
using AllTests.Models;
using AllTests.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AllTests.PageModels {
    [QueryProperty(nameof(CharacterId), nameof(CharacterId))]
    public class CharacterDetailPageModel : BasePageViewModel {

        private int _characterId;
        private Character _character;

        public int CharacterId {
            get => _characterId;
            set {
                SetProperty(ref _characterId, value);
                LoadData(value).ConfigureAwait(false);
            }
        }

        public Character Character { 
            get => _character; 
            set => SetProperty(ref _character, value);
        }                

        private async Task LoadData(int characterId) {
            if (IsBusy) return;
            IsBusy = true;
            try {

                var apiConfig = MarvelApiConfig.GetRequestConfig();
                var ret = await RestService.For<IMarvelApi>(MarvelApiConfig.ApiBaseUrl).GetCharacter(apiConfig, characterId);
                List<Character> characters;

                if (ret.IsSuccessStatusCode) {
                    characters = ret.Content.Data.Results;
                    Character = characters.FirstOrDefault();
                    Title = Character.Name;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
        }

    }
}
