﻿// Copyright (c) 2012-2014 Sharpex2D - Kevin Scholz (ThuCommix)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the 'Software'), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Sharpex2D.Input.JoystickApi
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Untested)]
    public class JoystickButton
    {
        /// <summary>
        ///     Initializes a new JoystickButton class.
        /// </summary>
        /// <param name="state">The Button State.</param>
        internal JoystickButton(bool state)
        {
            IsPressed = state;
        }

        /// <summary>
        ///     A value indicating whether the JoystickButton is pressed.
        /// </summary>
        public bool IsPressed { private set; get; }

        /// <summary>
        ///     Creates a new JoystickButtom from dwButtons.
        /// </summary>
        /// <param name="buttonIndex">The ButtonIndex.</param>
        /// <param name="dwButtons">The dwButtons.</param>
        /// <returns>JoystickButton.</returns>
        internal static JoystickButton FromDwButtons(int buttonIndex, uint dwButtons)
        {
            int button = 2 ^ (buttonIndex - 1);
            return new JoystickButton(((dwButtons & button) != 0));
        }
    }
}