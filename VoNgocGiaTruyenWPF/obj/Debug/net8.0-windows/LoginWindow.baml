   M S B A M L   `   `   `  ����M  IVoNgocGiaTruyenWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VoNgocGiaTruyenWPFVoNgocGiaTruyenWPF  5   	   $    VoNgocGiaTruyenWPF.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VoNgocGiaTruyenWPF     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�5	   	   
������  � AllowsTransparency$
 True��5   	   .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2q�5   	    J� Opacity$
 0.95Q�5   	   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #0099FF��6#   	 � Offset$	 0Q�63   � 5      $ #DA34AE��6#   $
	 0.75Q�63   � 5      $ 	#FF60B1E7��6#   $	 1Q�65   � 5      $ 	#FF596FDD��6#   $	 0.309Q�65   � 5      $ 	#FF8C57CA��6#   $	 0.484Q�65   5      ��5      �� 5      $	 0,1&�6&   $	 1,0&�67   .��5      � $ #060531��6#   $	 0Q�63   � 5      $ 	#FF472FDE��6#   $	 1Q�65   5      ._�5       � .+�5!      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�5"      $��82��5#      $	��Top=�6   $	��632��6)   .+�5$      �� $��LOGIN WINDOW��6    
�������$��28(�5&      $��Medium"�5'      $��
Montserrat)�5(       � Cursor$
 Hand��5)      $��
180,30,0,0q�5*      $	��377��6   5,      �� 5-      $
 Vertical=�5.      $��82,102,82,68q�5/      .+�50      �� $��Email��6    
�������$��12(�52      $��Medium"�53      $��
Montserrat)�54      $��0,35,0,0q�55      �� 56      -   5         ��Name$ txtUser��56      $��13(�57      $��Medium"�58      $��
Montserrat)�59      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5=      $��28��5>      $��Center=�5?      $��0,5,0,0q�5@      .��6+   ��5A      �� 5B      64   .��5C   .   5D      �� 5F      $��Password��6    
�������$��12(�5H      $��Medium"�5I      $��
Montserrat)�5J      $��0,15,0,0q�5K      G� 5L      -   5         G�Name$ txtPass��5L   "   $��13(�5M      $��Medium"�5N      $��
Montserrat)�5O      
������� G� 
CaretBrush
 �����
�������$��0,0,0,2q�5S      $��28��5T      $��Center=�5U      $��0,5,0,0q�5V      ��5W      �� 5X      64   5Z      �� 5[      -   5         ��Name$ btnLogin��5[      $��0q�5\      $��LOG IN��5]      
�������$��12(�5_      $��
Montserrat)�5`      $
 Hand��5a      $��0,50,0,0q�5b      ��5d      �� 5e       �� 
TargetType" ��6$   .�5f   "   ��  �� Property � �� �� Value �#0099FF6?    �� Triggers 5g   "   P� 5h   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5i   *   ��  � �� �#28AEED6G   5j   '   5l      ��5n      �� 5o       �� 
TargetType" ��6.   .R�5p   "   �� $	��150��6)   $��40��65   $ 20��5q   %   #��z��5r   %   ._�5s   &   �� $��Center=�67   $��Center=�5t   3   5u   #   5v      5x      5y      �� 5z      .+�5{      �� -   5        $ 	btnCancel��5{      $��0q�5|      $��CANCEL��5}      
�������$��12(�5      $��
Montserrat)�5�      $
 Hand��5�      $��20,350,20,0q�5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��
 ��� �6?    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � ��
 �W�.�6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $ 20��5�      #��z��5�      ._�5�   &   �� $��Center=�67   $��Center=�5�      5�   #   5�      5�      5�      5�      5�      5�      5�      