   M S B A M L   `   `   `  ����C  ?AutoWand, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AutoWandAutoWand  5   	       AutoWand.EmployeeLogin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:AutoWand     5   	     � Title$  Employee Login - AutoWand��5   	   $	��250��6+   $	��400��68    � 
ResizeMode$ NoResize=�6D   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   �� 5      .+�5   
   �� $��1��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��Center=�6g   $��5q�6�    +� FocusedElement 6�   ��  �� ElementName$ UsernameEntry��.+�5      �� $��	Username:��6   �� 5      -   5         ��Name$ UsernameEntry��5   3   $	��185��6J   $��20��6V   ��6b   �� *
userName+5      �� 5   
   $��1��6   $��2��6%   $ 
Horizontal=�62   $��Right=�6K   $��Center=�6g   $��5q�6�   .+�5      �� $��	Password:��6   �� 5      -   5        $ PasswordEntry��5   3   $	��185��6J   $��20��6V   ��6b   �� *
Password+5      �� 5   
   $��1��6   $��3��6%   $ 
Horizontal=�62   $��Center=�6K   .+�5      �� -   5        $��Log In��5      $	��120��6&   $��22��62   $��5q�6>    �� 	IsDefault . ��6I   �� *loginCommand+6}   �� 5       $��Add New Employee��6   $	��120��60   $��22��6<   $��5q�6H   ��6T   �� *addNewEmpCommand+5!      5"      5#      