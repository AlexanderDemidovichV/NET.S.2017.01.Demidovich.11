using System;
using System.ComponentModel;
using System.Threading;
using System.Timers;

namespace Task1
{
    /// <summary>
    /// Generates an event after a set interval.
    /// </summary>
    public class Timer
    {

        #region Public Events

        /// <summary>
        /// Gets the list of event handlers that are attached to this object.
        /// </summary>
        public event EventHandler<TimeOutEventArgs> TimeOut = delegate { };

        #endregion

        #region Protected Methods

        /// <summary>
        /// Occurs when the interval elapses.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimeOutEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTimeOut(object sender, TimeOutEventArgs e) => TimeOut(sender, e);

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the Interval to the specified number of milliseconds.
        /// </summary>
        /// <param name="elapse">A time to wait.</param>
        /// <param name="message">A message.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">elapse</exception>
        public void SetTimer(int elapse, string message)
        {
            if (elapse < 0)
                throw new ArgumentOutOfRangeException($"{nameof(elapse)} is less than zero.");
            if (ReferenceEquals(message, null))
                throw new ArgumentNullException($"{nameof(message)} is null.");
            Thread.Sleep(elapse);
            OnTimeOut(this, new TimeOutEventArgs(elapse, message));
        }

        #endregion

    }
}
