   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PL.UserPL.User  5   	       PL.User.SignInWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:PL.User     5   	     � Title$  SignInWindow��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� -   5        $��	SignUpBtn��5
   ^   $��Sign Up��6   $��Center=�6#   $��45��6@   $��0,22,0,0q�6L   $	��Top=�6o   $	��162��6�   y�6�   ��  �� Path$ 	l.isLogin� �� Mode$ TwoWay=�   TrueToVisible �� 	Converter# [  6�   �� 5   
   -   5        $��LoginBtn��5   !   $��Login��6   $��Center=�61   $��45��6N   $��0,22,0,0q�6Z   $	��Top=�6l   $	��162��6�   y�6�   �� $ 	l.isLogin�$ TwoWay=�  TrueToHidden# [ 6�   �� 5   
   $
��Name��6   $
��Left=�6   $��33��6:   $��
229,99,0,0q�6F   $	��Top=�6Z   $��44��6r   y�6}   �� $ 	l.isLogin�$ TwoWay=�# [ �� 5   
   $
��Left=�6   $��33��6-   $��
300,99,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6b   $	��167��6z   y�6�   �� $ 	l.isLogin�$ TwoWay=�# [ ��6�   �� $ 	user.Name�$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=��� 5   
   $��Email��6   $
��Left=�6    $��32��6;   $��229,138,0,0q�6G   $	��Top=�6\   $��44��6t    J� RenderTransformOrigin$ 
2.37,0.021&�6   �� 5   
   $
��Left=�6   $��33��6-   $��300,137,0,0q�69   $
 Wrap=�6N   $	��Top=�6c   $	��167��6{   ��5      �� $ 
user.Email�$ TwoWay=�$ 	LostFocus=��� 5   
   $��password��6   $
��Left=�6#   $��33��6>   $��229,175,0,0q�6J   $	��Top=�6_   $��66��6w   �� 5   
   $
��Left=�6   $��33��6-   $��300,175,0,0q�69   $
 Wrap=�6N   $	��Top=�6c   $	��167��6{   ��5      �� $ user.Password�$ TwoWay=�$ 	LostFocus=��� 5   
   $��address��6   $
��Left=�6"   $��33��6=   $��229,217,0,0q�6I   $	��Top=�6^   $��66��6v   y�6�   �� $ 	l.isLogin�$ TwoWay=�# [ �� 5   
   $
��Left=�6   $��33��6-   $��300,217,0,0q�69   $
 Wrap=�6�   $	��Top=�6  $	��167��6&  y�6N   �� $ 	l.isLogin�$ TwoWay=�# [ ��6�   �� $ user.Address�$ TwoWay=�$ 	LostFocus=�6&  �� 5   
   -   5        $��	signUpBtn��5   #   $��sign up��6   $
��Left=�64   $��51��6O   $��665,342,0,0q�6[   $	��Top=�6p   $	��108��6�   y�6�   �� $ 	l.isLogin�$ TwoWay=�# [ �� 5   
   -   5        $��loginBtn��5   !   $��login��6   $
��Left=�61   $��51��6L   $��665,342,0,0q�6X   $	��Top=�6m   $	��108��6�   y�6�   �� $ 	l.isLogin�$ TwoWay=�# [  6�   5      5      