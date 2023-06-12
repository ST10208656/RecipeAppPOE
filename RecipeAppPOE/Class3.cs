using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPOE
{
    internal class Ingredient
    {
        public string? Name { get; set; } //This is a property the represents the name of a ingredient
        public double Quantity { get; set; }//This is a property the represents the quantity of a ingredient
        public string? UnitOfMeasurement { get; set; }//This is a property the represents the unit of measurement of a ingredient
        public int Calories { get; set; }//This is a property the represents the calories of a ingredient

        public string? FoodGroup { get; set; }//This is a property the represents the food group of a ingredient

    }
}
