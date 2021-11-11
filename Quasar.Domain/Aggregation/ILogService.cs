using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Quasar.Domain.Aggregation
{
    public interface ILogService
    {
        void WriteLog(string message, [CallerMemberName] string memberName = "");

        void WriteError(string message, [CallerMemberName] string memberName = "");

        void WriteException(string message, [CallerMemberName] string memberName = "");

    }
}
