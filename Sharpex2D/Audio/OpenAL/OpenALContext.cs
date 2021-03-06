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

using System;

namespace Sharpex2D.Audio.OpenAL
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    internal class OpenALContext
    {
        /// <summary>
        /// Gets the handle of the openal context.
        /// </summary>
        private readonly IntPtr _handle;

        /// <summary>
        /// Creates a new OpenALContext class.
        /// </summary>
        /// <param name="contextHandle">The ContextHandle.</param>
        private OpenALContext(IntPtr contextHandle)
        {
            _handle = contextHandle;
        }

        /// <summary>
        /// Makes the context the current Context.
        /// </summary>
        public void MakeCurrent()
        {
            OpenAL.alcMakeContextCurrent(_handle);
        }

        /// <summary>
        /// Destroys the Context.
        /// </summary>
        public void Destroy()
        {
            OpenAL.alcDestroyContext(_handle);
        }

        /// <summary>
        /// Creates a new OpenALContext on the specified OpenALDevice.
        /// </summary>
        /// <param name="openALDeviceHandle">The OpenALDevice.</param>
        public static OpenALContext CreateContext(IntPtr openALDeviceHandle)
        {
            return new OpenALContext(OpenAL.alcCreateContext(openALDeviceHandle, IntPtr.Zero));
        }
    }
}