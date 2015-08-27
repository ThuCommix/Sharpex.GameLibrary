﻿// Copyright (c) 2012-2015 Sharpex2D - Kevin Scholz (ThuCommix)
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
using System.Runtime.Serialization;

namespace Sharpex2D.Framework.Network
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public class ConnectionRefusedException : Exception
    {
        /// <summary>
        /// Initializes a new ConnectionRefusedException class.
        /// </summary>
        public ConnectionRefusedException()
        {
        }

        /// <summary>
        /// Initializes a new ConnectionRefusedException class.
        /// </summary>
        /// <param name="message">The Message.</param>
        public ConnectionRefusedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new ConnectionRefusedException class.
        /// </summary>
        /// <param name="message">The Message.</param>
        /// <param name="innerException">The InnerException.</param>
        public ConnectionRefusedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new ConnectionRefusedException class.
        /// </summary>
        /// <param name="info">The Info.</param>
        /// <param name="context">The Context.</param>
        public ConnectionRefusedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}