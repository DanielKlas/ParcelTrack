   M S B A M L   `   `   `  ����F  BParcelTrack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ParcelTrackParcelTrack  5   	       ParcelTrack.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ParcelTrack     5   	     � Title$  Parcel Track��5   	   $	��300��6   $	��450��6+   .��5	      � .+�5
   
   �� $
��Left=�6   $��	22,98,0,0q�6/   $��Delivery management��6B   $
��Wrap=�6]   $	��Top=�6q   �� 5   
   $
��Left=�6   $��	243,9,0,0q�6/   $��Courier management��6B   $
��Wrap=�6\   $	��Top=�6p   �� 5   
   -   5        $��Show all couriers��5      $
��Left=�6-   $��253,158,0,0q�6H   $	��Top=�6]   $��30��6u   $	��121��6�   6�   �� 5   
   $
��Left=�6   $��	20,10,0,0q�6/   $��Parcel management��6B   $
��Wrap=�6[   $	��Top=�6o   �� 5   
   -   5        $��Add parcel / courier��5      $
��Left=�60   $��	20,39,0,0q�6K   $	��Top=�6^   $��31��6v   $	��121��6�   6�   �� 5   
   -   5        $��Transfer parcel��5      $
��Left=�6+   $��253,122,0,0q�6F   $	��Top=�6[   $��31��6s   $	��121��6   6�   �� 5   
   -   5        $��Save & Exit��5      $
��Left=�6+   $��253,193,0,0q�6F   $	��Top=�6[   $��30��6s   $	��121��6   6�   �� 5   
   -   5         ��Name$ btn_displayDelivery��5      $��Display deliveries��6.   $
��Left=�6K   $��
20,154,0,0q�6f   $	��Top=�6z   $��32��6�   $	��121��6�   6�   �� 5   
   -   5         ��Name$ txtbox_courierDetails��5      $
��Left=�61   $��
85,127,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $��62��6�   �� 5   
   $��Courier ID:��6   $
��Left=�6&   $��
14,123,0,0q�6A   $	��Top=�6U   �� 5   
   $��Target courier ID:��6   $
��Left=�6-   $��
224,32,0,0q�6H   $	��Top=�6\   �� 5   
   $��Destination courier ID:��6   $
��Left=�62   $��
224,58,0,0q�6M   $	��Top=�6a   �� 5   
   $��
Parcel ID:��6   $
��Left=�6%   $��
224,84,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ txtbox_targetID��5      $
��Left=�6+   $��
361,36,0,0q�6F   $
 Wrap=�6Z   $	��Top=�6n   $��39��6�   �� 5   
   -   5        $ txtbox_destinationID��5      $
��Left=�60   $��
361,62,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $��39��6�   �� 5   
   -	   5        $ txtbox_parcelTransferID��5      $
��Left=�63   $��
361,88,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $��39��6�   5      5      