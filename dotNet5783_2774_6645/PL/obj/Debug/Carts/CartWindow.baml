   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PL.CartsPL.Carts  5   	       PL.Carts.CartWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:PL.Carts     5   	     � Title$  
CartWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ ProductsItemListview��5
   >   
����������	#FF041F65$��50,10,50,92q�6�   ��6\   �� *
cart.Items+ �� View 5      �� 5       �� AllowsColumnReorder$
 true��6    �� ColumnHeaderToolTip$ Employee Information��66   .P�5      �� $��ID��6~    �� Width$	 100��6�    �� DisplayMemberBinding 6%   �� *	ProductID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=�6�   �� 5      $
��Name��6w   $	 100��6�    6%   �� *Name+$ TwoWay=�$ 	LostFocus=�6�   �� 5      $��Price��6x   $	 100��6�    6%   �� *Price+$ TwoWay=�$ 	LostFocus=�6�   �� 5      $��Amount��6y   $	 100��6�    6%   �� *Amount+$ TwoWay=�$ 	LostFocus=�6�   �� 5      $��
TotalPrice��6~   $	 100��6�    6%   �� *
TotalPrice+$ TwoWay=�$ 	LostFocus=�6�   �� 5      $��Update Amount��6%   $	 100��6<   	 �� CellTemplate	 5      �� 5      .R�5   "   � 
 � ColumnDefinitions
 5   &   �� 5   *   $��* �6=   �� 5   *   $��* �6=   �� 5   *   $��* �6=   .+�5   &   ��  ��Name$ decreaseProductBtn��6=   -   5        $��0��5   -   $��-��6Z   $��20��6f   $��15��6r   $��10,3,0,0q�6}   6�   �� 5   &   $��updatedAmount��6j   $��1��6.   $��23��6>    �� TextWrapping$
 Wrap=�6K   $��22��6_   $��5,3,0,0q�6   ��6�   ��  �� Path$ Amount�$ TwoWay=�$ 	LostFocus=��� 5    &   $ addProductAmountBtn��6=   -   5        $��2��5    -   $��+��6Z   $��15��6f   $��5,3,0,0q�6q   $	��Top=�6�   6�   5!   #   5"      5$      �� 5&      $	 100��6%   	 5'      �� 5(      .R�5)   "   �� $��updateAmountTxt��6J   -   5        $��0��5)   )   $��delete��69   $��20��6a   $��15,4,0,0q�6m   6   5*      5,      5.      50      �� 52   
   $��Total Price��6   $
��Left=�6&   $��31��6A   $��467,381,0,0q�6M   $	��Top=�6b   $��74��6z   �� 53   
   -   5        $��TotalPriceTxt��53      $
��Left=�6'   $��33��6B   $��549,379,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��131��6�    �� 
IsReadOnly$
 True��6�   ��6�   �� *cart.TotalPrice+$ TwoWay=�$ 	LostFocus=��� 55   
   -   5        $��confirmOrderBtn��55   )   $��confirm order��6   $��265,372,439,10q�6�   y�6@   �� $ isAdmin�$ Default=�   TrueToHidden �� 	Converter# [  6�   �� 56   
   -   5        $��
addItemBtn��56   $   $��Add Item��6   $
��Left=�67   $��52��6R   $��137,372,0,0q�6^   $	��Top=�6s   $	��101��6�   6�   57      58      