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


namespace Sharpex2D.Debug.Logging.Adapters.Console
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public class ConsoleAdapter : IAdapter
    {
        /// <summary>
        /// Initializes a new ConsoleAdapter class.
        /// </summary>
        /// <param name="mode">The OutputMode.</param>
        public ConsoleAdapter(OutputMode mode)
        {
            OutputMode = mode;
        }

        /// <summary>
        /// Gets the OutputMode.
        /// </summary>
        public OutputMode OutputMode { private set; get; }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The Message.</param>
        public void Write(string message)
        {
            if (OutputMode == OutputMode.Error)
            {
                System.Console.Error.WriteLine(message);
            }
            else
            {
                System.Console.WriteLine(message);
            }
        }
    }
}