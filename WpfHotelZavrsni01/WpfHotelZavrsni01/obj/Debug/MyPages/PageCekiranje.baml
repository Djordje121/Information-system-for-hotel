   M S B A M L   `   `   `  ����L  HWpfHotelZavrsni01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfHotelZavrsni01WpfHotelZavrsni01  5      %    WpfHotelZavrsni01.PageCekiranje   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WpfHotelZavrsni01     5        N� Title$  PageCekiranje��5	       N� 
Background
 �����.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridCekiranja��5      $
��Left=�6.   $	��239��6I   $��	21,41,0,0q�6V   $	��Top=�6i   $	��497��6�    �� AlternationCount$ 2��5         AlternatingRowBackground
 � ���   CanUserSortColumns .     CanUserAddRows .     SelectionMode$ Single=�5         SelectionUnit$ FullRow=�6*   	   AutoGenerateColumns	 .  
   
IsReadOnly
 . 
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ CekiranjeId� �� Mode$ OneWay=�  5      $
 Gost��6%   $	 120 63    6?   �� $
 Gost�$ OneWay=�  5      $ 
Vrsta sobe��6%   $	 100 69    6E   �� $ 	VrstaSobe�$ OneWay=�  5      $ Datum Cekiranja��6%   $	 120 6>    6J   �� $ CekiranjeDatum�$ OneWay=�  5      $ Datum Odlaska��6%   $	 120 6<    6H   �� $ OdlazakDatum�$ OneWay=�5      �� 5   
   $��	Cekiranja��6   $
��Left=�6$   $��	21,10,0,0q�6?   $	��Top=�6R   5      5      