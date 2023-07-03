using System.Globalization;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RecipeAppPOE
{
    // The window for displaying recipe details
    public partial class RecipeDetailsWindow : Window
    {
        // Variables to store the current recipe and recipe data
        private Recipe recipe1; // Represents the current recipe being displayed
        private RecipeData recipeData; // Represents the collection of recipes and recipe data

        // Constructor for RecipeDetailsWindow
        public RecipeDetailsWindow(Recipe recipe, RecipeData recipeData)
        {
            InitializeComponent();

            // Store the provided recipe and recipe data
            recipe1 = recipe;
            this.recipeData = recipeData;

            // Set the data context to the recipe
            DataContext = this.recipe1;

            // Set the color and text for the total calories display
            SetTotalCaloriesColor(recipe.TotalCalories);
        }

        // Sets the color and range text for the total calories display
        private void SetTotalCaloriesColor(int totalCalories)
        {
            if (totalCalories < 100)
            {
                // Low calories range
                totalCaloriesTextBlock.Foreground = Brushes.Green;
                calorieRangeTextBlock.Foreground = Brushes.Green;
                calorieRangeTextBlock.Text = "Low";
            }
            else if (totalCalories >= 100 && totalCalories < 300)
            {
                // Medium calories range
                totalCaloriesTextBlock.Foreground = Brushes.Yellow;
                calorieRangeTextBlock.Foreground = Brushes.Yellow;
                calorieRangeTextBlock.Text = "Medium";
            }
            else if (totalCalories >= 300 && totalCalories < 500)
            {
                // High calories range
                totalCaloriesTextBlock.Foreground = Brushes.Orange;
                calorieRangeTextBlock.Foreground = Brushes.Orange;
                calorieRangeTextBlock.Text = "High";
            }
            else if (totalCalories > 500)
            {
                // Very high calories range
                totalCaloriesTextBlock.Foreground = Brushes.Red;
                calorieRangeTextBlock.Foreground = Brushes.Red;
                calorieRangeTextBlock.Text = "Very High";
            }
        }

        // Event handler for the "Return to Recipe" button click
        private void ReturnToRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Return to the recipe list window
            RecipeListWindow recipeListWindow = new RecipeListWindow(recipeData);
            recipeListWindow.Show();
            Close();
        }

        // Event handler for the "Continue to Menu" button click
        private void ContinueToMenu_Click(object sender, RoutedEventArgs e)
        {
            // Continue to the menu window
            Menu menuWindow = new Menu(recipeData);
            menuWindow.Show();
            Close();
        }
    }
}
