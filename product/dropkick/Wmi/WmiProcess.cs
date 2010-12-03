﻿namespace dropkick.Wmi
{
    using System;

    //Reference http://msdn.microsoft.com/en-us/library/aa389388(v=VS.85).aspx
    //Reference http://www.dalun.com/blogs/05.09.2007.htm

    class WmiProcess
    {
        const string CLASSNAME = "Win32_Process";
        //private char NULL_VALUE = char(0);

       public static ProcessReturnCode Run(string machineName, string commandLine, string currentDirectory)
        {
 
            try
            {
                const string methodName = "Create";
                Int32 processId = 0;

                var parameters = new object[]
                                     {
                                         commandLine, // CommandLine
                                         currentDirectory, // CurrentDirectory
                                         null, //Win32_ProcessStartup ProcessStartupInformation
                                         processId //out ProcessId
                                     };
                return (ProcessReturnCode)WmiHelper.InvokeStaticMethod(machineName, CLASSNAME, methodName, parameters);
            }
            catch
            {
                //throw;
                return ProcessReturnCode.UnknownFailure;
            }
        }

    }
}