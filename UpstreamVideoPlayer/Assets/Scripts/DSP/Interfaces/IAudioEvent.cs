using System;

namespace Upstream
{
    /// <summary>
    /// Simple interface for implementing audio-based events
    /// </summary>
    public interface IAudioEvent
    {
        /// <summary>
        /// The event that should be fired whenever you want an "event" to happen.
        /// </summary>
        public event Action AudioEvent;
    }
}