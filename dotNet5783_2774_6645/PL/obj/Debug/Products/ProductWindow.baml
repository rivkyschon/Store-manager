   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PL.ProductsPL.Products  5   	   clr-namespace:PL.POPL.PO  5   	       PL.Products.ProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PL.Products     5   	   &localyclr-namespace:PL.PO     5   	     � Title$  ProductWindow��5
   	   $	��550��6   $	��800��6,   .��5      � -   5        $��p��5      .+�5   
   � -   5        $��GridData��5       J� RenderTransformOrigin$ 0.538,0.394&�6   .+�5      �� -   5        $��LblName��5      $
��name��6   $��18(�6+   $
��Left=�69   $��30��6T   $��	36,57,0,0q�6`   $	��Top=�6s   $��55��6�   
�������5      �� 5      -   5        $��TxtName��5      $
��Left=�6�   $��30��6�   $��
127,57,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6[  $	��190��6s   �� 
IsReadOnly 6%   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window �� Path$
 show�   
ShowToTrue �� 	Converter# [  ��6  �� $ currentProduct.Name�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 	LostFocus=�.��6  5      �� 5      -   5        $��LblPrice��5      $��18(�6   $��price��6+   $
��Left=�6;   $��36��6V   $��
36,105,0,0q�6b   $	��Top=�6v   $��55��6�   5      �� 5      -   5        $��TxtPrice��5      $
��Left=�6�   $��127,105,0,0q�6�   $
 Wrap=�6�   $	��Top=�6H  $	��190��6`  $��31��6l   6   ��  �� $ FindAncestor=�
 Window$
 show�# [  ��6�   �� $ currentProduct.Price�$	 TwoWay=�$
 	LostFocus=�.��6x  5      �� 5      -   5        $��	LblAmount��5      $��18(�6   $��amount��6,   $
��Left=�6=   $��36��6X   $��
36,193,0,0q�6d   $	��Top=�6x   $��79��6�   �� 5      -   5        $��	TxtAmount��5      $
��Left=�6�   $��127,-100,0,0q�6�   $
 Wrap=�6�   $��Center=�6L  $	��190��6g  $��30��6s   6   ��  �� $ FindAncestor=�
 Window$
 show�# [  ��6�   �� $ currentProduct.InStock�$	 TwoWay=�$
 	LostFocus=�.��6  5      �� 5      -	   5        $��SelectCategory��5      $
��Left=�6F   $��127,155,0,0q�6�   $	��Top=�6�   $	��120��6�    �� 
IsEditable$ False��6�   ��6#   �� *
categories+ �� Text 6a   �� $ currentProduct.Category�$	 TwoWay=�$
 	LostFocus=�5      �� 5       -
   5        $��LblCategory��5!      $��18(�6    $��category��6/   $
��Left=�6B   $��
36,147,0,0q�6]   $	��Top=�6q   $ 0.44,-0.266&�6�   5"      �� 5%      -   5        $��	BtnReturn��5&      $	��➜��6   $
��Left=�6,   $��687,0,0,369q�6G   $��Bottom=�6\   $��49��6w   $��83��6�   $��36(�6�   ���	#007070705'      5(      � 5)   
   -   5         �Name$ gridBtn��5)      $��0,2,0,-2q�6    .+�5*      �� -   5        $��BtnAdd��5+      $	��Add��6   $
��Left=�6�   $��
88,297,0,0q�6�   $	��Top=�6�   $��35��6�   $��72��6�   y�6)   �� *show+$	 OneTime=�  ShowOrUpdateToHidden# [ 5,      �� 5-      -   5        $��	BtnUpdate��5.      $��Update��6   $
��Left=�6�   $��200,297,0,0q�6�   $	��Top=�6�   $��35��6�   $��72��6�   y�6/   �� *show+$	 OneTime=�  AddOrShowToHidden# [ 5/      �� 50      -   5        $��	BtnDelete��51      $��Delete��6   $
��Left=�6�   $��307,297,0,0q�6�   $	��Top=�6�   $��35��6�   $��72��6�   y�6/   �� *show+$	 OneTime=�# [ 52      �� 53      -   5        $��addToCartBtn��54      $��add to cart��6!   $
��Left=�67   $��54��6R   $��581,120,0,0q�6^   $	��Top=�6�   $��93��6�   y�6s   �� *show+$	 OneTime=�  ShowToVisible# [ 55      �� 57      $	��200��6   $	��200��6%   $��0��62   $��528,197,72,37q�6B   .+�58      �� -   5         ��Name$ 
productImg��58      $	��100��59      $	��100��6)   $
��Fill=�68   $	��138��6G   $	��198��6T   ��58   ,   �� *currentProduct.Image+  ImageConverter# [ $	 OneWay=�59   T   5:      �� 5;      -   5        $��0��5;      $��	add image��6'   $��34��6<   $	��150��6H   $ 0.49,-0.994&�5<   �   $��161,363,489,37q�6�   y�6   �� *show+$	 OneTime=�  ShowToHidden# [ 6�   5=      �� 5>   
   $
��Left=�6   $	��100��6+   $��-128,297,0,0q�68   $	��Top=�6N   $	��100��6f   5?      5@      