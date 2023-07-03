using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPOE
{
    public class RecipeData : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private int totalCalories;
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<string> Instructions { get; set; }
        public int TotalCalories
        {
            get { return totalCalories; }
            set
            {
                if (totalCalories != value)
                {
                    totalCalories = value;
                    OnPropertyChanged(nameof(TotalCalories));

                }
            }
        }
        private ObservableCollection<Recipe> recipes;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public RecipeData()
        {
            Recipes = new ObservableCollection<Recipe>(); // Initialize the Recipes collection
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
