   M S B A M L   `   `   `  ����I  Ee_Tagebuch_2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:e_Tagebuch_2._0e_Tagebuch_2._0  5   	       e_Tagebuch_2._0.frmEditor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:e_Tagebuch_2._0     5   	     � Title$  Editor��5   	   $��455.29��6   $��271.107��6(    � WindowStartupLocation$ CenterScreen=�68    � SizeToContent$ WidthAndHeight=�6]    � 
ResizeMode$ NoResize=�6|   .��5	      � $��0,0,21,10.333q�6   .+�5
   
   �� $��Name:��6   $
��Left=�6    $��	34,10,0,0q�6;   $	��Top=�6N   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��23��6>    �� TextWrapping$
 Wrap=�6J   $�� ��6^   $	��Top=�6f   $	��120��6~   $��
102,14,0,0q�6�   �� 5   
   $��Type:��6   $
��Left=�6    $��	34,38,0,0q�6;   $	��Top=�6N   �� 5   
   -   5         ��Name$ bntChoosePic��5      $��:��6'   $
��Left=�63   $��
203,99,0,0q�6N   $	��Top=�6b   $��19��6z   6�   �� 5   
   $��	Picture: ��6   $
��Left=�6$   $��	34,96,0,0q�6?   $	��Top=�6R   �� 5   
   -   5         ��Name$ 
lblPicPath��5      $
��path��6$   $
��Left=�63   $��
102,96,0,0q�6N   $	��Top=�6b   {�.  $��96��6�   �� 5   
   -   5        $ txtMain��5      $
��Left=�6$   $	��225��6?    �� 	MaxLength$
 1000��6L   $��
10,137,0,0q�6]   $
 Wrap=�6q   $	��Top=�6�   $	��212��6�   �� 5   
   -   5        $ bntClose��5      $��Close��6#   $
��Left=�63   $��
67,382,0,0q�6N   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $ bntSave��5      $
��Save��6"   $
��Left=�61   $��147,382,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $ 	bntChoose��5      $��Select��6%   $
��Left=�66   $��
102,42,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ lblDatum��5      $��Date:��6#   $
��Left=�63   $��	34,69,0,0q�6N   $	��Top=�6a   (  "System.Windows.Controls.DatePicker  5   
   -	   5        	  Name$	 dpDatepicker��5      $
��Left=�6+   $��
102,69,0,0q�6F   $	��Top=�6Z   5      5      