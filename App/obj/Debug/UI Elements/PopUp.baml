   M S B A M L   `   `   `  ����B  >TestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TestApp.UI_ElementsTestApp.UI_Elements  5          TestApp.UI_Elements.PopUp   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TestApp.UI_Elements     5        � 	Resources  5	         placeHolder �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType ��Name K� ZIndex �� Path	 �� RelativeSource
 �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%�  &	        7���� 5
   
   " ��6$   8   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 
textSource��5   "   
������ $ 2��5   "   $��0q�5   "   ��5   &   �� $
 Text�	 �� *TemplatedParent+$
 TwoWay=�$ PropertyChanged=�5   "   �� 5      #��z 6&   #��z��6C   $ 1��6m   .��6~   ��5   "   �� 5   &   " ��6,   .�5   *   ��  � ��
 ���� 6G    5   *   �� 5   .    6:   �� $
 Text�   *
textSource+  6y   .a�5   2   ��  � ��
 �����6O   5   /   5    '   .��5!   1   5"      5#      5$      5&      5'      5(      .��5*      � $	��170��5+   	   $	��220��5,   	   .+�50   
   F� -   5         F�Name$ 	Container��50      $��Center=�51      $��Center=�52      ���#DDDAED����������hxр����hxрJ]�hxӀJ]�hx ���hx ��@��� ��@��� ���- �� ���- � ��@����J]@����@���@���р�@jV�р�@jV���- �@�����- �@���р���@���Ӏ���@��� 
�@��� 
��- �� 
��- �� 
�@��� 
�@�� 
��hx�����hx	$	��150��5E      $	��200��5F       �� Stretch$
 Fill=�5G      $��10q�5H      5I      �� 5J   
   -   5         ��Name$ StackContact��5J      .+�5K      �� $��0,25,0,5q�6    �� Padding$ 7,7,7,7q�6'   $��0q�69   ���#cac5e0 �� CornerRadius$ 	10,10,0,0��6b   $	��200��6{   ._�5L      �� $��Center=�6   $��Lane - Narrow)�6:   $��14(�6U   Ajouter un nouveau contact6   5M      �� 5N      -   5        $ 
StackRadio��5N       �� Orientation$ 
Horizontal=�6-   $��
0, 5, 0, 0q�6F   $��Center=�6Z   .+�5O      	� -   5         	�Name$ 
radioMaman��5O   2    	� 	GroupName$ Contact��6   $��Mère��6F    d� 	IsChecked$
 TrueY�6U   $��5,0,0,0q�6f   $��Lane - Narrow)�6w   $��14(�6�   	� 5P      -   5        $ 	radioPapa��5P   2   $ Contact��6   $��Père��6E   $��5,0,0,0q�6T   $��Lane - Narrow)�6e   $��14(�6�   	� 5Q      -   5        $ radioPatient��5Q   2   $ Contact��6   $��Patient��6H   $��5,0,0,0q�6Z   $��Lane - Narrow)�6k   $��14(�6�   5R      �� 5S      -   5        $ 
TextBoxTel��5S   *   $��0q�6   $��Lane - Narrow)�6>   $��14(�6Y   $��
0, 5, 0, 0q�6g   #��[  6{   $ Téléphone��6�   $	��185��6�   $��20��6�   $��Center=�6�   $��3q�6�   �� 5T      -   5        $ TextBoxEmail��5T      $��Lane - Narrow)�6,   $��14(�6G   $��
0, 5, 0, 0q�6U   #��[  6i   $ Email��6�   $	��185��6�   $��20��6�   $��Center=�6�   $��3q�6�   �� 5U      -	   5         ��Name$ ValidationContact��5U      $��Lane - Narrow)�60   $��14(�6K   $��
0, 5, 0, 0q�6Y   $ ButtonNouveauContact��6m   $��50��6�   $��20��6�   $��Valider��6�   6�   5V      5Y      ��5\      �� 5]   
    5^      :� 5_       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5`      �� .��5a      �� .��5b      W�  �� TargetProperty$ Opacity�6.    g� Duration$ 00:00:01D�6R    W� From$	 0.5X�6f   	 W� To$ 1X�6q   5c      5d      5e      P� 5f        P� Property  � y�! P� Value$! 	Collapsed=�6A   . �5g      ��  �@J�Opacity$ 0Q�6A   5h      5j      5l      