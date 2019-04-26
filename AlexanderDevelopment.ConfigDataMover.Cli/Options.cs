﻿// --------------------------------------------------------------------------------------------------------------------
// Options.cs
//
// Copyright 2015-2018 Lucas Alexander
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using System.Reflection;

namespace AlexanderDevelopment.ConfigDataMover.Cli
{
    class Options
    {
        [Option('c', "configfile", Required = true, HelpText = "Absolute or relative patch to XML file containing job data")]
        public string ConfigFile { get; set; }

        [Option('s', "source", Required = false, HelpText = "Data source, either a simplified CRM connection string to CRM source org -OR- path (absolute or relative to working directory) to source data file in the form of 'FILE=C:\\datadirectory\\datafile.json' -OR- raw JSON from export file in the form of 'RAWJSON={YOUR_EXPORT_JSON_HERE}' - optional if connection details are specified in config file.")]
        public string Source { get; set; }

        [Option('t', "target", Required = false, HelpText = "Data target, either a simplified CRM connection string to CRM target org -OR- path (absolute or relative to working directory) to target data file in the form of 'FILE=C:\\datadirectory\\datafile.json' - optional if connection details are specified in config file.")]
        public string Target { get; set; }

        [Option('v', "verbose", HelpText = "Print details during execution")]
        public bool Verbose { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("AlexanderDevelopment.ConfigDataMover.Cli", Assembly.GetExecutingAssembly().GetName().Version.ToString()),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.Copyright = string.Format(@"
Copyright 2015-{0} Lucas Alexander

This program comes with ABSOLUTELY NO WARRANTY. This is free software, and you are welcome to redistribute it and/or modify it under the terms of the Apache License, Version 2.0. You may obtain a copy at http://www.apache.org/licenses/LICENSE-2.0.
", DateTime.Now.Year);

            help.AddPreOptionsLine("Usage: AlexanderDevelopment.ConfigDataMover.Cli.exe -c configfile.xml -s \"Url=https://xxxx; Domain=xxxx; Username=xxxx; Password=xxxx;\" -t \"Url=https://xxxx; Domain=xxxx; Username=xxxx; Password=xxxx;\"");
            help.AddOptions(this);
            return help;
        }
    }
}
