   M S B A M L   `   `   `  ����  PL#    PL.Products.ProductListWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  ProductListWindow��5   
   $	��640��6$   $	��800��61   .��5	      � -   5        $��MainGrid��5	       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��5* �6   �� 5      $��* �6   .+�5   
   � -   5        $��UpGrid��5      $��Stretch=�6   $
��auto��6;   $��0��6I   $��Stretch=�6V   $
��auto��6r    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5        $��AttributeSelector��5   m   $��2��6    �� SelectedIndex$ 0��6D   $��100,32,16,31q�6V   $��2��6�   ��6(   �� *lst+6�   �� 5      $��	Category:��6   $��Center=�6(   $��Center=�6E   $��36(�6`   $��Anivers)�6n   $��1��6�   5      �� 5   
   -   5         ��Name$ ProductsListview��5   o   $��1��6   $��Stretch=�6�   $��Stretch=�6�   
����������	#FF041F65��6M   �� *
products+ �� View 5       �� 5!       �� AllowsColumnReorder$
 true��6    �� ColumnHeaderToolTip$ Employee Information��66   .P�5#      �� $��ID��6|    �� Width$	 100��6�   	 �� DisplayMemberBinding	 6%   �� 
 �� Path$
 ID� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=�6�   �� 5%      $
��Name��6|   $	 100��6�   	 6%   �� $

 Name�$ TwoWay=�$ 	LostFocus=�6�   �� 5'      $��category��6�   $	 100��6�   	 6%   �� $
 Category�$ TwoWay=�$ 	LostFocus=�6�   �� 5)      $��Price��6}   $	 100��6�   	 6%   �� $
 Price�$ TwoWay=�$ 	LostFocus=�6�   5+      5-      � 5.   
   -   5        $��prodListbtns��5.      .+�50      �� -   5        $��BtnAddProduct��50      $��Add Product��6*   $
��Left=�6@   $	��Top=�6[   $��44��6s   $��96��6   $��	17,17,0,0q�6�   51      53      55      