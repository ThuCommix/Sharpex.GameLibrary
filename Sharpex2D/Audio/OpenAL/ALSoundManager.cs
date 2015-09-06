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

using System.Collections.Generic;

namespace Sharpex2D.Framework.Audio.OpenAL
{
    public class ALSoundManager : SoundManager
    {
        /// <summary>
        /// A value indicating whether the openal sound manager is supported
        /// </summary>
        public override bool IsSupported => ALInterops.IsSupported();

        /// <summary>
        /// Creates a new openal sound player
        /// </summary>
        /// <returns>ISoundPlayer</returns>
        public override ISoundPlayer Create()
        {
            return new ALSoundPlayer();
        }

        /// <summary>
        /// Enumerates the playback devices
        /// </summary>
        /// <returns>Enumerable playback devices</returns>
        public override IEnumerable<IPlaybackDevice> EnumerateDevices()
        {
            return ALDevice.EnumerateALDevices();
        }
    }
}