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

using Sharpex2D.Framework.Network.Protocols;

namespace Sharpex2D.Framework.Network.Logic
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public interface IClientListener
    {
        /// <summary>
        ///     Gets the client instance.
        /// </summary>
        IClient Client { get; }

        /// <summary>
        ///     Called if a client joined on the server.
        /// </summary>
        /// <param name="connection">The IPAddress.</param>
        void OnClientJoined(IConnection connection);

        /// <summary>
        ///     Called if a client exited.
        /// </summary>
        /// <param name="connection">The IPAddress.</param>
        void OnClientExited(IConnection connection);

        /// <summary>
        ///     Called if the server sends a client list.
        /// </summary>
        /// <param name="connections">The Connections.</param>
        void OnClientListing(IConnection[] connections);

        /// <summary>
        ///     Called if the server is closing.
        /// </summary>
        void OnServerShutdown();

        /// <summary>
        ///     Called, if our client timed out.
        /// </summary>
        void OnClientTimedOut();
    }
}