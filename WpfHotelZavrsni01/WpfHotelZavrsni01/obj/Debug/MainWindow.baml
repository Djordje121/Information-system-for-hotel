   M S B A M L   `   `   `  ����H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   L HWpfHotelZavrsni01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfHotelZavrsni01WpfHotelZavrsni01 5   	   "   WpfHotelZavrsni01.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   1localclr-namespace:WpfHotelZavrsni01     5   	     � Title$  
MainWindow��5	   	   $	��620��6   $
��1100��6)   .��5      � 
���  �� � ColumnDefinitions 5   
   �� 5      $	��140 �6   �� 5      .+�5   
   o� -   5         o�Name$ menu1��5      $��Stretch=�6   $��Stretch=�6<   $��0��6X   
���  ��
��� �����5      �� 5      .R�5      $�  $� Orientation$ Vertical=�6-   5      .@�5      m� -   5         m�Name$ menuHome��5      $��Pocetna��6)   $��50��6:   
���  ��
�������$��Italic$�6m   $��20(�6�   
���   �$��2q�6�    m� Icon 5      �� 5      $��Icons/1.png��6   5      m� 5      -   5        $ menuCekiranje��5      $��	Cekiranje��6.   $��50��6A   
�������$��Italic$�6a   
���  ��$��20(�6�    5      �� 5      $��Icons/10.png��6   $��UniformToFill=�62   $��Stretch=�6J   $��Stretch=�6h   5      m� 5       -   5        $ menuRezervacije��5       $��Rezervacije��60   $��50��6E   
�������$��Italic$�6e   
���  ��$��20(�6�    5!      �� 5"      $��Icons/7.png��6   $��UniformToFill=�61   $��Stretch=�6I   $��Stretch=�6g   5$      m� 5%      -   5        $ menuGalerija��5%      $��Galerija��6-   $��50��6?   
�������$��Italic$�6_   
���  ��$��20(�6�    5&      �� 5'      $��Icons/GL.png��6   $��UniformToFill=�62   $��Stretch=�6J   $��Stretch=�6h   5)      5*      �� 5+   
   
���  ��$��1��6%   .+�5,      �� $��PETROVIC HOTEL��6   
��� ��� �� Left$	 658��6D   
 �� Top$ 23��6V   $��41��6f   $	��300��6r   $��30(�6~   $��DemiBold"�6�   $��Italic$�6�   $�� Arial italic)�6�   �� 5-      $	��Ime��6   
���k���$	 107��69   $ 10��6K   $��51��6[   $��35��6f   $��20(�6r   $��	ExtraBold"�6�   �� 5.      -   5         ��Name$ textboxPretraga��5.      $��19��6/   $	 107��6;   	 �� TextWrapping$
	 Wrap=�6M   $�� ��6a   $ 45��6i   $	��112��6y   6�   �� 5/      -   5        
 ��Name$
 btnDodaj��5/      $��Dodaj��6'   
�������$	 107��6J   $	 542��6\   $��76��6m   6x   �� 50      -   5        $
 
btnPromeni��50      $��Promeni��6)   
�������$	 248��6N   $	 542��6`   $��74��6q   6|   �� 51      -	   5        $
 	btnObrisi��51      $��Obrisi��6(   
�������$	 383��6L   $	 542��6^   $��75��6o   6z   �� 52      -
   5         ��Name$ borderFrame��52      
���   �$��1q�6>   $	��400��6R   $ 30��6_   $	 100��6p   $	��900��6�   ._�53       � -   5          �Name$ frame1��53      $��Stretch=�6(     � NavigationUIVisibility$ Hidden=�6D   54      �� 55      -   5        $
 ButtonPretraga��55      $��Pretraga��6-   
��� ���$
��Bold"�6W   $	 248��6i   $ 45��6{   $��66��6�   $��19��6�   6�   57      5<      5=      