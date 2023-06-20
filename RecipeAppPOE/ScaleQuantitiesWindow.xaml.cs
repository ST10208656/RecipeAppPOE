using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class ScaleQuantitiesWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Ingredient> scaledIngredients;
        private ObservableCollection<OriginalIngredient> originalIngredients;
        private Recipe selectedRecipe;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Recipe> Recipes { get; set; }

        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
                UpdateScaledIngredients();
            }
        }

        public ObservableCollection<Ingredient> ScaledIngredients
        {
            get { return scaledIngredients; }
            set
            {
                scaledIngredients = value;
                OnPropertyChanged(nameof(ScaledIngredients));
            }
        }


        public ScaleQuantitiesWindow(RecipeData recipeData)
        {
            InitializeComponent();
            Recipes = new ObservableCollection<Recipe>(recipeData.Recipes);
            ingredients = new ObservableCollection<Ingredient>(recipeData.Recipes.SelectMany(r => r.Ingredients));
            scaledIngredients = new ObservableCollection<Ingredient>(ingredients);
           

            // Set DataContext
            DataContext = this;

            // Call UpdateScaledIngredients after setting DataContext
            UpdateScaledIngredients();
            originalIngredients = new ObservableCollection<OriginalIngredient>(
           ingredients.Select(ingredient => new OriginalIngredient
           {
               Name = ingredient.Name,
               Quantity = ingredient.Quantity
           })
           );
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double scalingFactor = 1.0;

                if (halfRadioButton.IsChecked == true)
                    scalingFactor = 0.5;
                else if (doubleRadioButton.IsChecked == true)
                    scalingFactor = 2.0;
                else if (tripleRadioButton.IsChecked == true)
                    scalingFactor = 3.0;

                // Perform the scaling operation
                foreach (Ingredient ingredient in scaledIngredients)
                {
                    ingredient.Quantity = (double.Parse(ingredient.Quantity) * scalingFactor).ToString();
                }

                // Update the recipes collection
                foreach (Recipe recipe in Recipes)
                {
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        Ingredient scaledIngredient = scaledIngredients.FirstOrDefault(si => si.Name == ingredient.Name);
                        if (scaledIngredient != null)
                            ingredient.Quantity = scaledIngredient.Quantity;
                    }
                }

                UpdateScaledIngredients();
            }
            catch (Exception ex)
            {
                // Handle the exception or display an error message
                MessageBox.Show($"An error occurred while scaling the quantities: {ex.Message}");
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRecipe != null)
            {
                foreach (Ingredient ingredient in SelectedRecipe.Ingredients)
                {
                    OriginalIngredient originalIngredient = originalIngredients.FirstOrDefault(oi => oi.Name == ingredient.Name);
                    if (originalIngredient != null)
                        ingredient.Quantity = originalIngredient.Quantity;
                }
                UpdateScaledIngredients();
            }
        }


        private void UpdateScaledIngredients()
        {
            if (SelectedRecipe != null)
            {
                scaledIngredients.Clear();
                foreach (Ingredient ingredient in SelectedRecipe.Ingredients)
                {
                    Ingredient scaledIngredient = new Ingredient
                    (
                       ingredient.Name,
                       
                        ingredient.Quantity,
                        ingredient.Unit,
                        ingredient.Calories,
                        ingredient.FoodGroup
                    );
                    scaledIngredients.Add(scaledIngredient);
                }
            }
            else
            {
                scaledIngredients = new ObservableCollection<Ingredient>(ingredients);
            }


            ScaledIngredients = scaledIngredients;
          
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
