using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPOE
{
    public class Ingredient : INotifyPropertyChanged
    {
        private string quantity;
      

        public string Name { get; set; }
        public string Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
       
        public string Unit { get; set; }
        public string Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, string quantity, string unit, string calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }


        // Implement the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Name} - {Quantity} {Unit} {FoodGroup} {Calories}";
        }
    }
    public class OriginalIngredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
