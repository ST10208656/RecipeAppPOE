   M S B A M L   `   `   `  ����   RecipeAppPOE    RecipeAppPOE.EnterRecipe   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Recipe App��$	��751��$	��638��.��(�  (� Stretch$
 Fill=�.��� 
���   �$	��600��$	��500�� � RowDefinitions �� $
��Auto ��� $��* �.+�� $��0�� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Recipe Name:��$��Center=����	#FFFE89FF$��Cascadia Mono SemiBold)�$��14(��� -    ��Name$ recipeNameTextBox��$��1��$��	5,5,139,5q�$��	Agency FB)�
�������
���������Z� �� -   $��Save Recipe��$��1��$��	304,5,5,3q�
�������$��Cascadia Code SemiBold)�
���������Z�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFE89FF��   	Direction$	 313Q�   
BlurRadius$ 3Q�	   ShadowDepth$	 2Q��� $��1��$��10q�.+��� $��Ingredients��
�������$��Cascadia Code SemiBold)�$��14(�$
��Bold"�$��Italic$�� $	��200�� �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��392* ��� $��8* ��� $��5* ��� $	��75* ��� $
��Auto �.+��� -   $ ingredientNameTextBox��$��1��$��0��$��5,20,243,51q�
�������
���������Z� .���� -   $ quantityTextBox��$��0��$��159,22,152,52q�$��2��
�������
���������Z� .���� -   
 ��Name$
 unitComboBox��$��262,19,92,52q� J� RenderTransformOrigin$ 0.842,9.396&�$��1��$��Cascadia Mono Light)���Z� ��Z� .@��� $��Pinch���� $��Teaspoon���� $��
Tablespoon���� $	��Cup���� $
��Pint���� -   $ caloriesTextBox��$��0��$��319,20,0,54q�
�������
�������$��2��$��1����Z� �� -   $
 foodGroupComboBox��$��10,18,37,54q�$��1��$��3��$��Cascadia Code Light)�.@��� $��Starchy foods���� $��Vegetable and fruits���� $'��!Dry beans, peas, lentils and soya���� $"��Chicken, fish, meat and eggs���� $��Milk and dairy products���� $��Fats and oil���� $��Water���� -   $��Add Ingredient��$��1��$��0��$��	5,48,5,28q�$��4��
�������$��Cascadia Mono SemiBold)�
�������$��18.21��$	��470����Z�    $ 	#FFFE89FF��$	 313Q�$ 3Q�$	 2Q��� -	    ��Name$ ingredientsListBox��$��2��$��0��$��
10,6,10,57q�$��4��$��	Agency FB)�
����������� *CurrentRecipe.Ingredients+��Z� ��Z� �� $
��Left=�$��5,1,0,0q�$
��Wrap=�$	��Top=�$��2��$��16��$��43��$ 0.502,0.378&����	#FFFE89FF$��Cascadia Code SemiBold)�$��14(���  � Language$ en-gb�$�Name:���� $
��Left=�$��	159,0,0,0q�$
��Wrap=�$	��Top=�$��2��$��15��$��81��$ 0.502,0.378&�$��	Quantity:�����	#FFFE89FF$��Cascadia Mono SemiBold)�$��14(��� $
��Left=�$��
319,-1,0,0q�$
��Wrap=�$	��Top=�$��14��$��81��$ 0.502,0.378&����	#FFFE89FF$��Cascadia Mono SemiBold)�$��14(�$��2��$��2���� $ en-gb�$�	Calories:���� $
��Left=�$��	262,1,0,0q�$
��Wrap=�$	��Top=�$��2��$��14��$��47��$ 0.502,0.378&����	#FFFE89FF$��Cascadia Mono SemiBold)�$��14(��� $ en-gb�$�Unit:���� $
��Left=�$��0,-1,0,0q�$
��Wrap=�$	��Top=�$��2��$��18��$	��115��$ 0.502,0.378&����	#FFFE89FF$��Cascadia Mono SemiBold)�$��14(�$��3��$��2���� $ en-gb�$�Food Group:���� $��Instructions��$��0,10,0,0q�
�������$��Cascadia Mono SemiBold)�$��Italic$�$��14(�$
��Bold"��� $	��200��.+��� -
   $ instructionTextBox��$��5q�
�������
�������$��	Agency FB)���Z� �� -   $��Add Instruction��$��5q�$��Cascadia Mono SemiBold)�
�������
���������Z�    $ 	#FFFE89FF��$	 313Q�$ 3Q�$	 2Q��� -   $ instructionsListBox��$��5q�
�������$��	Agency FB)����� *CurrentRecipe.Instructions+��Z� ��Z� �� -   $��View Recipes��
�������$��Cascadia Mono SemiBold)�
�������$	��172��$��318,534,10,10q�$��1����Z�    $ 	#FFFE89FF��$	 313Q�$ 3Q�$	 2Q��� -   $��Continue to menu��$
��Left=�$��
10,534,0,0q�$��1��$	��Top=�$	��160��
�������
�������$��28��$��Cascadia Mono SemiBold)���Z�    $ 	#FFFE89FF��$	 313Q�$ 3Q�$	 2Q�