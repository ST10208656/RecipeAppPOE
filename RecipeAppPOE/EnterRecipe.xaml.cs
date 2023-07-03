using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppPOE
{
    public partial class EnterRecipe : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData; // Stores the recipe data
        private Recipe currentRecipe; // Represents the currently entered recipe

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipeData.Recipes; }
            set
            {
                recipeData.Recipes = value; // Update the recipe collection in the recipeData
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public EnterRecipe(RecipeData recipeData)
        {
            InitializeComponent();

            this.recipeData = recipeData;
            currentRecipe = new Recipe();
            DataContext = currentRecipe; // Set the data context to the currentRecipe
            currentRecipe.CaloriesExceeded += CurrentRecipe_CaloriesExceeded;
        }

        private void CurrentRecipe_CaloriesExceeded(object sender, EventArgs e)
        {
            MessageBox.Show("Total calories exceed 300!", "Calories Exceeded", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the ingredient details from the input fields
                string ingredientName = ingredientNameTextBox.Text;
                string quantityText = quantityTextBox.Text;
                string unit = unitComboBox.Text;
                string calories = caloriesTextBox.Text;
                string foodGroup = foodGroupComboBox.Text;
                double quantity = double.Parse(quantityText);

                // Create a new ingredient instance
                Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);

                // Add the ingredient to the current recipe's ingredients collection
                currentRecipe.Ingredients.Add(ingredient);

                // Clear the input fields
                ingredientNameTextBox.Text = string.Empty;
                quantityTextBox.Text = string.Empty;
                unitComboBox.SelectedIndex = -1;
                caloriesTextBox.Text = string.Empty;
                foodGroupComboBox.SelectedIndex = -1;

                // Update the ingredients list box with the new collection
                ingredientsListBox.ItemsSource = null;
                ingredientsListBox.ItemsSource = currentRecipe.Ingredients;

                // Update the total calories
                UpdateTotalCalories();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding ingredient: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTotalCalories()
        {
            // Calculate the total calories from all ingredients
            int totalCalories = currentRecipe.Ingredients.Sum(ingredient => Convert.ToInt32(ingredient.Calories));

            // Update the totalCalories property of the current recipe
            currentRecipe.TotalCalories = totalCalories;

            // Check if total calories exceed 300
            if (totalCalories >= 300)
            {
                // Raise the CaloriesExceeded event
                currentRecipe.OnCaloriesExceeded();
            }
        }

        private void AddInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int step = currentRecipe.Instructions.Count + 1; // Get the current step number

                // Create the instruction string with the step number
                string instruction = "Step " + step + ": " + instructionTextBox.Text;

                // Add the instruction to the current recipe's instructions collection
                currentRecipe.Instructions.Add(instruction);

                // Clear the instruction input field
                instructionTextBox.Text = string.Empty;

                // Update the instructions list box with the new collection

                instructionsListBox.ItemsSource = null;
                instructionsListBox.ItemsSource = currentRecipe.Instructions;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding instruction: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string recipeName = recipeNameTextBox.Text;

                // Set the name of the current recipe
                currentRecipe.Name = recipeName;

                // Add the current recipe to the Recipes collection
                Recipes.Add(currentRecipe);

                // Sort the recipes alphabetically within the recipeData instance
                Recipes = new ObservableCollection<Recipe>(Recipes.OrderBy(recipe => recipe.Name));

                // Create a new instance of currentRecipe and update the event handler
                currentRecipe = new Recipe();
                currentRecipe.CaloriesExceeded += CurrentRecipe_CaloriesExceeded;

                // Clear the input fields and reset the data context
                recipeNameTextBox.Text = string.Empty;
                ingredientsListBox.ItemsSource = currentRecipe.Ingredients;
                instructionsListBox.ItemsSource = currentRecipe.Instructions;

                // Reset the currentRecipe as the data context
                DataContext = null;
                DataContext = currentRecipe;
                MessageBox.Show("Recipe saved successfully."+ "\n"+ "You may enter another recipe.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the recipe: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void unitComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ingredientNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void RecipeListButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the RecipeListWindow and close the current window
            RecipeListWindow obj = new RecipeListWindow(recipeData);
            obj.Show();
            Close();
        }

        private void MenuButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Open the Menu window and close the current window
            Menu obj = new Menu(recipeData);
            obj.Show();
            Close();
        }
    }
}
