   M S B A M L   `   `   `  ����  RecipeAppPOE$    RecipeAppPOE.RecipeListWindow1   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Recipe List��5   	   $	��400��6   $	��883��6*   .��5      � 
���   � � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� $ ��Filter by Ingredient Name:��6   $��Center=�69   $��Cascadia Mono SemiBold)�6T   ���	#FFFE89FF6x   �� 5      -   5         ��Name$ filterTextBox��5      $	��139��6-   $��5q�69   $��Center=�6D   
�������
���������6_   Z� 6�   �� 5      $��Food Group:��6   $��Center=�6+   $��10,0,0,0q�6F   $��Cascadia Mono SemiBold)�6X   ���	#FFFE89FF6|   �� 5      -   5         ��Name$ foodGroupComboBox��5      $	��150��62   $��5q�6>   .@�5      �� $	��All��6    �� 
IsSelected$
 True��6-   �� 5      $��Starchy foods��6   �� 5      $��Vegetable and fruits��6   �� 5      $'��!Dry beans, peas, lentils and soya��6   �� 5      $"��Chicken, fish, meat and eggs��6   �� 5      $��Milk and dairy products��6   �� 5      $��Fats and oil��6   �� 5      $��Water��6   5      �� 5      $��Max Calories:��6   $��Center=�6-   $��10,0,0,0q�6H   $��Cascadia Mono SemiBold)�6Z   
�������6~   �� 5      -   5        $ caloriesTextBox��5      $��80��6/   $��5q�6:   �� 5      -   5        $��Filter��5      $��5q�6A   $��Center=�6L   �� 5      -   5        $��Clear��5      $��5q�6?   $��Center=�6J   5      �� 5   
   -   5         ��Name$ recipesListBox��5      $��1��6*   $��10q�67   
���   �
�������$��Cascadia Mono SemiBold)�6�   ���	#FFFE89FF��6C   �� *	Recipes+��5      �� 5       .R�5!      �� .+�5"      �� $
��Bold"�6:   $��16(�6L   
���������6$   �� *Name+ J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$   "      Color$ 	#FFFE89FF��63   	   	Direction$		 313Q�6E   
   
BlurRadius$
 3Q�6U      ShadowDepth$ 2Q�6d   5&      �� 5'      ��6$   �� *Ingredients.Count+ �� StringFormat$  Number of Ingredients: {0}���� 5(      ��6$   �� *TotalCalories+$ Total Calories: {0}��5)      5*      5,      �� 5-   
   -   5        $��Continue to Menu��5-      $��2��6,   $��Center=�69   $��10q�6V   $��Cascadia Mono SemiBold)�6�   ���	#FFFE89FF
���������6�   Z� 6�   5.      5/      