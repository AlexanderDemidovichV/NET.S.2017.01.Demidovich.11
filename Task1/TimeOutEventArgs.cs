using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Provides a value to use for events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public sealed class TimeOutEventArgs: EventArgs
    {

        #region Constructors

        /// <summary>
        /// Initializes TimerStopEventArgs instance with the specified message and time.
        /// </summary>
        /// <param name="message">Sent message.</param>
        /// <param name="timeout">Elapsed time.</param>
        public TimeOutEventArgs(int timeout, string message)
        {
            Timeout = timeout;
            Message = message;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets elapsed time.
        /// </summary>
        public int Timeout { get; }

        /// <summary>
        /// Gets sent message by timer.
        /// </summary>
        public string Message { get; }

        #endregion

    }
}
