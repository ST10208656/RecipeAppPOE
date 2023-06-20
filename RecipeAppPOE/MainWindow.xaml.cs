using System.Windows;

namespace RecipeAppPOE
{
    // Other using statements and code...

    public partial class MainWindow : Window
    {
        private RecipeData recipeData;

        public MainWindow()
        {
            InitializeComponent();
          
            recipeData = new RecipeData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnterRecipe obj = new EnterRecipe(recipeData);
            obj.Show();
            MessageBox.Show("Welcome, please start by entering all your ingredients and press 'Add ingredient'. Do the same for instructions, and once you're done, you can enter your recipe name and press 'Save recipe'. If you wish to view all your entered recipes, press 'View'.", "Welcome", MessageBoxButton.OK);
            // Hide the current window instead of closing it
        }
    }

    // Rest of the code...
}
