using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<CheckedListItem<string>> _customCheckBox;
        public ObservableCollection<CheckedListItem<string>> CustomCheckBox
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

        private int _quantity = 1;
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

        public class CheckedListItem<T> : ViewModelBase
        {
            private bool _isChecked;
            private T _item;

            public CheckedListItem()
            {
            }

            public CheckedListItem(T item, bool isChecked = false)
            {
                item = _item;
                isChecked = _isChecked;
            }

            public T Item
            {
                set
                {
                    _item = value;
                    OnPropertyChanged();
                }
                get { return _item; }
            }


            public bool IsChecked
            {
                set
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
                get { return _isChecked; }
            }
        }

        public MainViewModel()
        {
            myFrameShop.FrameShopFill();

            CustomCheckBox = new ObservableCollection<CheckedListItem<string>>();

            foreach (Material material in myFrameShop.Materials)
            {
                CustomCheckBox.Add(new CheckedListItem<string>() { Item = material.Name });
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
                        foreach (CheckedListItem<string> i in CustomCheckBox)
                        {
                            if (material.Name == i.Item & i.IsChecked == true)
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
                    }
                    myFrame.Save();
                });
            }
        }
    }
}
