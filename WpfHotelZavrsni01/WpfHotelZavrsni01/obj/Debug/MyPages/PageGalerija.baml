   M S B A M L   `   `   `  ����L  HWpfHotelZavrsni01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfHotelZavrsni01WpfHotelZavrsni01  5      $    WpfHotelZavrsni01.PageGalerija   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WpfHotelZavrsni01     5        N� 
Background
  ����� N� Title$ PageGalerija��5	      .��5      � 
���  �� � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   $��1��6   $��Stretch=�6/   
���   �$��0q�6a   ._�5      �� $��Hidden=�6   $��Visible=�6@   .��5      � -   5         �Name$ wrap1��5      $��Stretch=�6+   $��Stretch=�6I   5      5      �� 5   
   -   5         ��Name$ border1��5      $��Stretch=�6#   $��1��6B   $��Stretch=�6O   $��1��6k   ._�5      �� -   5         ��Name$ 	imgBorder��5      $
��Fill=�6'   5      �� 5   
   -   5         ��Name$ buttonDodajSliku��5      $��
Dodaj novu��6+   $
��Left=�6@   $��	10,41,0,0q�6[   $	��Top=�6n   $��75��6�   $��1��6�   �� 5   
   -   5        $ buttonPromeniSliku��5      $��Promeni��6-   $
��Left=�6?   $��	10,90,0,0q�6Z   $��1��6m   $	��Top=�6z   $��75��6�   6�   �� 5    
   -   5        $ buttonIzbrisiSliku��5       $��Obrisi��6-   $
��Left=�6>   $��
10,128,0,0q�6Y   $��1��6m   $	��Top=�6z   $��75��6�   6�   �� 5!   
   -   5         ��Name$ comboboxTipSobe��5!      $
��Left=�6,   $��	10,48,0,0q�6G   $	��Top=�6Z   $	��120��6r   6~   �� 5"   
   $��
vrsta sobe��6   $
��Left=�6%   $��10,8,0,0q�6@   $	��Top=�6R   	 J� RenderTransformOrigin$	 0.368,0.385&�6j   $��14(�6�   5$      5%      