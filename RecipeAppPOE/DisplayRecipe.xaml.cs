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
    public partial class RecipeListWindow1 : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData;
        private ObservableCollection<Recipe> recipes;
        private ICollectionView recipesView;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipeData.Recipes; }
            set
            {
                recipeData.Recipes = value;
                OnPropertyChanged(nameof(Recipes));

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public RecipeListWindow1(RecipeData data)
        {
            InitializeComponent();
            recipeData = data;
            recipes = recipeData.Recipes;
            recipesView = CollectionViewSource.GetDefaultView(recipes);
            DataContext = this.recipeData;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = filterTextBox.Text.Trim();
            string selectedFoodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content as string;

            int maxCalories = 0;
            bool applyFoodGroupFilter = !string.IsNullOrWhiteSpace(selectedFoodGroup) && !selectedFoodGroup.Equals("All", StringComparison.OrdinalIgnoreCase);



            // Parse the maximum calories value entered by the user
            if (!string.IsNullOrWhiteSpace(caloriesTextBox.Text) && !int.TryParse(caloriesTextBox.Text, out maxCalories))
            {
                // Invalid input for maximum calories, display an error message
                MessageBox.Show("Invalid value for maximum calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Filter the recipes based on the selected criteria
            List<Recipe> filteredRecipes = new List<Recipe>(Recipes);

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
            if (!string.IsNullOrWhiteSpace(caloriesTextBox.Text) && maxCalories > 0)
            {
                // Filter recipes based on maximum calories
                filteredRecipes = filteredRecipes.Where(recipe =>
     recipe.Ingredients.Any(ingredient => !string.IsNullOrWhiteSpace(ingredient.Calories) && int.Parse(ingredient.Calories) <= maxCalories))
     .ToList();

            }
            filteredRecipes = filteredRecipes.OrderBy(recipe => recipe.Name).ToList();
            // Update the ListBox with the filtered recipes
            recipesListBox.ItemsSource = filteredRecipes;
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            filterTextBox.Text = string.Empty;
            foodGroupComboBox.SelectedIndex = 0; // Select the "All" option
            caloriesTextBox.Text = string.Empty;

            // Reset the filtering and retrieve the whole list of recipes
            recipesListBox.ItemsSource = Recipes;
        }

        private void RecipesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (recipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                RecipeDetailsWindow detailsWindow = new RecipeDetailsWindow(selectedRecipe);
              detailsWindow.ShowDialog();
               recipesListBox.SelectedIndex = -1;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
