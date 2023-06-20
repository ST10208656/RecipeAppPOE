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
        private RecipeData recipeData;
        private Recipe currentRecipe;
       

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
       
        public EnterRecipe(RecipeData recipeData)
        {
            InitializeComponent();
            this.recipeData = recipeData;
            currentRecipe = new Recipe();
            DataContext = currentRecipe;
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
                string ingredientName = ingredientNameTextBox.Text;
                string quantityText = quantityTextBox.Text;
                string unit = unitComboBox.Text;
                string calories = caloriesTextBox.Text;
                string foodGroup = foodGroupComboBox.Text;

                Ingredient ingredient = new Ingredient(ingredientName, quantityText, unit, calories, foodGroup);
                currentRecipe.Ingredients.Add(ingredient);

                ingredientNameTextBox.Text = string.Empty;
                quantityTextBox.Text = string.Empty;
                unitComboBox.SelectedIndex = -1;
                caloriesTextBox.Text = string.Empty;
                foodGroupComboBox.SelectedIndex = -1;

                ingredientsListBox.ItemsSource = null;
                ingredientsListBox.ItemsSource = currentRecipe.Ingredients;
                UpdateTotalCalories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding ingredient: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateTotalCalories()
        {
            int totalCalories = currentRecipe.Ingredients.Sum(ingredient => Convert.ToInt32(ingredient.Calories));
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
                string instruction = instructionTextBox.Text;
                currentRecipe.Instructions.Add(instruction);

                instructionTextBox.Text = string.Empty;
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
                currentRecipe.Name = recipeName;

                Recipes.Add(currentRecipe);

                // Sort the recipes alphabetically within the recipeData instance
                Recipes = new ObservableCollection<Recipe>(Recipes.OrderBy(recipe => recipe.Name));

                // Clear the input fields and reset the data context
                currentRecipe = new Recipe();
                recipeNameTextBox.Text = string.Empty;
                ingredientsListBox.ItemsSource = currentRecipe.Ingredients;
                instructionsListBox.ItemsSource = currentRecipe.Instructions;

                // Reset the currentRecipe as the data context
                DataContext = null;
                DataContext = currentRecipe;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow1 obj = new RecipeListWindow1(recipeData);
            obj.Show();

        }

        private void unitComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ingredientNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu(recipeData);
            obj.Show();
        }
    }
}







