   M S B A M L   `   `   `  ����F  BSmallShopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SmallShopUISmallShopUI  5   	       SmallShopUI.Admin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SmallShopUI     5   	     � Title$  Admin��5   	   $	��450��6   $	��800��6$   .��5	      � $��	0,0,0,-11q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ productView��5
      $��Center=�6(   $	��207��6E   $	��Top=�6R   $	��760��6j      CanUserAddRows$ False��5         
IsReadOnly$
 True��6*      AutoGenerateColumns$ False��6<   $��0,13,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 182 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	ProductId+6W     5      $ Product Name��6%   $	 190 6[    6;   �� *ProductName+6[     5      $ 
Amount(kg)��6%   $	 190 6T    69   �� *Amount+6T     5      $ Price(CAD)/kg��6%   $	 190 6V    6<   �� *Price+6V   5      �� 5   
   $
��Left=�6   $��
82,547,0,0q�6.   $	��Top=�6B   $	��120��6Z   �� 5   
   $��Label��6   $
��Left=�6    $��
20,547,0,0q�6;   $	��Top=�6O   $��73��6g   �� 5   
   $��Label��6   $��Right=�6    $��0,603,821,0q�6<   $	��Top=�6Q   $��37��6i   	 J� RenderTransformOrigin$	 0.5,0.5&�6u   $	��100��6�   6�   � 5   
   $
��Left=�6   $	��805��6*   $��-530,474,0,0q�67   $	��Top=�6M   $
��1530��6e   � 5   
   $
��Left=�6   $	��802��6*   $��-535,547,0,0q�67   $	��Top=�6M   $
��1555��6e   �� 5   
   -   5        
 ��Name$
 	ProductId��5      $��	ProductId��6#   $
��Left=�67   $��
29,253,0,0q�6R   $	��Top=�6f   $	��120��6~   �� 5   
   -   5        $
 ProductName��5      $��ProductName��6%   $
��Left=�6;   $��181,253,0,0q�6V   $	��Top=�6k   $��31��6�   �� 5   
   -   5        $
 Amount��5      $��Amount��6    $��Center=�61   $��	0,251,0,0q�6N   $	��Top=�6a   $	��136��6y   �� 5   
   -   5        $
 Price��5      $��Price��6   $
��Left=�6/   $��505,253,0,0q�6J   $	��Top=�6_   $	��120��6w   $	 0.615,-0.968&�6�   �� 5   
   -   5         ��Name$ 	View_date��5      $��	View date��6$   $
��Left=�68   $��630,237,0,0q�6S   $	��Top=�6h   $	��123��6�   6�   �� 5   
   -   5        $ InsertButton��5      $��Insert��6'   $
��Left=�68   $��
29,322,0,0q�6S   $	��Top=�6g   $	��120��6�   �� 5   
   -   5        $ UpdateButton��5      $��Update��6'   $
��Left=�68   $��182,322,0,0q�6S   $	��Top=�6h   $	��120��6�   �� 5    
   -	   5        $ DeleteButton��5       $��Delete��6'   $
��Left=�68   $��332,322,0,0q�6S   $	��Top=�6h   $	��128��6�   �� 5!   
   -
   5        $ SearchButton��5!      $��Search��6'   $
��Left=�68   $��505,322,0,0q�6S   $	��Top=�6h   $	��120��6�   6�   �� 5"   
   -   5         ��Name$ PriceTextBox��5"      $
��Left=�6(   $��505,274,0,0q�6C    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��120��6�   �� 5#   
   -   5        $ AmountTextBox��5#      $��Center=�6)   $��	0,274,0,0q�6F   $
 Wrap=�6Y   $	��Top=�6m   $	��136��6�   �� 5$   
   -   5        $ ProductNameTextBox��5$      $
��Left=�6.   $��181,274,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5%   
   -   5        $ ProductIdTextBox��5%      $
��Left=�6,   $��
29,274,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5&   
   -   5        $ 
BackButton��5&      $
��Back��6%   $
��Left=�64   $��644,367,0,0q�6O   $	��Top=�6d   $	��120��6|   6�   5'      5(      