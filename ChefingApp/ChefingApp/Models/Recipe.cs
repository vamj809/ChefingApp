using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace ChefingApp.Models
{
    public class RecipeItem
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class RecipeHits
    {
        [JsonPropertyName("recipe")]
        public RecipeItem Recipe { get; set; }
    }

    public class RecipeSearchResults
    {
        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("hits")]
        public ObservableCollection<RecipeHits> Hits { get; set; }
    }
}
