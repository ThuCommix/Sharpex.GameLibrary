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

namespace Sharpex2D.Framework
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [TestState(TestState.Tested)]
    public class MetaDataReader
    {
        /// <summary>
        /// Reads the MetaData.
        /// </summary>
        /// <param name="obj">The Object.</param>
        /// <returns>MetaDataCollection.</returns>
        public static MetaDataCollection ReadMetaData(object obj)
        {
            return ReadMetaData(obj.GetType());
        }

        /// <summary>
        /// Reads the MetaData.
        /// </summary>
        /// <param name="type">The Type.</param>
        /// <returns>MetaDataCollection.</returns>
        public static MetaDataCollection ReadMetaData(Type type)
        {
            MetaDataAttribute[] data = AttributeHelper.GetAttributes<MetaDataAttribute>(type);
            var dataCollection = new MetaDataCollection();

            foreach (MetaDataAttribute metaData in data)
            {
                if (dataCollection.ContainsKey(metaData.Name)) continue;

                dataCollection.Add(metaData.Name, metaData.Data);
            }

            return dataCollection;
        }
    }
}