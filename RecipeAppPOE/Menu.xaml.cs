using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class Menu : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData; // Holds the data for recipes
        private ObservableCollection<Recipe> recipes; // Collection of recipes
        private ObservableCollection<Ingredient> ingredients; // Collection of ingredients
        private EnterRecipe enterRecipeWindow; // Reference to the EnterRecipe window

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipeData.Recipes; } // Retrieves the recipe collection from recipeData
            set
            {
                recipeData.Recipes = value; // Sets the recipe collection in recipeData
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; } // Retrieves the ingredient collection
            set
            {
                ingredients = value; // Sets the ingredient collection
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public Menu(RecipeData data)
        {
            InitializeComponent();

            recipeData = data; // Assigns the provided recipe data to the local variable
            recipes = recipeData.Recipes; // Retrieves the recipe collection from recipeData
            Ingredients = new ObservableCollection<Ingredient>(); // Initializes the Ingredients collection
        }

        private void AddRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            enterRecipeWindow = new EnterRecipe(recipeData); // Creates a new instance of the EnterRecipe window

            enterRecipeWindow.Show(); // Shows the EnterRecipe window
            Close(); // Closes the current Menu window
        }

        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow newRecipeListWindow = new RecipeListWindow(recipeData); // Creates a new instance of the RecipeListWindow

            newRecipeListWindow.Show(); // Shows the RecipeListWindow
            Close(); // Closes the current Menu window
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleQuantitiesWindow scaleWindow = new ScaleQuantitiesWindow(recipeData); // Creates a new instance of the ScaleQuantitiesWindow

            scaleWindow.ShowDialog(); // Shows the ScaleQuantitiesWindow as a dialog

            // Check if the scaling was successful or canceled
            if (scaleWindow.DialogResult.HasValue && scaleWindow.DialogResult.Value)
            {
                // Refresh the UI to reflect the scaled quantities
                Ingredients = new ObservableCollection<Ingredient>(Ingredients);
            }

            Close(); // Closes the current Menu window
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecipeWindow obj = new DeleteRecipeWindow(recipeData); // Creates a new instance of the DeleteRecipeWindow

            obj.Show(); // Shows the DeleteRecipeWindow
            Close(); // Closes the current Menu window
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Exits the application
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
