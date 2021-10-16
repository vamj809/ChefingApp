using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using ChefingApp.Helpers;

namespace ChefingApp.Models
{
    public class Recipe
    {
        public static ObservableCollection<RecipeCategory> MealTypes = new ObservableCollection<RecipeCategory>() {
            new RecipeCategory("Breakfast"),
            new RecipeCategory("Lunch"),
            new RecipeCategory("Dinner"),
            new RecipeCategory("Snack"),
            new RecipeCategory("Teatime"),
            new RecipeCategory("More...",null,true)
        };

        public static ObservableCollection<RecipeCategory> DishTypes = new ObservableCollection<RecipeCategory>() {
            new RecipeCategory("Category 0"),
            new RecipeCategory("Category 1"),
            new RecipeCategory("Category 2"),
            new RecipeCategory("Category 3"),
            new RecipeCategory("Category 4"),
            new RecipeCategory("Category 5"),
            new RecipeCategory("Category 6"),
            new RecipeCategory("Category 7"),
            new RecipeCategory("Category 8"),
            new RecipeCategory("Category 9")
        };
    }

    public class RecipeItem
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("ingredientLines")]
        public string[] Ingredients { get; set; }

        [JsonPropertyName("calories")]
        public decimal Calories { get; set; }

        public string CaloriesLabel { get => Calories > 0 ? Calories.ToString("0.##") + " " + AppResources.Calories : null; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
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
