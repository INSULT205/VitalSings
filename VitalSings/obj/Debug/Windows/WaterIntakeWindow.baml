   M S B A M L   `   `   `  ����E  AVitalSings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VitalSings.WindowsVitalSings.Windows  5   	   *    $VitalSings.Windows.WaterIntakeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VitalSings.Windows     5   	     � Title$  WaterIntakeWindow��5   	   $	��450��6#   $	��800��60    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�6   .��5
      � ���	#FFCBFDFF � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� .+�5      �� -   5        $��X��5      $��30��6!   $��30��6,   $��Right=�68   $	��Top=�6T   $��	0,10,10,0q�6l   ��5      �� 5       �� 
TargetType" ��6&   .R�5      �� ���#00a1ff �� CornerRadius$ 20��66   ._�5      �� #��z��6(   $��Center=�6I   $��Center=�6f   
�������6�   5      5      5      5      �� 5   
   $��Center=�6   $��1��60   .+�5      �� $ ��/Resources/Water/KapLa.png��6   $	��200��5      $	��250��5       �� 5!      $��Вода,мл��6      TitleTextStyle#��[  5"      $��Center=�5#      �� 5$      -   5         ��Name$ QuantityWaterTB��5'      $��24(�5%       �� TextAlignment$ Center=�5&      $	��200��5*      $��Center=�5+      �� 5,       �� Orientation$ 
Horizontal=�6   $��Center=�5-      $��	0 10 0 10q�5.      .+�5/      �� -   5        	 ��Name$	 	PlusFifBT��50      $	��+50��5/      $	��100��52      
�������53      �� 54      -   5        $	 	PlusHanBT��55      $
��+100��54      
�������$	��100��58      $��	10 0 10 0q�59      �� 5:      -   5        $	 	PlusTwoBT��5;      $
��+200��5:      $	��100��5=      
�������5>      5?      �� 5@      $ 
Horizontal=�6   $��Center=�5A      $��	0 10 0 10q�5B      .+�5C      �� -   5        $	 
MinusFifBT��5D      $	��-50��5C      $	��100��5F      ���	#FF5103035G      �� 5H      -   5        $	 
MinusHanBT��5J      $
��-100��5H      $	��100��5I      ���	#FF510303$��	10 0 10 0q�5M      �� 5N      -   5        $	 
MinusTwoBT��5P      $
��-200��5N      $	��100��5O      ���	#FF5103035R      5S      �� 5T      -	   5        $$��/Resources/Water/CheckMark.png��5T      $��Right=�5V      $��50��5W      $��50��5X      $��
0 0 100 10q�5Y      5Z      5[      5\      