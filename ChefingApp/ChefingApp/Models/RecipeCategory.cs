using System.Collections.Generic;

namespace ChefingApp.Models
{
    public class RecipeCategory
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsInternal { get; set; }

        public RecipeCategory(string description, string icon = null, bool isInternal = false)
        {
            Description = description;
            Icon = icon;
            IsInternal = isInternal;
        }
    }
}
