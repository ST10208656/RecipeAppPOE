   M S B A M L   `   `   `  ����   RecipeAppPOE$    RecipeAppPOE.RecipeListWindow1   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Recipe List��$	��400��$	��883��.��� 
���   � � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��10q�.+��� $ ��Filter by Ingredient Name:��$��Center=�$��Cascadia Mono SemiBold)����	#FFFE89FF�� -    ��Name$ filterTextBox��$	��139��$��5q�$��Center=�
�������
���������Z� �� $��Food Group:��$��Center=�$��10,0,0,0q�$��Cascadia Mono SemiBold)����	#FFFE89FF�� -    ��Name$ foodGroupComboBox��$	��150��$��5q�.@��� $	��All�� �� 
IsSelected$
 True���� $��Starchy foods���� $��Vegetable and fruits���� $'��!Dry beans, peas, lentils and soya���� $"��Chicken, fish, meat and eggs���� $��Milk and dairy products���� $��Fats and oil���� $��Water���� $��Max Calories:��$��Center=�$��10,0,0,0q�$��Cascadia Mono SemiBold)�
��������� -   $ caloriesTextBox��$��80��$��5q��� -   $��Filter��$��5q�$��Center=��� -   $��Clear��$��5q�$��Center=��� -    ��Name$ recipesListBox��$��1��$��10q�
���   �
�������$��Cascadia Mono SemiBold)����	#FFFE89FF���� *	Recipes+���� .R��� .+��� $
��Bold"�$��16(�
����������� *Name+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFFE89FF��	   	Direction$		 313Q�
   
BlurRadius$
 3Q�   ShadowDepth$ 2Q��� ���� *Ingredients.Count+ �� StringFormat$  Number of Ingredients: {0}���� ���� *TotalCalories+$ Total Calories: {0}���� -   $��Continue to Menu��$��2��$��Center=�$��10q�$��Cascadia Mono SemiBold)����	#FFFE89FF
���������Z� 