   M S B A M L   `   `   `  ����E  AVitalSings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VitalSings.WindowsVitalSings.Windows  5   	   (    "VitalSings.Windows.NutritionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VitalSings.Windows     5   	     � WindowStyle$
  None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � Title$ NutritionWindow��5	   	   $	��450��6!   $	��800��6.   .��5
      � ���	#FFCBFDFF � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��2��6   .+�5      �� -   5        $��X��5      $��30��6!   $��30��6,   $��Right=�68   $	��Top=�6T   $��	0,10,10,0q�6l   ��5      �� 5       �� 
TargetType" ��6&   .R�5      �� ���#00a1ff �� CornerRadius$ 20��66   ._�5      �� #��z��6(   $��Center=�6I   $��Center=�6f   
�������6�   5      5      5       5!      �� 5"   
   -   5         ��Name$ NameTB��5'      $��Center=�5#      $��3��5$         TitleTextStyle#��[  5%      $
��Wrap=�5&      5'      �� 5*   
   $��Center=�6   $��Center=�60   $��3��6M   .+�5+      �� -   5         ��Name$ 
MinusFifBT��5,      $	��-50��5.      $	��200��5/      �� 50      -   5        $ 
MinusHanBT��51      $��	0 50 0 50q�53      $
��-100��54      $	��200��55      �� 56      -   5        $ 
MinusTwoBT��57      $
��-200��59      $	��200��5:      5;      �� 5=   
   
���   �$��1q�5>      $��Center=�5?      
�������$��1��5A      $��1��5B      $	��250��5C      $	��230��5D      $��	0 40 0 10q�5E      ._�5F      �� $��Center=�6   $��Center=�64   .+�5G      �� -   5        	 ��Name$	 QuantityNutritionTB��5J      
 �� TextAlignment$
 Center=�5H      $	��200��5I      $��40(�5M      5N      5O      �� 5R   
   -   5        $ AddNutritionBT��5S      $��1��5U      $��2��5V      $��0 0 0 80q�5W      $%��Добавить перекус��5X      �� 5[   
   $��Center=�6   $��Center=�60   $��2��5\      $��3��5]      .+�5^      �� -   5        $ 	PlusFifBT��5_      $��50��5a   	   $	��200��5b   	   �� 5c      -	   5        $ 	PlusHanBT��5d      $��	0 50 0 50q�5f   	   $	��100��5g   	   $	��200��5h   	   �� 5i      -
   5        $ 	PlusTwoBT��5j      $	��200��5l   	   $	��200��5m   	   5n      5p      5q      