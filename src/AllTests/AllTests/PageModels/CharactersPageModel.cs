using AllTests.Configs;
using AllTests.Models;
using AllTests.Pages;
using AllTests.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllTests.PageModels {
    public class CharactersPageModel : BasePageViewModel {

        private List<Character> _lstCharacters;
        private int _offset = 0;
        private const int _limit = 100;
        private ObservableCollection<Character> _characters;
        private bool _isLoadMoreAvaliable;
        private bool _isRefreshing;

        public bool IsRefreshing { 
            get => _isRefreshing; 
            set => SetProperty(ref _isRefreshing, value);
        }

        public bool IsLoadMoreAvaliable {
            get => _isLoadMoreAvaliable;
            set => SetProperty(ref _isLoadMoreAvaliable, value);
        }

        public ICommand LoadMoreCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SelectedItemCommand { get; set; }

        public ObservableCollection<Character> Characters {
            get => _characters;
            set => SetProperty(ref _characters, value);
        }

        public CharactersPageModel() {
            Characters = new ObservableCollection<Character>();
            RefreshCommand = new Command(OnRefreshCommand);
            LoadMoreCommand = new Command(OnLoadMoreCommand);
            SelectedItemCommand = new Command<Character>(OnSelectedItemCommand);
        }

        private async void OnSelectedItemCommand(Character character) {
            if (IsBusy) return;
            IsBusy = true;
            try {
                if (character == null)
                    return;
                
                await Shell.Current.GoToAsync($"{nameof(CharacterDetailPage)}?{nameof(CharacterDetailPageModel.CharacterId)}={character.Id}");
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
        }

        private async void OnLoadMoreCommand() {
            if (IsBusy) return;
            IsBusy = true;
            try {
                _offset = Characters.Count;               
                await LoadData(true).ConfigureAwait(false);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
        }

        private async void OnRefreshCommand() {
            
            try {
                await LoadData().ConfigureAwait(false);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                IsRefreshing = false;
            }
        }

        private async Task LoadData(bool loadMore = false) {                 

            var apiConfig = MarvelApiConfig.GetRequestConfig();
            var ret = await RestService.For<IMarvelApi>(MarvelApiConfig.ApiBaseUrl).GetAllCharacters(apiConfig, _offset, _limit);
            List<Character> characters;
            
            if (ret.IsSuccessStatusCode) {
                characters = ret.Content.Data.Results;
                if (!loadMore) {
                    _lstCharacters = ret.Content.Data.Results;
                    Characters = new ObservableCollection<Character>(_lstCharacters);                    
                }
                else {
                    _lstCharacters.AddRange(ret.Content.Data.Results);
                    characters.ForEach(c => Characters.Add(c));
                }
                
                var canLoadMore = ret.Content.Data.Total > Characters.Count;
                IsLoadMoreAvaliable = canLoadMore;
                
            }

        }


        public override async Task OnAppearing() {
            if (Characters.Any()) return;
            if (IsBusy) return;
            IsBusy = true;
            try {
                await LoadData().ConfigureAwait(false);
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
