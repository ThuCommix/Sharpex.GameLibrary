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
using System.Collections.Generic;
using Sharpex2D.Content;

namespace Sharpex2D.Rendering.Scene
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public class SceneManager : IGameComponent, IComponent
    {
        /// <summary>
        /// SceneEventHandler.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">The EventArgs.</param>
        public delegate void SceneEventHandler(object sender, SceneEventArgs e);

        private readonly List<Scene> _scenes;
        private Scene _activeScene;

        /// <summary>
        /// Initializes a new SceneManager class.
        /// </summary>
        public SceneManager()
        {
            _scenes = new List<Scene>();
            Order = 0;
        }

        /// <summary>
        /// Gets the scenes.
        /// </summary>
        public Scene[] Scenes
        {
            get { return _scenes.ToArray(); }
        }

        /// <summary>
        /// Gets the ActiveScene.
        /// </summary>
        public Scene ActiveScene
        {
            get { return _activeScene; }
            set
            {
                if (value == null) return;
                var args = new SceneEventArgs(_activeScene, value);
                if (_activeScene != null)
                {
                    _activeScene.OnSceneDeactivated();
                }
                _activeScene = value;
                value.OnSceneActivated();
                if (SceneChanged != null)
                {
                    SceneChanged(this, args);
                }
            }
        }

        #region IComponent Implementation

        /// <summary>
        /// Sets or gets the Guid of the Component.
        /// </summary>
        public Guid Guid
        {
            get { return new Guid("00C8ED49-0C1B-47A8-B990-C71F5C4CB09E"); }
        }

        #endregion

        #region IGameComponent Implementation

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order { get; private set; }

        #endregion

        /// <summary>
        /// Updates the object.
        /// </summary>
        /// <param name="gameTime">The GameTime.</param>
        public void Update(GameTime gameTime)
        {
            if (ActiveScene != null)
            {
                ActiveScene.Update(gameTime);
            }
        }

        /// <summary>
        /// Processes a Render.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch.</param>
        /// <param name="gameTime">The GameTime.</param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (ActiveScene != null)
            {
                ActiveScene.Draw(spriteBatch, gameTime);
            }
        }

        /// <summary>
        /// SceneChanged event.
        /// </summary>
        public event SceneEventHandler SceneChanged;

        /// <summary>
        /// Gets a specified scene.
        /// </summary>
        /// <typeparam name="T">The Scene.</typeparam>
        /// <returns>Scene.</returns>
        public T Get<T>() where T : Scene
        {
            for (int i = 0; i <= _scenes.Count - 1; i++)
            {
                if (_scenes[i].GetType() == typeof (T))
                {
                    return (T) _scenes[i];
                }
            }

            throw new InvalidOperationException("The scene " + typeof (T).Name + " is not available.");
        }

        /// <summary>
        /// Adds a new Scene.
        /// </summary>
        /// <param name="scene">The Scene.</param>
        public void AddScene(Scene scene)
        {
            scene.Initialize();
            scene.LoadContent(SGL.Components.Get<ContentManager>());
            _scenes.Add(scene);
        }

        /// <summary>
        /// Adds a new Scene fluently.
        /// </summary>
        /// <param name="scene">The Scene.</param>
        /// <returns>The specified scene.</returns>
        public Scene AddSceneFluently(Scene scene)
        {
            scene.Initialize();
            scene.LoadContent(SGL.Components.Get<ContentManager>());
            _scenes.Add(scene);
            return scene;
        }

        /// <summary>
        /// Removes a Scene.
        /// </summary>
        /// <param name="scene">The Scene.</param>
        public void RemoveScene(Scene scene)
        {
            _scenes.Remove(scene);
        }

        /// <summary>
        /// Removes all Scenes.
        /// </summary>
        public void ClearScenes()
        {
            _scenes.Clear();
        }
    }
}