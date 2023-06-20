using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{

    public partial class Menu : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData;
        private ObservableCollection<Recipe> recipes;
        private ObservableCollection<Ingredient> ingredients;
        private EnterRecipe enterRecipeWindow; // Reference to the EnterRecipe window
        private RecipeListWindow1 recipeListWindow; // Reference to the RecipeListWindow1 window

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipeData.Recipes; }
            set
            {
                recipeData.Recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public Menu(RecipeData data)
        {
            InitializeComponent();
            recipeData = data;
            recipes = recipeData.Recipes;
            Ingredients = new ObservableCollection<Ingredient>(); // Initialize the Ingredients collection
        }

        private void AddRecipesButton_Click(object sender, RoutedEventArgs e)
        {

            enterRecipeWindow = new EnterRecipe(recipeData);

            enterRecipeWindow.Show();

            Close();
        }



        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {

            RecipeListWindow1 newRecipeListWindow = new RecipeListWindow1(recipeData);
            newRecipeListWindow.Show();

        }


        private void ScaleQuantityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScaleQuantitiesWindow scaleWindow = new ScaleQuantitiesWindow(recipeData);

            scaleWindow.ShowDialog();

            // Check if the scaling was successful or canceled
            if (scaleWindow.DialogResult.HasValue && scaleWindow.DialogResult.Value)
            {
                // Refresh the UI to reflect the scaled quantities
                Ingredients = new ObservableCollection<Ingredient>(Ingredients);
            }
        }

    }
}