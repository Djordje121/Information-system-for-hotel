   M S B A M L   `   `   `  ����L  HWpfHotelZavrsni01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfHotelZavrsni01WpfHotelZavrsni01  5      '    !WpfHotelZavrsni01.PageRezervacije   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WpfHotelZavrsni01     5        N� 
Background
  ����� N� Title$ PageSobaInfo��5	      .��5      � {�. .+�5   
   �� $
��Left=�6   $��
77,196,0,0q�6+   $	��Top=�6?   �� 5   
   -   5         ��Name$ comboboxTipSobe��5      $
��Left=�6,   $��
165,16,0,0q�6G   $	��Top=�6[   $	��120��6s   6   �� 5   
   -   5         ��Name$ textboxBrojDana��5      $
��Left=�6+   $��23��6F   $��
92,275,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $��54��6�    J� RenderTransformOrigin$ 
0.87,0.696&�6�   �� 5   
   -   5         ��Name$ buttonPretrazi��5      $��pretrazi��6)   $
��Left=�6<   $��
71,313,0,0q�6W   $	��Top=�6k   $��75��6�   $ 
1.827,2.15&�6�   �� 5   
   $��Rezervisane sobe��6   $
��Left=�6+   $��
485,64,0,0q�6F   $	��Top=�6Z   �� 5   
   $��izaberite vrstu sobe:��6   $
��Left=�60   $��	10,12,0,0q�6K   $	��Top=�6^   �� 5   
   $��	broj dana��6   $
��Left=�6$   $��
10,272,0,0q�6?   $	��Top=�6S   $ 2.166,-0.496&�6k   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridSlobodniTermini��5      $
��Left=�64   $	��168��6O   $��	10,99,0,0q�6\   $	��Top=�6o   $	��373��6�   
������� �� AlternationCount$ 1��5      	   AlternatingRowBackground
	 � ���
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserSortColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ SobaId� �� Mode$ OneWay=�6]     5      $ moguca prijava��6%   $	 120 6f    6=   �� $ CekiranjeFormat�6f     5      $ moguca odjava��6%   $	 120 6b    6<   �� $ OdjavaFormat�6b     5      $ 	broj dana��6%   $ * 6`    68   �� $ BrojDanaFormat�6`   5      �� 5   
   $��Slobodni termini��6   $
��Left=�6+   $��	10,64,0,0q�6F   $	��Top=�6Y   �� 5    
   -   5        $ buttonRezervisi��5       $��cekiraj��6*   $
��Left=�6<   $��308,313,0,0q�6W   $	��Top=�6l   $��75��6�   6�     5!   
   -   5        $ datagridRezervisaneSobe��5!      $
��Left=�64   $	��168��6O   $��
485,99,0,0q�6\   $	��Top=�6p   $	��336��6�   $ 1��5"      
	 � ��� .   .  
 .   .     SelectionMode$ Single=�5$   &      SelectionUnit$ FullRow=�6=   
�������$ 
0.428,0.12&�6h    5%        5&      $ ID��6%   $ 60 61    6<   �� $ SobaId�$ OneWay=�  5'      $ Datum cekiranja��6%   $	 130 6>    6J   �� $ CekiranjeFormat�$ OneWay=�  5(      $ Datum Odjave��6%   $	 130 6;    6G   �� $ OdjavaFormat�$ OneWay=�5+      5,      5-      