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
