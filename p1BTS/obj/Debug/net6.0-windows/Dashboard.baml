   M S B A M L   `   `   `  ����@  <p1BTS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:p1BTSp1BTS  5   	       p1BTS.Dashboard   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:p1BTS     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Icon$  /Assets/MainLogo.png��5	   	   $
��1366��5
   	   $	��768��5   	    � 
ResizeMode$ 	CanResize=�5   	    � AllowsTransparency$
 True��5   	    � WindowState$ 	Maximized=�5   	    � Title$ 	Dashboard��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 35Q�6   	 � 	Resources	 5         
BlackBrush
 �� Color �� Opacity �� 
TargetType  MenutTextBlock �� Property �� Value �� Triggers P� Property P� Value  ComboBoxSelect  	BtnSetDef �� 
TargetType  PrimaryHueMidBrush��%�  &	        &	 .     7   &	 �    &	 u    �� 5   
   $
 Black��6-   $	 0.2Q�6;   �� 5   
   " ��6   .�5      ��  � �� �#efefef6+   �� 5       � ��
 ���� 6+   �� 5       �@��Padding$ 
15 15 0 15q�6(   �� 5       � ��$ 14(�6)   �� 5       �@�Cursor$
 Hand��6'    5      P� 5       �@J�IsMouseOver$
 True��61   . �5       ��  � ��8   63   5!      5#      �� 5$   
   " ��6   .�5%      ��  � �� �#efefef6+   �� 5&       � ��$
 15 8q�6(   �� 5'       � ��$ 14(�6)   �� 5(       � ��$ 0q�60   �� 5)       � ��$ Center=�62   5*      �� 5+   
   " ��6   .�5,      ��  � ��
 ���� 6+   �� 5-       � ��$ 20(�6)   �� 5.       � �� �#efefef6,   �� 5/       � �� �#efefef6+   �� 50       � ��$ SemiBold"�6+   �� 51       � �� 52      �� 53      " ��6&   .R�54      �� #��z��55      #��z��56      $��1q�57      ._�58      �� $��Center=�59   !   $��Center=�5:   !   5;      5<      5>       5?      P� 5@       �@J�IsMouseOver$
 True��61   . �5A      ��  � �� �#efefef63   �� 5B       � ��# �  63   �� 5C       � �� 5D      �� 5E      " ��6.   .R�5F   "   �� #��z��5G   %   #��z��5H   %   $��0q�5I   %   ._�5J   &   �� $��Center=�5K   )   $��Center=�5L   )   5M   #   5N      5P      5Q      5S      5U      .��5V      #  MaterialDesignThemes.Wpf.Card    MaterialDesignPaper#���  6   .��5W   
   �  � RowDefinitions 5X      �� 5Y      $
��Auto �6    �� 5Z      $��* �6    .+�5\      � $	��Top=�6   ���#efefef$��0��6@   .+�5]      ��    IsHitTestVisibleInChrome$
 True��6   $��Center=�6J   $��Right=�6e    �� Orientation$ 
Horizontal=�6�   .+�5^      �� -   5        $��MinimizeWindowBtn��5^   O     MaterialDesignFlatButton#��[ 6   .��5_      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   ���#3336H   5`      �� 5a      -   5        $��MaximizeWindowBtn��5a   O   #��[ 6   .��5b        $ WindowMaximize=�62   ���#3336H   5c      �� 5d      -   5        $��CloseAppBtn��5d   O   #��[ 6   .��5e        $ Close=�62   ���#3336?   5f      5g      5h      � 5i      $��1��6   .+�5j      �  � ColumnDefinitions 5k      �� 5l      $	��250 �6+   �� 5m      $��* �6+   .+�5o      � $��0��6   #���  6+    5p      �� 5q      $
��Auto �6,   �� 5r      $
��Auto �6,   �� 5s      .+�5u      � $��0��6   #���  6,   .+�5v      �� $ 
Horizontal=�5w   !   $��Center=�5x   !   $��	0 -35 0 0q�5y   !   #���  5z   !   .+�5{   "   �� $��/Assets/DashboardLogo.png��6(   $��50��5|   (   $��50��63   $��15 0 0 0q�5}   (   �� 5~   "   $ Vertical=�5   %   .+�5�   &   �� $��Dwipanca Corps��5�   )   ���#efefef$��20(�5�   )   $��	15 15 0 0q�5�   )   $��SemiBold"�5�   )   �� 5�   &   ���#efefef$��	15 0 0 20q�5�   )   $��Report System��5�   )   $��16(�5�   )   $��Normal"�5�   )   5�   #   5�      5�      � 5�      $��1��6   .+�5�      �� $ Vertical=�6)   $��	15 0 15 0q�6@   .+�5�   "   �� ���#aaa J� Opacity$ .3Q�6>   �� 5�   "   $��	Dashboard��6,   #��[ 6=   �� 5�   "   $��Finance��6,   #��[ 6;   �� 5�   "   $��	Add Staff��6,   #��[ 6=   �� 5�   "   $��Logout��6,   #��[ 6:   �� 5�   "   ���#aaa$ .3Q�6>   5�      5�      � 5�      $��2��6   $��30 15 15 15q�6,    5�      �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60    5�      �� 5�   "   $��* �63   �� 5�   "   $��50 �63   .+�5�      �� $��0��5�   !   $��0��5�   !   $
��0 15q�5�   !    �� SelectedIndex$ 0��5�   !   #���  5�   !   ��5�   "   -  'System.Windows.Data.CompositeCollection  5�   &   �� 5�   *   .��66   List Company6D   �� 5�   *   .��66   Please Select26F   �� 5�   *   .��66   Please Select36F   �� 5�   *   .��66   Please Select46F   5�   '   5�      �� 5�      $��+��5�   !   $��1��5�   !   $��0��5�   !   $��
15 15 0 15q�5�   !   #��[ 5�   !   �� 5�      $��0��5�   !   $��1��5�   !   $
��0 15q�5�   !   $ 0��5�   !   #���  5�   !   ��5�   "     5�   &   �� 5�   *   .��66   	List Area6A   �� 5�   *   .��66   Please Select26F   �� 5�   *   .��66   Please Select36F   �� 5�   *   .��66   Please Select46F   5�   '   5�      �� 5�      $��+��5�   !   $��1��5�   !   $��1��5�   !   $��
15 15 0 15q�5�   !   #��[ 5�   !   �� 5�      $��0��5�   !   $��2��5�   !   $
��0 15q�5�   !   $ 0��5�   !   #���  5�   !   ��5�   "     5�   &   �� 5�   *   .��66   List Project Name6I   �� 5�   *   .��66   Please Select26F   �� 5�   *   .��66   Please Select36F   �� 5�   *   .��66   Please Select46F   5�   '   5�      �� 5�      $��+��5�   !   $��1��5�   !   $��2��5�   !   $��
15 15 0 15q�5�   !   #��[ 5�   !   �� 5�      $��0��5�   !   $��3��5�   !   $
��0 15q�5�   !   $ 0��5�   !   #���  5�   !   ��5�   "     5�   &   �� 5�   *   .��66   List Item Name6F   �� 5�   *   .��66   Please Select26F   �� 5�   *   .��66   Please Select36F   �� 5�   *   .��66   Please Select46F   5�   '   5�      �� 5�      $��+��5�   !   $��1��5�   !   $��3��5�   !   $��
15 15 0 15q�5�   !   #��[ 5�   !   5�      5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   .+�5�      � -   5         �Name$
 dddt��5�   8   $��0��6   $��15q�6,    5      �� 5  "   $��* �63   �� 5  "   $��* �63   �� 5  "   $��* �63   .+�5     � $��0��6#   $
��Left=�63   $��Center=�6N   .+�5  "   �� $��	Dashboard��6,   $��24(�6=   $��SemiBold"�6K   5     � 5     $��2��6#   $��Right=�63   $��Center=�6O   .+�5	  "   �� $ Vertical=�6-   .+�5
  &   �� $��Arson Marianus (admin)��60   $��13(�6N   $��SemiBold"�6\   �� 5  &   $��Owner��60   $��13(�6=   $��Normal"�6K   5  #   5     5     � 5     $
��15 0q�5     $��1��5     $	��Top=�5     $
��Left=�5     .+�5     �� -   5         ��Name$ sv��5  !   $
��True��5  !   $
��Auto=�5  !   $
��Auto=�5  !   .��5  "   &   System.Windows.Controls.DataGrid  $
��Left=�5  )   $	��Top=�5  )   "   VerticalScrollBarVisibility$
 Auto=�5  )   $   HorizontalScrollBarVisibility$
 Auto=�5  )      CanUserReorderColumns$ False��5   )      
IsReadOnly$
 True��5!  )       AutoGenerateColumns$  False��5"  )   ��5  )   �� *DataGridItems+!   Columns! 5#  &   0  *System.Windows.Controls.DataGridTextColumn  5$  *   ,  &System.Windows.Controls.DataGridColumn"   Header$" No��6=   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6I   �� *no+  5%  *   $" SO Numb��6=   # 6N   �� *	so_numb+  5&  *   $" Site ID��6=   # 6N   �� *	site_id+  5'  *   $" 
Site ID OP��6=   # 6Q   �� *
site_id_op+  5(  *   $" 	Site Name��6=   # 6P   �� *	site_name+  5)  *   $" Company��6=   # 6N   �� *	company+  5*  *   $" Status��6=   # 6M   �� *status+  5+  *   $" Operator��6=   # 6O   �� *	operatr+  5,  *   $" Tower Height��6=   # 6S   �� *tower_height+  5-  *   $" KOM Sitac Date��6=   # 6U   �� *kom_sitac_date+  5.  *   $" Tower Height��6=   # 6S   �� *tower_height+  5/  *   $" Validate Date��6=   # 6T   �� *validate_date+  50  *   $
" Long��6=   # 6K   �� *long_+  51  *   $	" Lat��6=   # 6J   �� *lat+  52  *   $" 	Residence��6=   # 6P   �� *	residence+  53  *   $" Province��6=   # 6O   �� *
province+  54  *   $" SPO Pre Sitac��6=   # 6T   �� *spo_pre_sitac+  55  *   $" PO Pre Sitac��6=   # 6S   �� *po_pre_sitac+  56  *   $" Status BAST��6=   # 6R   �� *status_bast+  57  *   $" PO Sitac��6=   # 6O   �� *
po_sitac+  58  *   $" PO CME��6=   # 6M   �� *po_cme+  59  *   $" Status BAST��6=   # 6R   �� *status_bast2+  5:  *   $" PO Operational��6=   # 6U   �� *po_operational+  5;  *   $" PO Date��6=   # 6N   �� *	po_date+  5<  *   $" Status��6=   # 6M   �� *	status_+  5=  *   $" 
PO Comcase��6=   # 6Q   �� *
po_comcase+  5>  *   $" Remark BAST CME��6=   # 6V   �� *remark_bast_cme+  5?  *   $" Reamrk BAST IMB��6=   # 6V   �� *remark_bast_imb+5A  #   5B     5C     5D     5E     5F     5G     5H     5I     