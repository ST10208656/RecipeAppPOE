using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeAppPOE
{
    /// <summary>
    /// Interaction logic for EnterRecipe.xaml
    /// </summary>
    public partial class EnterRecipe : Window
    {
        private List<Recipe> recipes;
        private Recipe recipe;
        public EnterRecipe()
        {
            InitializeComponent();

            recipes = new List<Recipe>();
            recipe = new Recipe();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           

            string recipeName = RecipeNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName) || recipeName.Any(char.IsDigit))
            {
                MessageBox.Show("Invalid input. Please enter a valid recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the event handler to prevent further execution
            }

            recipe.Name = recipeName;

            recipe.Ingredients = new List<Ingredient>();
            recipe.Instructions = new List<Step>();
          
            bool addingInstructions = true;
            while (addingInstructions)
            {
                Step instruction = new Step();
                string instructions = InstructionsTextBox.Text.Trim();

                if (instructions.ToLower().Equals("done"))
                {
                    addingInstructions = false;
                    break;
                }

                instruction.Steps = instructions;
                recipe.Instructions.Add(instruction);
            }

            recipes.Add(recipe);
            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.OrdinalIgnoreCase));

            MessageBox.Show("Recipe entered successfully!");

            // Reset UI fields
            RecipeNameTextBox.Text = string.Empty;
            IngredientNameTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            CaloriesTextBox.Text = string.Empty;
            InstructionsTextBox.Text = string.Empty;
        }

        private void IngredientNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private Recipe GetRecipe()
        {
            return recipe;
        }

      
       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool addingIngredients = true;
            while (addingIngredients)
            {
                Ingredient ingredient = new Ingredient();

                string ingredientName = IngredientNameTextBox.Text.Trim();
                if (ingredientName.ToLower().Equals("done"))
                {
                    addingIngredients = false;
                    break;
                }

                ingredient.Name = ingredientName;

                if (!double.TryParse(QuantityTextBox.Text, out double quantity))
                {
                    MessageBox.Show("Invalid input. Please enter a valid quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Exit the event handler to prevent further execution
                }

                ingredient.Quantity = quantity;

                if (!int.TryParse(CaloriesTextBox.Text, out int calories))
                {
                    MessageBox.Show("Invalid input. Please enter a valid calorie value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Exit the event handler to prevent further execution
                }

                if (recipe == null)
                {
                    MessageBox.Show("Recipe object is null.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Exit the event handler to prevent further execution
                }

                if (recipe.Ingredients == null)
                    recipe.Ingredients = new List<Ingredient>();

                ingredient.Calories = calories;
                recipe.Ingredients.Add(ingredient);
            }
        }

    }
}

