   M S B A M L   `   `   `  ����E  AVitalSings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:VitalSings.PagesVitalSings.Pages  5      U QLiveCharts.Wpf, Version=0.9.3.5, Culture=neutral, PublicKeyToken=3b585c2a5f1a92c1G4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      $    VitalSings.Pages.StatisticPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:VitalSings.Pages     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        N� Title$  StatisticPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��1q�6   
���   ���5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ #5AB2FF��6#   � 5      $ #CAF4FF��6#    � Offset$ 1Q�63   5      ._�5      �� $��0 0 10 0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/Resources/MainLogo.png��6   $��30��6=   $��30��6I   �� 5      -   5         ��Name$ MainTB��5      $��5 4 0 0q�5      $��Главная��5        �� TextAlignment$ Center=�5!      5"      �� 5#      $ 
Horizontal=�6   $��	0 10 0 10q�66   .+�5$      �� $"��/Resources/StatisticLogo.png��6   $��30��6B   $��30��6N   �� 5%      $��5 4 0 0q�5&      $��Статистика��5'      $ Center=�5(      5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $ ��/Resources/ProfileLogo.png��6   $��30��6@   $��30��6L   �� 5,      -   5        $ 	ProfileTB��5-      $��Профиль��5,       $��5 4 0 0q�5/      $ Center=�50      51      52      53      � 54   
   $��1��6   ���	#FFCBFDFF6   (� 55   
   $��1��6   .��56      �� $ 
Horizontal=�6   .+�57      �� .+�58      �� $��0 0 0 10q�59      $��Center=�5:      $7��1Статистика по приемам пищи��5;      #  LiveCharts.Wpf.CartesianChart  5<      -   5        $��nutritionsChart��5<   )   $	��500��5=      $
��auto��6-   $
��auto��5>   )   $	��400��5?   !   &   LiveCharts.Wpf.Charts.Base.Chart	   AxisX	 5A        LiveCharts.Wpf.Axis  
   Title$
 Дата��6'      Labels 64   �� *Dates+   AxisY 5D        $
 Количество��6'      LabelFormatter 6:   �� *
NFormatter+5F      �� 5G      -   5         ��Name$ PrintNutritionsChart��5H      $��Распечатать��5G      $��5q�5J      5K      �� 5M      $��10 0 0 0q�6   .+�5N      �� $��Center=�5O      $��0 0 0 10q�5P      $7��1Статистика по приемам воды��5Q        5R      -   5        $��
waterChart��5R   )   $
��auto��5S      $	��400��5T      $
��auto��5U      $	��500��5V      	 5X        $
 Дата��6'    64   �� *
WaterDates+ 5[        $
 Миллилитры��6'    6:   �� *LitersFormatter+5]      �� 5^      -   5        $ PrintWaterChart��5`      $��Распечатать��5^      $��5q�5_      5a      5b      5c      5d      5e      5f      