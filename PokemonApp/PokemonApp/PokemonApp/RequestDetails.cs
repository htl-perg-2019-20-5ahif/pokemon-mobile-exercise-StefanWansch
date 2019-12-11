
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Xamarin.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Pokemon_Uebung
{

    public class RequestDetails
    {
        
        public RequestDetails()
        {

        }



        public async Task<Pokemons> LoadPokemonsIntoList()
        {
            HttpClient HttpClient = new HttpClient() { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };
            var pokemonResponse = await HttpClient.GetAsync("pokemon");
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody);
            pokemons.Results.ForEach(p => Console.WriteLine(p.Name));
            return pokemons;
        }

        public async Task<Pokemons> LoadDetailsIntoList(Pokemons p)
        {
            HttpClient HttpClient = new HttpClient();

            for (int i = 0; i < p.Results.Count; i++)
            {
                var pokemonResponse = await HttpClient.GetAsync(p.Results[i].URL);
                pokemonResponse.EnsureSuccessStatusCode();
                string responseBody = await pokemonResponse.Content.ReadAsStringAsync();
                p.Results[i].Details = JsonSerializer.Deserialize<PokemonDetail>(responseBody);
                Console.WriteLine(p.Results[i].Details.Name);
            } 
            return p;

        }

        

    }
}
