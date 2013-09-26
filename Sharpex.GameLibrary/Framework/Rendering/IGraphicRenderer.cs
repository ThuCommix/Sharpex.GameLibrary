﻿using System;
using SharpexGL.Framework.Components;
using SharpexGL.Framework.Math;
using SharpexGL.Framework.Rendering.Font;

namespace SharpexGL.Framework.Rendering
{
    public interface IGraphicRenderer : IConstructable, IDisposable
    {
        /// <summary>
        /// Sets or gets the GraphicsDevice.
        /// </summary>
        GraphicsDevice GraphicsDevice
        {
            get;
            set;
        }
        /// <summary>
        /// Sets or gets the Frames per second.
        /// </summary>
        int FramesPerSecond
        {
            get;
        }
        /// <summary>
        /// Sets or gets whether the renderer is disposed.
        /// </summary>
        bool IsDisposed
        {
            get;
            set;
        }
        /// <summary>
        /// Begins the draw operation.
        /// </summary>
        void Begin();
        /// <summary>
        /// Flushes the buffer.
        /// </summary>
        void Close();
        /// <summary>
        /// Draws a Texture.
        /// </summary>
        /// <param name="texture">The Texture.</param>
        /// <param name="rectangle">The Rectangle.</param>
        /// <param name="color">The Color.</param>
        void DrawTexture(Texture texture, Rectangle rectangle, Color color);
        /// <summary>
        /// Draws a Texture.
        /// </summary>
        /// <param name="texture">The Texture.</param>
        /// <param name="position">The Position.</param>
        /// <param name="color">The Color.</param>
        void DrawTexture(Texture texture, Vector2 position, Color color);
        /// <summary>
        /// Draws a string.
        /// </summary>
        /// <param name="text">The Text.</param>
        /// <param name="spriteFont">The SpriteFont.</param>
        /// <param name="position">The Position.</param>
        /// <param name="color">The Color.</param>
        void DrawString(string text, SpriteFont spriteFont, Vector2 position, Color color);
    }
}