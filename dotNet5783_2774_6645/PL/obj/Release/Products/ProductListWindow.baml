   M S B A M L   `   `   `  ����   PL#    PL.Products.ProductListWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  ProductListWindow��$	��640��$	��800��.��� -   $��MainGrid�� � RowDefinitions �� $��* ��� $��5* ��� $��* �.+�� -   $��UpGrid��$��Stretch=�$
��auto��$��0��$��Stretch=�$
��auto�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $��AttributeSelector��$��2�� �� SelectedIndex$ 0��$��100,32,16,31q�$��2������ *lst+�� $��	Category:��$��Center=�$��Center=�$��36(�$��Anivers)�$��1���� -    ��Name$ ProductsListview��$��1��$��Stretch=�$��Stretch=�
����������	#FF041F65���� *
products+ �� View ��  �� AllowsColumnReorder$
 true�� �� ColumnHeaderToolTip$ Employee Information��.P��� $��ID�� �� Width$	 100��	 �� DisplayMemberBinding	 �� 
 �� Path$
 ID� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=��� $
��Name��$	 100��	 �� $

 Name�$ TwoWay=�$ 	LostFocus=��� $��category��$	 100��	 �� $
 Category�$ TwoWay=�$ 	LostFocus=��� $��Price��$	 100��	 �� $
 Price�$ TwoWay=�$ 	LostFocus=�� -   $��prodListbtns��.+��� -   $��BtnAddProduct��$��Add Product��$
��Left=�$	��Top=�$��44��$��96��$��	17,17,0,0q�