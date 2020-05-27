using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BasicCRUDTool
{
    class WindowViewModel : BaseViewModel
    {
        #region Private Member

        private Window mWindow;
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;
        private int mInnerContentPaddingsize = 6;

        #endregion

        #region Public Properties
        public double WindowMinimumWidth { get; set; } = 900;
        public double WindowMinimumHeight { get; set; } = 600;
        public double TitleHeight { get; set; } = 42; 

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        public Thickness InnerContentPadding { get { return new Thickness(mInnerContentPaddingsize); } }
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }

            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }

            set
            {
                mWindowRadius = value;
            }
        }

        public CornerRadius WindowRadiusCornerRadius { get { return new CornerRadius(WindowRadius);  } }

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximiseCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        #endregion


        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += MWindow_StateChanged;

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximiseCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, mWindow.PointToScreen(Mouse.GetPosition(mWindow))));
        }

        private void MWindow_StateChanged(object sender, EventArgs e)
        {
            //Create event for all resize properties when resized
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowRadiusCornerRadius));

        }
    }
}
