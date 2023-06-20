using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppPOE
{

    public class Recipe : INotifyPropertyChanged
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

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Instructions = new ObservableCollection<string>();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Event for calories exceeded notification
        public event EventHandler CaloriesExceeded;

        public virtual void OnCaloriesExceeded()
        {
            CaloriesExceeded?.Invoke(this, EventArgs.Empty);
        }
        public override string ToString()
        {
            return $"{Name} ({Ingredients.Count} ingredients)";
        }

    }
}
