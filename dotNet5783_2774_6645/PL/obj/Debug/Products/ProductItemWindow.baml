   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PL.ProductsPL.Products  5   	   #    PL.Products.ProductItemWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PL.Products     5   	     � Title$  ProductItemWindow��5   	   $	��750��6#   $
��1200��60    � 	Resources 5
         MyDataTemplate � RowDefinitions �� Mode  ImageConverter �� 	Converter��%>  &	        7  �� 5   
   .R�5      �� 
���   �$��2q�6*   ._�5      � $	��260��6   $	��300��6#    5      �� 5      $
��0.5* �6(   �� 5      $
��3.5* �6(   �� 5      $
��0.5* �6(   �� 5      $
��0.5* �6(   �� 5      $
��0.5* �6(   .+�5      �� $��0��6   $��15(�6G   $��2q�6W   ��6*   �� *
Category+6W   �� 5      $��1��6   ��6+   �� *Image+$ OneWay=�8   �� 5      $��2��6   $��2q�6E   $��Center=�6R   $��Center=�6v   $��18(�6�   ��6*   �� *Name+6�   �� 5      $��3��6   $�� Price: ��6)   $��15(�6<   $��2q�6K   �� 5      $��3��6   $��45,0,0,0q�6)   $��15(�6;   $��2q�6d   ��6I   �� *Price+6d   �� 5      $��4��6   $��2q�6F   ��6)   �� *	InStock+6F   5      5      5      5      .��5$      �  5%   
   �� 5&      $��* �6   �� 5'      $��5* �6   �� 5(      $��* �6   .+�5*   
   � $��0��6    � ColumnDefinitions 5+      �� 5,      $��* �6#   �� 5-      $��* �6#   �� 5.      $��* �6#   �� 5/      $��* �6#   �� 50      $��* �6#   �� 51      $��* �6#   �� 52      $��* �6#   �� 53      $��* �6#   55      �� 56   
   -   5        $��AttributeSelector��56   K   $��2��6   $��100,16,16,16q�6#    �� SelectedIndex$ 0��69   $��2��6�   ��6e   �� *lst+6�   �� 58   
   $��1��6   $
��Auto=�6&   .��59      �� -   5        $��Disabled=�59   N   #��[  6�   ��6�   �� *
products+��5:      �� 5;      .R�5<      � 5=      5?      5@      �� 5A   
   -   5        $��2��5A      $��-50,30,10,10q�6   $
��🛒��66   
���  ��
�������$��35(�6h   $��50��6w   $	��200��6�   6�   5B      5C      