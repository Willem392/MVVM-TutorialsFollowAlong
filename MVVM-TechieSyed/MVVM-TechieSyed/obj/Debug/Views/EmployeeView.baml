   M S B A M L   `   `   `  ����J  FMVVM-TechieSyed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MVVM_TechieSyed.ViewsMVVM_TechieSyed.Views  5      (    "MVVM_TechieSyed.Views.EmployeeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MVVM_TechieSyed.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      � $��15q�6     � ColumnDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��5      $��0��5      $��2��5      $��5,8,8,5q�5       �� Padding$ 3,3,3,3q�5      $��Center=�5      $��20(�5       $
��Bold"�5!      $��Employee Management��5"      �� 5#   
   $��1��5$      $��0��5%      $��5,8,8,5q�5&      $ 3,3,3,3q�5'      $��Enter Id��5(      �� 5)   
   $��2��5*      $��0��5+      $��5,8,8,5q�5,      $ 3,3,3,3q�5-      $��
Enter Name��5.      �� 5/   
   $��3��50      $��0��51      $��5,8,8,5q�52      $ 3,3,3,3q�53      $��	Enter Age��54      �� 55   
   -   5        $��txtId��56      $��1��57      $��1��58      $��5,8,8,5q�59      $��3,3,3,3q�5:      ��5;      ��  �� Path$ CurrentEmployee.Id� �� Mode$ TwoWay=��� 5<   
   -   5        $��txtName��5=      $��2��5>      $��1��5?      $��5,8,8,5q�5@      $��3,3,3,3q�5A      ��5B      �� $ CurrentEmployee.Name�$ TwoWay=��� 5C   
   -   5        $��txtAge��5D      $��3��5E      $��1��5F      $��5,8,8,5q�5G      $��3,3,3,3q�5H      ��5I      �� $ CurrentEmployee.Age�$ TwoWay=��� 5J   
   $��4��5K      $��1��5L       �� Orientation$ 
Horizontal=�5M      .+�5N      �� -   5        $��btnAdd��5O      $��5,8,8,5q�5P      $��3,3,3,3q�5Q      $	��ADD��5S      ��5R      �� $ SaveCommand�5S      �� 5T      -   5        $��	btnSearch��5U      $��5,8,8,5q�5V      $��3,3,3,3q�5W      $��SEARCH��5Y      ��5X      �� $ SearchCommand�5Y      �� 5Z      -   5        $��	btnUpdate��5[      $��5,8,8,5q�5\      $��3,3,3,3q�5]      $��UPDATE��5_      ��5^      �� $ UpdateCommand�5_      �� 5`      -   5        $��	btnDelete��5a      $��5,8,8,5q�5b      $��3,3,3,3q�5c      $��DELETE��5e      ��5d      �� $ DeleteCommand�5e      5f      �� 5g   
   -   5        $��txtBlockMessage��5h      $��5��5i      $��1��5j      $��5,8,8,5q�5k      $ 3,3,3,3q�5l      ��5m      �� $ Message�&   System.Windows.Controls.DataGrid  5n   
   -	   5        $��dgEmployees��5o      $��6��5p      $��1��5q      $��5,8,8,5q�5r      $��3,3,3,3q�5s         AutoGenerateColumns .  ��5u      �� $ EmployeesList�$ TwoWay=�   Columns 5v      0  *System.Windows.Controls.DataGridTextColumn  5w      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5x      	   Header$	 Employee Id��5z      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5y      �� $ Id�5z        5{      $
 auto 5|      $	 Employee Name��5~      
 5}      �� $
 Name�5~        5      $
 auto 5�      $	 Employee Age��5�      
 5�      �� $	 Age�5�      5�      5�      5�      