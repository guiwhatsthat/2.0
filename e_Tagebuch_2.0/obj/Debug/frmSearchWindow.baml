   M S B A M L   `   `   `  ����I  Ee_Tagebuch_2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:e_Tagebuch_2._0e_Tagebuch_2._0  5   	   %    e_Tagebuch_2._0.frmSearchWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:e_Tagebuch_2._0     5   	     � Title$  frmSearchWindow��5   	   $��564.889��6!   $��474.111��62    � WindowStartupLocation$ CenterScreen=�6B   .��5	      � .+�5
   
   �� -   5         ��Name$ chkDate��5
      $��Search by date��6$   $
��Left=�6=   $��	34,42,0,0q�6X   $	��Top=�6k   6�   �� 5   
   -   5        $ chkType��5      $��Search by type��6$   $
��Left=�6=   $��	34,86,0,0q�6X   $	��Top=�6k   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpSearchDate��5      $
��Left=�6+   $��
180,38,0,0q�6F   $	��Top=�6Z   $	��120��6r   �� 5   
   -   5         ��Name$ cmbType��5      $
��Left=�6$   $	��Top=�6?   $	��120��6W   $��
180,79,0,0q�6c   �� 5   
   $��Suchkriterien��6   $
��Left=�6(   $��	34,10,0,0q�6C   $	��Top=�6V   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgView��5      $
��Left=�6#   $	��372��6>   $��
34,137,0,0q�6K   $	��Top=�6_   $	��266��6w      
IsReadOnly . 6�   �� 5   
   $��Entries:��6   $
��Left=�6#   $��
34,115,0,0q�6>   $	��Top=�6R   �� 5   
   $��Find by name��6   $
��Left=�6'   $��309,138,0,0q�6B   $	��Top=�6W   �� 5   
   -   5         ��Name$ txtSuche��5      $�� ��6$   $
��Left=�6,   $��23��6G    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��120��6   $��309,166,0,0q�6�   6�   �� 5   
   -   5        	 ��Name$	 bntShow��5      $��Show results��6"   $
��Left=�69   $��309,347,0,0q�6T   $	��Top=�6i   $	��119��6�   $��22��6�   6�     5   
   -   5        $ dpFrom��5      $
��Left=�6%   $��346,243,0,0q�6@   $	��Top=�6U   $��83��6m   �� 5   
   -	   5        $ chkdateSince��5      $$��Find all dates with
 no entry��6)   $
��Left=�6Z   $��309,199,0,0q�6u   $	��Top=�6�   6�   �� 5   
   -
   5        $	 bntNew��5      $	��New��6!   $
��Left=�6/   $��310,420,0,0q�6J   $	��Top=�6_   $	��119��6w   $��22��6�   6�   �� 5   
   -   5        $	 bntEdit��5      $
��Edit��6"   $
��Left=�61   $��309,383,0,0q�6L   $	��Top=�6a   $	��119��6y   $��22��6�   6�   �� 5   
   $��Current diary��6   $
��Left=�6(   $��
318,10,0,0q�6C   $	��Top=�6W   
 J� RenderTransformOrigin$
 0.432,0.333&�6o   �� 5   
   -   5        $ txtTagebuch��5      {�.  $�� ��69   $
��Left=�6A   $��23��6\   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   $��
318,40,0,0q�6�   �� 5   
   -   5        $	 bntClose��5      $��Close��6#   $
��Left=�63   $��310,487,0,0q�6N   $	��Top=�6c   $	��119��6{   $��22��6�   6�   �� 5   
   -   5        $	 bntClear��5      $��Clear search��6#   $
��Left=�6:   $��309,309,0,0q�6U   $	��Top=�6j   $	��119��6�   $��22��6�   6�   �� 5   
   -   5        $	 	bntRemove��5      $��Remove��6$   $
��Left=�65   $��310,452,0,0q�6P   $	��Top=�6e   $	��119��6}   $��22��6�   6�   �� 5   
   -   5        $	 	bntChange��5      $��Change diary��6$   $
��Left=�6;   $��
318,79,0,0q�6V   $	��Top=�6j   $	��119��6�   $��22��6�   6�   �� 5   
   $��From:��6   $
��Left=�6    $��305,222,0,0q�6;   $	��Top=�6P   $
 0.432,0.333&�6h   �� 5   
   $	��To:��6   $
��Left=�6   $��305,252,0,0q�69   $	��Top=�6N   $
 0.432,0.333&�6f     5    
   -   5        $
 dpTo��5       $
��Left=�6#   $��346,273,0,0q�6>   $	��Top=�6S   $��83��6k   5!      5"      