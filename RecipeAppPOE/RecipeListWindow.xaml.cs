using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;

namespace RecipeAppPOE
{
    public partial class RecipeListWindow : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData; // Reference to the RecipeData object
        private ObservableCollection<Recipe> recipes; // Collection of recipes

        private ICollectionView recipesView; // Collection view for filtering and sorting

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipeData.Recipes; } // Getter for the Recipes collection
            set
            {
                recipeData.Recipes = value; // Setter for the Recipes collection
                OnPropertyChanged(nameof(Recipes)); // Notify property changed event
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public RecipeListWindow(RecipeData data)
        {
            InitializeComponent();

            // Initialize the RecipeListWindow
            recipeData = data; // Set the RecipeData reference
            recipes = recipeData.Recipes; // Set the Recipes collection
            recipesView = CollectionViewSource.GetDefaultView(recipes); // Get the collection view for filtering and sorting
            DataContext = this.recipeData; // Set the data context to the RecipeData object

            // Set the default value for the caloriesComboBox
            caloriesComboBox.SelectedIndex = 1; // Select the "100" calorie option
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve filter criteria from user inputs
            string ingredientName = filterTextBox.Text.Trim(); // Get the ingredient name filter
            string selectedFoodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content as string; // Get the selected food group filter
            int maxCalories = 0; // Maximum calories filter
            bool applyFoodGroupFilter = !string.IsNullOrWhiteSpace(selectedFoodGroup) && !selectedFoodGroup.Equals("All", StringComparison.OrdinalIgnoreCase); // Check if food group filter should be applied

            // Parse the maximum calories value selected by the user
            if (caloriesComboBox.SelectedItem is ComboBoxItem selectedItem && int.TryParse(selectedItem.Content.ToString(), out maxCalories))
            {
                // Filter the recipes based on the selected criteria
                List<Recipe> filteredRecipes = new List<Recipe>(Recipes); // Create a copy of the Recipes collection

                if (!string.IsNullOrWhiteSpace(ingredientName))
                {
                    // Filter recipes based on ingredient name
                    filteredRecipes = filteredRecipes.Where(recipe =>
                        recipe.Ingredients.Any(ingredient => ingredient.Name.ToLower().Contains(ingredientName.ToLower())))
                        .ToList();
                }

                if (!string.IsNullOrWhiteSpace(selectedFoodGroup))
                {
                    // Filter recipes based on food group
                    filteredRecipes = filteredRecipes.Where(recipe =>
                    {
                        if (selectedFoodGroup.Equals("All", StringComparison.OrdinalIgnoreCase))
                            return true;

                        return recipe.Ingredients.Any(ingredient =>
                            string.Equals(ingredient.FoodGroup, selectedFoodGroup, StringComparison.OrdinalIgnoreCase));
                    }).ToList();
                }

                if (maxCalories > 0)
                {
                    // Filter recipes based on maximum calories
                    filteredRecipes = filteredRecipes.Where(recipe =>
                        recipe.Ingredients.Any(ingredient => !string.IsNullOrWhiteSpace(ingredient.Calories) && int.Parse(ingredient.Calories) <= maxCalories))
                        .ToList();
                }

                filteredRecipes = filteredRecipes.OrderBy(recipe => recipe.Name).ToList(); // Sort the filtered recipes by name

                // Update the ListBox with the filtered recipes
                recipesListBox.ItemsSource = filteredRecipes;
            }
            else
            {
                // Invalid input for maximum calories, display an error message
                MessageBox.Show("Invalid value for maximum calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the filter inputs
            filterTextBox.Text = string.Empty; // Clear the ingredient name filter
            foodGroupComboBox.SelectedIndex = 0; // Select the "All" option for food group filter
            caloriesComboBox.SelectedIndex = 1; // Select the "100" calorie option

            // Reset the filtering and retrieve the whole list of recipes
            recipesListBox.ItemsSource = Recipes;
        }

        private void RecipesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (recipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                // If a recipe is selected from the ListBox
                RecipeDetailsWindow detailsWindow = new RecipeDetailsWindow(selectedRecipe, recipeData); // Create a RecipeDetailsWindow instance
                detailsWindow.ShowDialog(); // Show the RecipeDetailsWindow as a modal dialog
                recipesListBox.SelectedIndex = -1; // Deselect the recipe in the ListBox

            }
            Close(); // Close the RecipeListWindow
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ContinueToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Menu window and pass the RecipeData object
            Menu obj = new Menu(recipeData);
            obj.Show();
            Close(); // Close the RecipeListWindow
        }
    }
}
