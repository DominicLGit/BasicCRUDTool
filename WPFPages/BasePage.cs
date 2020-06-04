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
    public class BasePage : Page
    {
        /// <summary>
        /// Animation to play when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        /// <summary>
        /// Animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimtation { get; set; } = PageAnimation.SlideAndFadeInFromLeft;
        /// <summary>
        /// Time any slide animation takes
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        public BasePage()
        {
            // If animation hide page to start
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
           //Listen for page loading     
            this.Loaded += BasePage_Loaded;
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

                case PageAnimation.SlideAndFadeInFromLeft:
                    //initate animation
                    await this.SlideAndFadeoutFromLeft(this.SlideSeconds);
                    break;
            }
        }
    }
}
