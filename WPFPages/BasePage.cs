using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System;

namespace BasicCRUDTool
{

    /// <summary>
    /// A base page for all apges to gain base functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel
    {
        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private VM mViewModel;
        /// <summary>
        /// Animation to play when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        /// <summary>
        /// Animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimtation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        /// <summary>
        /// Time any slide animation takes
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        public BasePage()
        {
            // If animation hide page to start
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
           //Listen for page loading     
            this.Loaded += BasePage_Loaded;

            this.DataContext = mViewModel;
        }
        /// <summary>
        /// ONce the page is loaded perform required animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    //initate animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimtation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimtation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    //initate animation
                    await this.SlideAndFadeoutToLeft(this.SlideSeconds);
                    break;
            }

        }
    }
}
