using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class TimeOutEventArgs: EventArgs
    {

        #region Constructors

        public TimeOutEventArgs(int timeout)
        {
            Timeout = timeout;
        }

        #endregion

        #region Properties

        public int Timeout { get; }

        #endregion

    }
}
