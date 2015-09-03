// Copyright (c) 2012-2015 Sharpex2D - Kevin Scholz (ThuCommix)
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
using Sharpex2D.Framework.Content;

namespace Sharpex2D.Framework.Audio
{
    public class SoundEffect : IContent
    {
        private readonly ISoundPlayer _audioProvider;

        /// <summary>
        /// Initializes a new AudioEffect class.
        /// </summary>
        internal SoundEffect() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new AudioEffect class.
        /// </summary>
        /// <param name="sound">The Sound.</param>
        public SoundEffect(Sound sound)
        {
            Sound = sound;
            SoundManager soundManager = GameHost.Get<SoundPlayer>().SoundManager;

            if (soundManager == null)
            {
                Logger.Instance.Warn("The specified SoundManager was null.");
            }
            else if (!soundManager.IsSupported)
            {
                Logger.Instance.Warn("The specified SoundManager is not supported.");
            }
            else
            {
                _audioProvider = soundManager.Create();
                _audioProvider.PlaybackChanged += PlaybackChanged;
            }
        }

        /// <summary>
        /// Gets or sets the Sound.
        /// </summary>
        public Sound Sound { internal set; get; }

        /// <summary>
        /// Gets or sets the Volume.
        /// </summary>
        public float Volume
        {
            get { return _audioProvider.Volume; }
            set { _audioProvider.Volume = value; }
        }

        /// <summary>
        /// Gets or sets the Pan.
        /// </summary>
        public float Pan
        {
            get { return _audioProvider.Pan; }
            set { _audioProvider.Pan = value; }
        }

        /// <summary>
        /// Gets the PlaybackState.
        /// </summary>
        public PlaybackState PlaybackState => _audioProvider.PlaybackState;

        /// <summary>
        /// Gets or sets the playback device
        /// </summary>
        public IPlaybackDevice PlaybackDevice
        {
            get { return _audioProvider.PlaybackDevice; }
            set { _audioProvider.PlaybackDevice = value; }
        }

        /// <summary>
        /// Initializes the audio effect.
        /// </summary>
        public void Initialize()
        {
            if (Sound == null) throw new NullReferenceException("Sound was null.");
            _audioProvider.Initialize(Sound.GetAudioStream(), Sound.Format);
        }

        /// <summary>
        /// Triggered if the playback state changed.
        /// </summary>
        public event EventHandler<EventArgs> PlaybackStateChanged;

        /// <summary>
        /// Triggered if the playback state changed.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">The EventArgs.</param>
        private void PlaybackChanged(object sender, EventArgs e)
        {
            PlaybackStateChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Plays the specified audio source.
        /// </summary>
        public void Play()
        {
            _audioProvider.Play(PlaybackMode.None);
        }
    }
}
