using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPOE
{
    internal class Recipe
    {
        public string? Name { get; set; }//This is a property the represents the name of the recipe
        public List<Ingredient>? Ingredients { get; set; }//This is a property the represents the list of ingredients for the recipe

        public List<Step>? Instructions { get; set; }//This is a property the represents the list of instructions for the recipe
        public List<Ingredient>? OriginalIngredients { get; set; }//This is a property the represents a copied list of ingredients for the recipe


    }
}
