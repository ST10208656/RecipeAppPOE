using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class DeleteRecipeWindow : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData; // Reference to the RecipeData object
        private ObservableCollection<Recipe> recipes; // Collection of recipes
        private Recipe selectedRecipe; // Currently selected recipe

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value; // Assign the new value to the 'recipes' field
                OnPropertyChanged(nameof(Recipes)); // Notify property changed event to update bindings
            }
        }


        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        public DeleteRecipeWindow(RecipeData data)
        {
            InitializeComponent();
            recipeData = data;
            recipes = recipeData.Recipes;
            DataContext = this;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRecipe != null)
            {
                // Prompt the user for confirmation before deleting the recipe
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Remove the selected recipe from the Recipes collection
                    Recipes.Remove(SelectedRecipe);
                    SelectedRecipe = null; // Clear the selected recipe
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Menu window
            Menu obj = new Menu(recipeData);
            obj.Show();
            Close();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the Menu window
            Menu obj = new Menu(recipeData);
            obj.Show();
            Close();
        }
    }
}
