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

using System.Drawing;
using Sharpex2D.Framework.Content.Pipeline;

namespace Sharpex2D.Framework.Rendering.GDI
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    [Content("Graphics Device Interface Texture")]
    public class GDITexture : Texture2D
    {
        #region Texture2D Implementation

        private readonly int _height;
        private readonly int _width;

        /// <summary>
        ///     Gets the Width.
        /// </summary>
        public override int Width
        {
            get { return _width; }
        }

        /// <summary>
        ///     Gets the Height.
        /// </summary>
        public override int Height
        {
            get { return _height; }
        }

        #endregion

        /// <summary>
        ///     Initializes a new GdiTexture class.
        /// </summary>
        /// <param name="bitmap">The Bitmap.</param>
        internal GDITexture(Bitmap bitmap)
        {
            Bmp = bitmap;
            _width = Bmp.Width;
            _height = Bmp.Height;
        }

        /// <summary>
        ///     Gets the GdiTexture data.
        /// </summary>
        internal Bitmap Bmp { private set; get; }
    }
}