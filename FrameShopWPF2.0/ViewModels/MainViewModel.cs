using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FrameShopWPF
{
    public class MainViewModel : ViewModelBase
    {
        FrameShop myFrameShop = new FrameShop();
        Frame myFrame;

        private string _firstName;
        public string FirstName
        {
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
            get { return _firstName; }
        }

        private string _secondName;
        public string SecondName
        {
            set
            {
                _secondName = value;
                OnPropertyChanged();
            }
            get { return _secondName; }
        }

        private List<string> _customCheckBox;
        public List<string> CustomCheckBox
        {
            set
            {
                _customCheckBox = value;
                OnPropertyChanged();
            }
            get { return _customCheckBox; }
        }

        private int _width;
        public int WidthVM
        {
            set
            {
                _width = value;
                OnPropertyChanged();
            }
            get { return _width; }
        }

        private int _length;
        public int LengthVM
        {
            set
            {
                _length = value;
                OnPropertyChanged();
            }
            get { return _length; }
        }

        private int _quantity;
        public int QuantityVM
        {
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
            get { return _quantity; }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
            get { return _selectedItem; }
        }

        private string _checkLabel;
        public string CheckLabel
        {
            set
            {
                _checkLabel = value;
                OnPropertyChanged();
            }
            get { return _checkLabel; }
        }
        
        //public string FirstName
        //{
        //    get { return _firstName; }
        //    set { SetProperty(ref _firstName, value); }
        //}

        public MainViewModel()
        {
            FirstName = "test1";
            myFrameShop.FrameShopFill();

            CustomCheckBox = new List<string>();

            foreach (Material material in myFrameShop.Materials)
            {
                CustomCheckBox.Add(material.Name);
            }
        }

        public ICommand TestButton
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SecondName = "test2";
                });
            }
        }

        public ICommand CheckButton
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CheckLabel = "";

                    myFrame = new Frame()
                    {
                        Width = WidthVM,
                        Length = LengthVM,
                        Quantity = QuantityVM
                    };

                    foreach (Material material in myFrameShop.Materials)
                    {
                        if (material.Name == SelectedItem)
                        {

                            myFrame.Materials.Add(material);

                            int finalAmount = myFrame.FinalAmount(material);

                            if (material.QuanInStock >= finalAmount)
                            {
                                CheckLabel += "You have enough of " + material.Name + ".\nYou need: "
                                    + finalAmount + ". You have: " + material.QuanInStock + ".\n\n";
                            }

                            else if (material.QuanInStock < finalAmount)
                            {
                                CheckLabel += "You don't have enough of " + material.Name + ".\nYou need: "
                                    + finalAmount + ". You have: " + material.QuanInStock + ".\n\n";
                            }
                        }
                    }

                    myFrame.Save();
                });
            }
        }
    }
}
