using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BasicCRUDTool
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            //create storyboard
            var sb = new Storyboard();

            //add animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);
            //add animation
            sb.AddFadeIn(seconds);
            //start animation
            sb.Begin(page);
            //make page visible for animation
            page.Visibility = Visibility.Visible;

            //wait for end
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeoutFromLeft(this Page page, float seconds)
        {
            //create storyboard
            var sb = new Storyboard();

            //add animation
            sb.AddSlidetoLeft(seconds, page.WindowWidth);
            //add animation
            sb.AddFadeOut(seconds);
            //start animation
            sb.Begin(page);
            //make page visible for animation
            page.Visibility = Visibility.Visible;

            //wait for end
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
