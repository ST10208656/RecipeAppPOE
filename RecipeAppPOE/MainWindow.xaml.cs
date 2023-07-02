using System;
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
            Close();
           
            MessageBox.Show("Welcome" +"\n\n"+ "Here is brief instructions on how to enter recipes:"+"\n\n"+"* Step 1. Please enter ingredient details first then click 'add ingredient', you can enter more ingredients until done."+"\n"+"* Step 2. Once done, please enter instructions second then click 'add instructions', you can enter more instructions until done."+ "\n"+"* Step 3. Once done, please enter recipe name last then click 'save recipe', \tyou can enter as much recipes as you wish.", "Welcome", MessageBoxButton.OK);


        }
    }

}
