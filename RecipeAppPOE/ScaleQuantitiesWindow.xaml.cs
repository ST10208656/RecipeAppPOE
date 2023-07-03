using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class ScaleQuantitiesWindow : Window, INotifyPropertyChanged
    {
        // Variables for storing data and collections
        private RecipeData recipeData1;
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Ingredient> scaledIngredients;
        private ObservableCollection<OriginalIngredient> originalIngredients;
        private Recipe selectedRecipe;

        public event PropertyChangedEventHandler PropertyChanged;

        // Property for binding the recipe collection to the view
        public ObservableCollection<Recipe> Recipes { get; set; }

        // Property for storing the currently selected recipe
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

        // Property for binding the scaled ingredients collection to the view
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

            // Initialize variables and collections
            recipeData1 = recipeData;
            Recipes = new ObservableCollection<Recipe>(recipeData.Recipes);
            ingredients = new ObservableCollection<Ingredient>(recipeData.Recipes.SelectMany(r => r.Ingredients));
            scaledIngredients = new ObservableCollection<Ingredient>(ingredients);

            // Set DataContext to this window
            DataContext = this;

            // Call UpdateScaledIngredients after setting DataContext
            UpdateScaledIngredients();

            // Create a collection of original ingredients for resetting purposes
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
                // Get the scaling factor based on the selected radio button
                double scalingFactor = 1.0;
                if (halfRadioButton.IsChecked == true)
                    scalingFactor = 0.5;
                else if (doubleRadioButton.IsChecked == true)
                    scalingFactor = 2.0;
                else if (tripleRadioButton.IsChecked == true)
                    scalingFactor = 3.0;

                // Perform the scaling operation on the scaled ingredients collection
                foreach (Ingredient ingredient in scaledIngredients)
                {
                    // Multiply the quantity by the scaling factor
                    ingredient.Quantity *= scalingFactor;

                    // Perform unit conversions if necessary
                    if (ingredient.Unit.Equals("Pinch"))
                    {
                        if (ingredient.Quantity >= 16)
                        {
                            ingredient.Quantity /= 16;
                            ingredient.Unit = "Teaspoon";
                        }
                    }
                    else if (ingredient.Unit.Equals("Teaspoon"))
                    {
                        if (ingredient.Quantity <= 1)
                        {
                            ingredient.Quantity *= 16;
                            ingredient.Unit = "Pinch";
                        }
                        else if (ingredient.Quantity >= 3)
                        {
                            ingredient.Quantity /= 3;
                            ingredient.Unit = "Tablespoon";
                        }
                    }
                    else if (ingredient.Unit.Equals("Tablespoon"))
                    {
                        if (ingredient.Quantity <= 1)
                        {
                            ingredient.Quantity *= 3;
                            ingredient.Unit = "Teaspoon";
                        }
                        else if (ingredient.Quantity >= 16)
                        {
                            ingredient.Quantity /= 16;
                            ingredient.Unit = "Cup";
                        }
                    }
                    else if (ingredient.Unit.Equals("Cup"))
                    {
                        if (ingredient.Quantity <= 1)
                        {
                            ingredient.Quantity *= 16;
                            ingredient.Unit = "Tablespoon";
                        }
                        else if (ingredient.Quantity >= 2)
                        {
                            ingredient.Quantity /= 2;
                            ingredient.Unit = "Pint";
                        }
                    }
                    else if (ingredient.Unit.Equals("Pint"))
                    {
                        if (ingredient.Quantity <= 1)
                        {
                            ingredient.Quantity *= 2;
                            ingredient.Unit = "Cup";
                        }
                        else if (ingredient.Quantity >= 2)
                        {
                            ingredient.Quantity /= 2;
                            ingredient.Unit = "Quart";
                        }
                    }
                    else if (ingredient.Unit.Equals("Quart"))
                    {
                        if (ingredient.Quantity <= 1)
                        {
                            ingredient.Quantity *= 2;
                            ingredient.Unit = "Pint";
                        }
                    }
                }


                // Update the recipes collection
                foreach (Recipe recipe in Recipes)
                {
                    if (recipe == SelectedRecipe)
                    {
                        // Update the ingredients collection of the selected recipe
                        foreach (Ingredient ingredient in recipe.Ingredients)
                        {
                            Ingredient scaledIngredient = scaledIngredients.FirstOrDefault(si => si.Name == ingredient.Name);
                            if (scaledIngredient != null)
                            {
                                ingredient.Quantity = scaledIngredient.Quantity;
                                ingredient.Unit = scaledIngredient.Unit;
                            }
                        }
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
                // Reset the quantities of ingredients in the selected recipe
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
                // Clear and populate the scaledIngredients collection with ingredients from the selected recipe
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
                scaledIngredients.Clear(); // Clear the scaledIngredients collection when no recipe is selected
            }

            ScaledIngredients = scaledIngredients;
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ContinueToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Menu window and close the current window
            Menu obj = new Menu(recipeData1);
            obj.Show();
            Close();
        }
    }
}
