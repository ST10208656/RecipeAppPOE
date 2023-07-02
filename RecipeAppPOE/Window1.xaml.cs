using System.Globalization;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RecipeAppPOE
{
    
    public partial class RecipeDetailsWindow : Window//erfrerfwe
    {
        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();
            DataContext = recipe;
            SetTotalCaloriesColor(recipe.TotalCalories);
        }
        private void SetTotalCaloriesColor(int totalCalories)
        {
            if (totalCalories < 100)
            {
                totalCaloriesTextBlock.Foreground = Brushes.Green;
                calorieRangeTextBlock.Foreground = Brushes.Green;
                calorieRangeTextBlock.Text = "Low";
            }
            else if (totalCalories >= 100 && totalCalories < 300)
            {
                totalCaloriesTextBlock.Foreground = Brushes.Yellow;
                calorieRangeTextBlock.Foreground = Brushes.Yellow;
                calorieRangeTextBlock.Text = "Medium";
            }
            else if (totalCalories >= 300 && totalCalories < 500)
            {
                totalCaloriesTextBlock.Foreground = Brushes.Orange;
                calorieRangeTextBlock.Foreground = Brushes.Orange;
                calorieRangeTextBlock.Text = "High";
            }
            else if (totalCalories > 500)
            {
                totalCaloriesTextBlock.Foreground = Brushes.Red;
                calorieRangeTextBlock.Foreground = Brushes.Red;
                calorieRangeTextBlock.Text = "Very High";
            }
        }



    }



}

