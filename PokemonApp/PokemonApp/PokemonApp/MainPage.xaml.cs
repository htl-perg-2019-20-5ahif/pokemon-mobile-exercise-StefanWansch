using Pokemon_Uebung;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Pokemon> pokemons = new ObservableCollection<Pokemon>();
        public ObservableCollection<Pokemon> Pokemons { get { return pokemons; } }
        public RequestDetails rq = new RequestDetails();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public async void GetPokemons (){
            pokemons.Clear();
            var pokemon = await rq.LoadPokemonsIntoList();
            
            pokemon = await rq.LoadDetailsIntoList(pokemon);
            foreach (var result in pokemon.Results)
            {
                pokemons.Add(result);
                Console.WriteLine(result.Details.Sprites.Front_default.ToString());
            }
            
            PokemonView.ItemsSource = pokemons;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GetPokemons();
        }

        private async void PokemonView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item!=null)
            {
                var pokemon1 = e.Item as Pokemon;
                
                await Navigation.PushModalAsync(new DetailsPage(pokemon1.Details));
            }
            



        }
    }
}
