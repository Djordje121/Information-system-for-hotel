   M S B A M L   `   `   `  ����L  HWpfHotelZavrsni01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfHotelZavrsni01WpfHotelZavrsni01  5   	   '    !WpfHotelZavrsni01.WindowCekiranje   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfHotelZavrsni01     5   	   -   5          � Title$  WindowCekiranje��5   	   $	��500��6!   $	��900��6.    � 	Resources 5	      '  !WpfHotelZavrsni01.StatusConverter   
statusConv��%   &	          5
   
   6    5      .��5      � -   5         �Name$ grid1��5      
���i��.+�5   
   �� -   5         ��Name$ textboxImeGosta��5      $
��Left=�6+   $��23��6F   $��	37,34,0,0q�6R    �� TextWrapping$
 Wrap=�6e   
�������$	��Ime��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ textboxPrezime��5      $
��Left=�6*   $��23��6E   $��	37,88,0,0q�6Q   $
 Wrap=�6d   
�������$��Prezime��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ textboxJmbg��5      $
��Left=�6'   $��23��6B   $��
37,141,0,0q�6N   $
 Wrap=�6b   
�������$
��Jmbg��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ textboxKontaktTelefon��5      $
��Left=�61   $��23��6L   $��
37,199,0,0q�6X   $
 Wrap=�6l   
�������$��Telefon��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ textboxEmail��5      $
��Left=�6(   $��34��6C   $��
37,268,0,0q�6O   $
 Wrap=�6c   
�������$��Email��6�   $	��Top=�6�   $	��192��6�   6�   �� 5   
   -   5         ��Name$ comboboxTipSobe��5      $
��Left=�6,   $��
461,43,0,0q�6G   $	��Top=�6[   $	��120��6s   #��["�6   6�   �� 5   
   -	   5        $ comboBoxUsluga��5      $
��Left=�6+   $��
714,43,0,0q�6F   $	��Top=�6Z   $	��120��6r   #��["�6~   6�   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ datepickerPrijava��5      $
��Left=�60   $��461,310,0,0q�6K   $	��Top=�6`   6x     5   
   -   5        $ datepickerOdjava��5      $
��Left=�6/   $��732,310,0,0q�6J   $	��Top=�6_   6w   �� 5   
   -   5         ��Name$ 	btnZavrsi��5      $��zavrsi��6$   $
��Left=�65   $��
40,377,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ btnOdustani��5      $��odustani��6&   $
��Left=�69   $��154,377,0,0q�6T   $	��Top=�6i   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridSobe��5      
�������$
��Left=�6<   $	��179��6W   $��
461,88,0,0q�6d   $	��Top=�6x   $	��373��6�   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     CanUserSortColumns .     
IsReadOnly .    SelectionUnit$ FullRow=�5         SelectionMode$ Single=�6+      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Broj sobe��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   ��  �� Path$ BrojSobe� �� Mode$ OneWay=�6f     5      $ Sprat��6%   $ 90 6_    64   �� $ Sprat�$ OneWay=�6_   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Status��6)   $	 100 69      CellTemplate 5       �� 5!      .R�5"      �� ��6(   �� $ VratiStatus�$ OneWay=���6V   �� $ 
StatusSobe�$ OneWay=� �� 	Converter# [  5#      5%        5&      $
 Cena��6%   $ 90 6g    63   �� $ CenaSobePoDanu�$ OneWay=�6g   5(      �� 5)   
   $��
vrsta sobe��6   $
��Left=�6%   $��
461,10,0,0q�6@   $	��Top=�6T   �� 5*   
   -   5         ��Name$ labelImeGosta��5*      $��*��6'   $
��Bold"�63   $
��Left=�6E   $��	40,57,0,0q�6`   $	��Top=�6s   
���  ��
 � Tag 6�   ��  �� ElementName$ textboxImeGosta��$
 Name�$ OneWay=��� 5+   
   -   5        $ labelPrezime��5+      $��*��6&   $
��Bold"�62   $
��Left=�6D   $��
40,115,0,0q�6_   $	��Top=�6s   
���  �� 6�   �� $ textboxPrezime��$
 Name�$ OneWay=��� 5,   
   -   5        $ 	labelJmbg��5,      $��*��6#   $
��Bold"�6/   $
��Left=�6A   $��
37,169,0,0q�6\   $	��Top=�6p   
���  �� 6�   �� $ textboxJmbg��$
 Name�$ OneWay=��� 5-   
   -   5        $ labelKontaktTelefon��5-      $��*��6-   $
��Bold"�69   $
��Left=�6K   $��
40,237,0,0q�6f   $	��Top=�6z   
���  �� 6�   �� $ textboxKontaktTelefon��$
 Name�$ OneWay=��� 5.   
   $��prijava��6   $
��Left=�6"   $��461,276,0,0q�6=   $	��Top=�6R   �� 5/   
   $��odjava��6   $
��Left=�6!   $��750,276,0,0q�6<   $	��Top=�6Q   �� 50   
   -   5        $ textboxCena��50      $
��Left=�6'   $��45��6B   $��689,382,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��145��6�    �� 
IsReadOnly .  6�   �� 51   
   -   5        $ 
buttonCena��51      $��	vidi cenu��6%   $
��Left=�69   $��609,390,0,0q�6T   $	��Top=�6i   $��75��6�   $��30��6�   �� 52   
   $��vrsta obroka��6   $
��Left=�6'   $��
714,10,0,0q�6B   $	��Top=�6V   $��81��6n   53      54      