using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Pokemon_Uebung
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string URL { get; set; }
        
        public PokemonDetail Details { get; set; }  
        
      
    }

    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


    public class PokemonDetail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("abilities")]
        public List<Ability> Abilities { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        [JsonPropertyName("sprites")]
        public Sprite Sprites { get; set; }

    }

    public class Sprite
    {
        [JsonPropertyName("front_default")]
        public Uri Front_default { get; set; }
        [JsonPropertyName("back_default")]
        public Uri Back_default { get; set; }
    }

}
