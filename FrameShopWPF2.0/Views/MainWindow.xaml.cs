using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrameShopWPF
{
    public partial class MainWindow : Window
    {
        FrameShop myFrameShop = new FrameShop();

        //Frame myFrame;

        public MainWindow()
        {
            InitializeComponent();

            //myFrameShop.FrameShopFill();

            //foreach (Material material in myFrameShop.Materials)
            //{
            //    CheckBox chk = new CheckBox();
            //    chk.Content = material.Name;
            //    materialsStP.Children.Add(chk);
            //}
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            //    checkLabel.Content = "";

            //    myFrame = new Frame()
            //    {
            //        Width = Convert.ToInt32(widthTextBox.Text),
            //        Length = Convert.ToInt32(lengthTextBox.Text),
            //        Quantity = Convert.ToInt32(quantityTextBox.Text)
            //    };

            //    foreach (Material material in myFrameShop.Materials)
            //    {
            //        foreach(CheckBox chk in materialsStP.Children)
            //        {
            //            if (chk.IsChecked == true)
            //            {
            //                if (material.Name == chk.Content.ToString())
            //                {

            //                    myFrame.Materials.Add(material);

            //                    int finalAmount = myFrame.FinalAmount(material);

            //                    if (material.QuanInStock >= finalAmount)
            //                    {
            //                        checkLabel.Content += "You have enough of " + material.Name + ".\nYou need: "
            //                            + finalAmount + ". You have: " + material.QuanInStock + ".\n\n";
            //                    }

            //                    else if (material.QuanInStock < finalAmount)
            //                    {
            //                        checkLabel.Content += "You don't have enough of " + material.Name + ".\nYou need: "
            //                            + finalAmount + ". You have: " + material.QuanInStock + ".\n\n";
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    myFrame.Save();
        }
    }
}
