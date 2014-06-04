﻿using System;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams;

namespace Sharpex2D.Framework.Media.Sound.Wasapi
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Tested)]
    public class WasapiSoundProvider : ISoundProvider
    {
        #region IComponent Implementation
        /// <summary>
        /// Gets the Guid.
        /// </summary>
        public Guid Guid { get { return new Guid("F08568B6-2426-444F-8562-827AFCA55E36"); } }
        #endregion

        /// <summary>
        /// Initializes a new WasapiSoundProvider class.
        /// </summary>
        internal WasapiSoundProvider()
        {
            _soundOut = new WasapiOut(false, CSCore.CoreAudioAPI.AudioClientShareMode.Shared, 100);
        }

        private ISoundOut _soundOut;
        private PanSource _panSource;

        private bool _disposed;

        /// <summary>
        /// Disposes the SoundProvider.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the SoundProvider.
        /// </summary>
        /// <param name="disposing">The State.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_soundOut != null)
                {
                    Stop();
                    _soundOut.Dispose();
                    _soundOut = null;
                    _panSource = null;
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Deconstructs the SoundProvider.
        /// </summary>
        ~WasapiSoundProvider()
        {
            Dispose(false);
        }

        /// <summary>
        /// Clones the SoundProvider.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
        /// <param name="soundFile">The Soundfile.</param>
        /// <param name="playMode">The PlayMode.</param>
        public void Play(Sound soundFile, PlayMode playMode)
        {
            Play(CodecFactory.Instance.GetCodec(soundFile.ResourcePath), playMode);
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
        /// <param name="waveSource">The WaveSource.</param>
        /// <param name="playMode">The PlayMode.</param>
        private void Play(IWaveSource waveSource, PlayMode playMode)
        {
            Stop();
            if (playMode == PlayMode.Loop)
                waveSource = new LoopStream(waveSource);

            var panSource = new PanSource(waveSource);
            _soundOut.Initialize(panSource.ToWaveSource(16));
            _panSource = panSource;
            IsPlaying = true;
        }

        /// <summary>
        /// Stops the sound.
        /// </summary>
        private void Stop()
        {
            if (PlaybackState != PlaybackState.Stopped)
            {
                _soundOut.Stop();
                IsPlaying = false;
            }
        }

        /// <summary>
        /// Gets the PlaybackState.
        /// </summary>
        private PlaybackState PlaybackState
        {
            get { return _soundOut.PlaybackState; }
        }

        /// <summary>
        /// Resumes a sound.
        /// </summary>
        public void Resume()
        {
            _soundOut.Resume();
        }

        /// <summary>
        /// Pause a sound.
        /// </summary>
        public void Pause()
        {
            _soundOut.Pause();
            IsPlaying = false;
        }

        /// <summary>
        /// Seeks a sound to a specified position.
        /// </summary>
        /// <param name="position">The Position.</param>
        public void Seek(long position)
        {
            if (_soundOut.WaveSource != null)
                _soundOut.WaveSource.Position = position;
        }

        /// <summary>
        /// Sets or gets the Position.
        /// </summary>
        public long Position
        {
            get { return _soundOut.WaveSource != null ? _soundOut.WaveSource.Position : 0; }
            set { Seek(value); }
        }

        /// <summary>
        /// A value indicating whether the SoundProvider is playing.
        /// </summary>
        public bool IsPlaying { get; set; }

        /// <summary>
        /// Gets the sound length.
        /// </summary>
        public long Length
        {
            get { return _soundOut.WaveSource != null ? _soundOut.WaveSource.Length : 0; }
        }

        /// <summary>
        /// Sets or gets the Balance.
        /// </summary>
        public float Balance
        {
            get { return _panSource.Pan; }
            set { _panSource.Pan = value; }
        }

        /// <summary>
        /// Sets or gets the Volume.
        /// </summary>
        public float Volume
        {
            get { return _soundOut.Volume; }
            set { _soundOut.Volume = value; }
        }
    }
}
