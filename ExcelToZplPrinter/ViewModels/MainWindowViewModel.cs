using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ExcelToZplPrinter.Commands;
using ExcelToZplPrinter.Services;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ExcelToZplPrinter.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _copies;
        private bool _itemSplitter;
        private bool _isVertical;
        private int _fontSize;
        private int _documentHeight;
        private int _documentWidth;
        private bool _findFolderDialogOpen;
        private string _currentFolder;
        public int Copies
        {
            get { return _copies; }
            set
            {
                if(value == _copies) return;
                _copies = value;
                OnPropertyChanged();
            }
        }
        public bool ItemSplitter
        {
            get { return _itemSplitter; }
            set
            {
                if (value == _itemSplitter) return;
                _itemSplitter = value;
                OnPropertyChanged();
            }
        }
        public bool IsVertical
        {
            get { return _isVertical; }
            set
            {
                if(value == _isVertical) return;
                _isVertical = value;
                OnPropertyChanged();
            }
        }
        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                if (value == _fontSize) return;
                _fontSize = value;
                OnPropertyChanged();
            }
        }
        public int DocumentHeight
        {
            get { return _documentHeight; }
            set
            {
                if (value == _documentHeight) return;
                _documentHeight = value;
                OnPropertyChanged();
            }
        }
        public int DocumentWidth
        {
            get { return _documentWidth; }
            set
            {
                if(value == _documentWidth) return;
                _documentWidth = value;
                OnPropertyChanged();
            }
        }
        private bool FindFolderDialogOpen
        {
            get
            {
                return _findFolderDialogOpen;
            }

            set
            {
                if (value == _findFolderDialogOpen) return;
                _findFolderDialogOpen = value;
                OnPropertyChanged();
            }
        }
        public ICommand FindFolder { get; set; }
        public string CurrentFolder
        {
            get
            {
                return _currentFolder;
            }

            set
            {
                if(value == _currentFolder) return;
                _currentFolder = value;
                OnPropertyChanged();
            }
        }
       

        public MainWindowViewModel()
        {
            FindFolder = new RelayCommand(_findFolderLocation,_canFindFolder);
            DispatcherTimer welcomeMessageCaller = new DispatcherTimer(TimeSpan.Zero, DispatcherPriority.ApplicationIdle, ShowWelcomeMessage,
                Dispatcher.CurrentDispatcher);
        }

        private void ShowWelcomeMessage(object sender, EventArgs e)
        {
            DialogService.ShowMessage("Main", "", "Bem, vindo", MessageDialogStyle.Affirmative);
            ((DispatcherTimer)sender).Stop();
        }

        private bool _canFindFolder(object arg)
        {
            return !FindFolderDialogOpen;
        }

        private void _findFolderLocation(object obj)
        {
         
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.Title = "Selecione a Pasta";
            fileDialog.IsFolderPicker = true;
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            FindFolderDialogOpen = true;
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                CurrentFolder = fileDialog.FileName;
            }
            FindFolderDialogOpen = false;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
