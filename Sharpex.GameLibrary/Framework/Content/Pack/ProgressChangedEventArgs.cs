﻿using System;

namespace SharpexGL.Framework.Content.Pack
{
    public class ProgressChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the current progress percentage.
        /// </summary>
        public int Percentage {private set; get; }

        /// <summary>
        /// Initializes a new ProgressChangedEventArgs class.
        /// </summary>
        /// <param name="percentage">The Percentage.</param>
        internal ProgressChangedEventArgs(int percentage)
        {
            Percentage = percentage;
        }
    }
}