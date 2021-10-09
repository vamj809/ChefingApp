using System.Collections.Generic;

namespace ChefingApp.Models
{
    public class RecipeCategory
    {
        public string Description { get; set; }
        public string Icon { get; set; }

        public RecipeCategory(string description, string icon = null)
        {
            Description = description;
            Icon = icon;
        }
    }
}
