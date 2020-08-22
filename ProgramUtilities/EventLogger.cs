using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUtilities

{/// <summary>
/// Static event logger class that allows the messages to be passed from each classLibrary to the UI layer using an Event
/// </summary>
/// 
   
    public class EventLogger
    {
        public static event EventHandler<string> LogEntryAdded;

        protected static void OnLogEntryAdded(string logEntry) => LogEntryAdded?.Invoke(null, logEntry);

        public static void CreateLogEntry(string logEntry) => OnLogEntryAdded(logEntry);
    }
}
