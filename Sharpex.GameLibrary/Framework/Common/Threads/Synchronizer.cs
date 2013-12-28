﻿using System;
using System.Collections.Generic;

namespace SharpexGL.Framework.Common.Threads
{
    internal class Synchronizer
    {

        private readonly List<SynchronizeObject> _objects; 

        /// <summary>
        /// Initializes a new Synchronizer class.
        /// </summary>
        public Synchronizer()
        {
            _objects = new List<SynchronizeObject>();
        }

        /// <summary>
        /// A value indicating whether the two Objects are synced.
        /// </summary>
        public bool IsSynced {
            get { return InternalIsSynced(); }
        }

        /// <summary>
        /// InternalIsSynced.
        /// </summary>
        /// <returns>True if synced.</returns>
        private bool InternalIsSynced()
        {
            for (var i = 0; i <= _objects.Count - 1; i++)
            {
                if (!_objects[i].Synced)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Synchronizes into the Synchronizer.
        /// </summary>
        /// <returns>SynchronizeObject</returns>
        public SynchronizeObject Synchronize()
        {
            var syncobject = new SynchronizeObject(Guid.NewGuid());
            _objects.Add(syncobject);
            return syncobject;
        }
        /// <summary>
        /// Asynchronizes from the Synchronizer.
        /// </summary>
        /// <param name="syncObject">The SynchronizeObject</param>
        public void Asynchron(SynchronizeObject syncObject)
        {
            if (_objects.Contains(syncObject))
            {
                _objects.Remove(syncObject);
            }
        }

        internal class SynchronizeObject
        {
            /// <summary>
            /// Initializes a new SynchronizeObject class.
            /// </summary>
            /// <param name="guid">The Guid.</param>
            internal SynchronizeObject(Guid guid)
            {
                Guid = guid;
                Synced = true;
            }

            /// <summary>
            /// A value indicating whether the SynchronizeObject is synced.
            /// </summary>
            public bool Synced { set; get; }
            /// <summary>
            /// Gets the Guid.
            /// </summary>
            public Guid Guid { private set; get; }
        }
    }
}
