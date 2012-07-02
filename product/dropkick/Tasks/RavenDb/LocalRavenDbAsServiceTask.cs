﻿// Copyright 2007-2012 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace dropkick.Tasks.RavenDb
{
    using CommandLine;
    using DeploymentModel;
    using FileSystem;

    public class LocalRavenDbAsServiceTask : BaseTask
    {
        readonly string _location;
        readonly LocalCommandLineTask _task;

        public LocalRavenDbAsServiceTask(string location)
        {
            _location = location;

            _task = new LocalCommandLineTask(new DotNetPath(), "Raven.Server.exe")
            {
                Args = "/install",
                ExecutableIsLocatedAt = location,
                WorkingDirectory = location
            };
        }

        public override string Name
        {
            get { return "[ravendb] Installing local RavenDb as a service from location {0}.".FormatWith(_location); }
        }

        public override DeploymentResult VerifyCanRun()
        {
            return _task.VerifyCanRun();
        }

        public override DeploymentResult Execute()
        {
            Logging.Coarse("[ravendb] Installing a local RavenDb as a service.");
            return _task.Execute();
        }
    }
}