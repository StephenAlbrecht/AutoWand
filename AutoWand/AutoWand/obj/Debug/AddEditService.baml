   M S B A M L   `   `   `  ����C  ?AutoWand, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AutoWandAutoWand  5   	       AutoWand.AddEditService   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:AutoWand     5   	     � Title$  Add Service - AutoWand��5   	   $	��260��6(   $	��350��65    � 
ResizeMode$ NoResize=�6A   .��5	      � -   5         �Name$ 
ParentGrid��5	       � ColumnDefinitions 5
   
   �� 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��1��6    $��Right=�6-   $��Center=�6I   $��Name:��6d   �� 5   
   $��1��6   $��2��6    $��Right=�6-   $��Center=�6I   $��Parts Cost:��6d   �� 5   
   $��1��6   $��3��6    $��Right=�6-   $��Center=�6I   $��Labor Cost:��6d   �� 5   
   -   5         ��Name$ 	NameEntry��5   �   $��2��6   $��1��6"   $
��Left=�6L   $��Center=�6g   $��22��6�   $	��200��6�    �� 	MaxLength$ 25��6�   �� 5   
   -   5        $ 
PartsEntry��5   �   $��2��6   $��2��6"   $
��Left=�6L   $��Center=�6g   $��22��6�   $��75��6�   6�   �� 5   
   -   5        $ 
LaborEntry��5   �   $��2��6   $��3��6"   $
��Left=�6L   $��Center=�6g   $��22��6�   $��75��6�   6�   �� 5!   
   $��1��6   $��4��6%   $��2��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�5"      �� -   5        $��5q�5"      $��22��6    $	��100��6,   $��Add Service��68   6N   �� 5#      -   5        $��5q�5#      $��22��6    $	��100��6,   $��Cancel��68   6I   5$      5%      5&      