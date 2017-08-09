using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace BlackScreenDetect
{
    public static class PsExtensions
    {
        public static List<PSObject> ExecutePs(this string script, bool writeToConsole = true)
        {
            var powerShell = PowerShell
                .Create()
                .AddScript(script);
            if (writeToConsole)
            {
                powerShell.AddCommand("Out-String");
                powerShell
                    .Invoke<PSObject>()
                    .ToList()
                    .WritePs();
            }
            // Lets the caller act on the returned collection
            // of PowerShell objects
            return powerShell
                .Invoke<PSObject>()
                .ToList();
        }
        public static void WritePs(this List<PSObject> psResults)
        {
            psResults.ForEach(Console.WriteLine);
        }
    }
}