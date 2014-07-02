// Copyright (c) 2012-2014 Sharpex2D - Kevin Scholz (ThuCommix)
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

using System;
using System.Globalization;
using Sharpex2D.Framework.Game;
using Sharpex2D.Framework.Input;

namespace Sharpex2D.Framework.UI.Input
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Untested)]
    public abstract class NumericBox : UIControl
    {
        private string _buffer = "";
        private decimal _decimalValue;
        private int _intValue;

        /// <summary>
        ///     Initializes a new NumericBox.
        /// </summary>
        /// <param name="mode">The NumericMode.</param>
        /// <param name="assignedUIManager">The assigned UIManager.</param>
        protected NumericBox(NumericMode mode, UIManager assignedUIManager) : base(assignedUIManager)
        {
            Mode = mode;
        }

        /// <summary>
        ///     Sets or gets the IntValue.
        /// </summary>
        public int IntValue
        {
            set
            {
                _intValue = value;
                _buffer = value.ToString(CultureInfo.InvariantCulture);
            }
            get { return _intValue; }
        }

        /// <summary>
        ///     Sets or gets the DecimalValue.
        /// </summary>
        public decimal DecimalValue
        {
            set
            {
                _decimalValue = value;
                _buffer = value.ToString(CultureInfo.InvariantCulture);
            }
            get { return _decimalValue; }
        }

        /// <summary>
        ///     Gets the DisplayValue.
        /// </summary>
        public string DisplayValue
        {
            get { return _buffer; }
        }

        /// <summary>
        ///     Sets or gets the mode.
        /// </summary>
        public NumericMode Mode { set; get; }

        /// <summary>
        ///     Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime.</param>
        public override void OnUpdate(GameTime gameTime)
        {
            //back
            if (IsKeyPressed(Keys.Back))
            {
                if (_buffer.Length > 1)
                {
                    _buffer = _buffer.Substring(0, _buffer.Length - 1);
                }
            }

            //handle -
            if (IsKeyPressed(Keys.OemMinus))
            {
                if (_buffer == "")
                {
                    _buffer = "-";
                }
            }

            //numbers
            if (IsKeyPressed(Keys.D0))
            {
                _buffer += "0";
            }
            if (IsKeyPressed(Keys.D1))
            {
                _buffer += "1";
            }
            if (IsKeyPressed(Keys.D2))
            {
                _buffer += "2";
            }
            if (IsKeyPressed(Keys.D3))
            {
                _buffer += "3";
            }
            if (IsKeyPressed(Keys.D4))
            {
                _buffer += "4";
            }
            if (IsKeyPressed(Keys.D5))
            {
                _buffer += "5";
            }
            if (IsKeyPressed(Keys.D6))
            {
                _buffer += "6";
            }
            if (IsKeyPressed(Keys.D7))
            {
                _buffer += "7";
            }
            if (IsKeyPressed(Keys.D8))
            {
                _buffer += "8";
            }
            if (IsKeyPressed(Keys.D9))
            {
                _buffer += "9";
            }

            //handle point
            if (Mode == NumericMode.Decimal)
            {
                if (IsKeyPressed(Keys.Oemcomma))
                {
                    if (!_buffer.Contains("."))
                    {
                        _buffer += ".";
                    }
                }
            }

            ConvertBuffer();
            base.OnUpdate(gameTime);
        }

        /// <summary>
        ///     Converts the Buffer.
        /// </summary>
        private void ConvertBuffer()
        {
            if (Mode == NumericMode.Int)
            {
                IntValue = Convert.ToInt32(_buffer);
            }
            else
            {
                DecimalValue = Convert.ToDecimal(_buffer);
            }
        }
    }
}