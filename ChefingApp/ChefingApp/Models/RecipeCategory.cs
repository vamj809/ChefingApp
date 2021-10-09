using System.Collections.Generic;

namespace ChefingApp.Models
{
    public class RecipeCategory
    {
        public string Description;
        public string Icon;

        public RecipeCategory(string description, string icon = null)
        {
            Description = description;
            Icon = icon;
        }
    }
}
