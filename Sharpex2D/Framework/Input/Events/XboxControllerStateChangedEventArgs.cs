﻿using Sharpex2D.Framework.Events;
using Sharpex2D.Framework.Input.XInput;

namespace Sharpex2D.Framework.Input.Events
{
    public class XboxControllerStateChangedEventArgs : IEvent
    {
        /// <summary>
        /// Sets or gets the CurrentInputState.
        /// </summary>
        public XInputState CurrentInputState { get; set; }
        /// <summary>
        /// Sets or gets the PreviousInputState.
        /// </summary>
        public XInputState PreviousInputState { get; set; }
    }
}