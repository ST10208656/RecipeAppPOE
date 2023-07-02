using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RecipeAppPOE
{
    public partial class DeleteRecipeWindow : Window, INotifyPropertyChanged
    {
        private RecipeData recipeData;
        private ObservableCollection<Recipe> recipes;
        private Recipe selectedRecipe;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
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
              MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

               if (result == MessageBoxResult.Yes)
                {
                    Recipes.Remove(SelectedRecipe);
                    SelectedRecipe = null;
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
