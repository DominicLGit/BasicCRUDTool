using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace BasicCRUDTool
{
    /// <summary>
    /// Animation helps for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Slide from right animation for storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add to</param>
        /// <param name="seconds">time for animation</param>
        /// <param name="offset">distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Slide to left animation for storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add to</param>
        /// <param name="seconds">time for animation</param>
        /// <param name="offset">distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlidetoLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Fade in animation for storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add to</param>
        /// <param name="seconds">time for animation</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };

            // Set the property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Fade out animation for storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add to</param>
        /// <param name="seconds">time for animation</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };

            // Set the property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }
    }
}
