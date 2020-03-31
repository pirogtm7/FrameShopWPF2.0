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
        public IFrameService frameService { get; }
        public IFrameShopService frameShopService { get; }
        public IMaterialService materialService { get; }

        private FrameShopModel myFrameShop = new FrameShopModel();
        private FrameModel myFrame;

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

        public MainViewModel(IFrameService _frameService, IFrameShopService _frameShopService, IMaterialService _materialService)
        {
            frameService = _frameService;
            frameShopService = _frameShopService;
            materialService = _materialService;
            CustomCheckBox = new ObservableCollection<CheckedListItem<string>>();

            foreach (MaterialModel material in materialService.GetMaterials())
            {
                frameShopService.FrameShopFill(material, myFrameShop);
            }

            foreach (string name in frameShopService.NamesOfMaterials(myFrameShop))
            {
                CustomCheckBox.Add(new CheckedListItem<string>() { Item = name });
            }
        }

        public ICommand CheckButton
        {
            get
            {
                return new DelegateCommand((obj) =>
                {

                    myFrame = new FrameModel()
                    {
                        Width = WidthVM,
                        Length = LengthVM,
                        Quantity = QuantityVM
                    };

                    frameService.CreateFrame(myFrameShop, this, myFrame);
                    frameService.Save(myFrame);
                });
            }
        }
    }
}
