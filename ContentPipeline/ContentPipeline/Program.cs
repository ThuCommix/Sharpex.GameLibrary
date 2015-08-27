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
using System.Linq;
using System.Reflection;
using Sharpex2D.Framework;
using ContentPipeline.Actions;

namespace ContentPipeline
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    internal class Program
    {
        private static int Main(string[] args)
        {
            var actionManager = new ActionManager();
            actionManager.AddRange(
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => typeof (IAction).IsAssignableFrom(x) && !x.IsInterface)
                    .Select(type => (IAction) Activator.CreateInstance(type)));

            IAction defaultAction = actionManager.First(x => x.GetType() == typeof (CompileAction));

            foreach (var action in from action in actionManager from arg in args where action.Option == arg select action)
            {
                defaultAction = action;
            }

            return defaultAction.Execute(args);
        }
    }
}