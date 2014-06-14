﻿using System;
using System.Threading;
using Sharpex2D.Framework.Game;
using Sharpex2D.Framework.Math;

namespace Sharpex2D.Framework.Rendering.Effects
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Tested)]
    public class Blend : IEffect
    {
        #region IEffect Implementation

        /// <summary>
        ///     Gets the Guid-Identifer.
        /// </summary>
        public Guid Guid
        {
            get { return new Guid("199266BF-94EA-4B1C-BF2B-117B3B13FCAB"); }
        }

        /// <summary>
        ///     Sets or gets the Duration.
        /// </summary>
        public float Duration { get; set; }

        /// <summary>
        ///     Starts the Effect.
        /// </summary>
        public void Start()
        {
            if (!_issubscribed)
            {
                _scaling = 255/Duration;
                _drawingRect = new Rectangle(-8, -5, SGL.GraphicsDevice.DisplayMode.Width + 20,
                    SGL.GraphicsDevice.DisplayMode.Height + 20);
                _finished = false;
                Completed = false;
                _issubscribed = true;
            }
        }

        /// <summary>
        ///     A value indicating whether the Effect is completed.
        /// </summary>
        public bool Completed { private set; get; }

        /// <summary>
        ///     Gets the Callback action.
        /// </summary>
        public Action Callback { private set; get; }

        #endregion

        #region IGameHandler Implementation

        /// <summary>
        ///     Constructs the Component
        /// </summary>
        public void Construct()
        {
        }

        /// <summary>
        ///     Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime.</param>
        public void Update(GameTime gameTime)
        {
            if (_finished)
            {
                if (!_finishFired)
                {
                    _finishFired = true;
                    _issubscribed = false;
                    Completed = true;
                    if (Callback != null)
                    {
                        // Invoke callback
                        new Thread(() => Callback.Invoke()).Start();
                    }
                }
            }
            else
            {
                if (!_issubscribed) return;
                float deltaA = _scaling*gameTime.ElapsedGameTime;
                if (_blendMode == BlendMode.FadeIn)
                {
                    if (_alpha - deltaA > 0)
                    {
                        _alpha -= deltaA;
                    }
                    else
                    {
                        _alpha = 0;
                        _finished = true;
                    }

                    _color.A = (byte) _alpha;
                }
                else
                {
                    if (_alpha + deltaA < 255)
                    {
                        _alpha += deltaA;
                    }
                    else
                    {
                        _alpha = 255;
                        _finished = true;
                    }
                    _color.A = (byte) _alpha;
                }
            }
        }

        /// <summary>
        ///     Processes a Render.
        /// </summary>
        /// <param name="renderer">The GraphicRenderer.</param>
        /// <param name="gameTime">The GameTime.</param>
        public void Render(IRenderer renderer, GameTime gameTime)
        {
            /*/renderer.DrawTexture(_overlay,
                _drawingRect,
                _color);/*/
            if (!_issubscribed) return;
            renderer.FillRectangle(_color, _drawingRect);
        }

        #endregion

        private readonly BlendMode _blendMode;
        private float _alpha;
        private Color _color;
        private Rectangle _drawingRect;
        private bool _finishFired;
        private bool _finished;
        private bool _issubscribed;
        private float _scaling;

        /// <summary>
        ///     Initializes a new Blend class.
        /// </summary>
        /// <param name="callback">The Callback Action.</param>
        /// <param name="blendMode">The BlendMode.</param>
        public Blend(Action callback, BlendMode blendMode)
        {
            //var bmp = new Bitmap(100, 100);
            //_overlay = new Texture {Texture2D = bmp};
            _color = Color.Black;
            _color.A = blendMode == BlendMode.FadeIn ? (byte) 255 : (byte) 0;
            _alpha = blendMode == BlendMode.FadeIn ? 255 : 0;
            _finished = false;
            Callback = callback;
            _blendMode = blendMode;
        }
    }
}