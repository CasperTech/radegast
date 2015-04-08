// 
// METABolt Metaverse Client, forked from RADISHGHAST
// Copyright (c) 2015, METABolt Development Team
// Copyright (c) 2009-2014, RADISHGHAST Development Team
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name "METAbolt", nor "RADISHGHAST", nor the names of its
//       contributors may be used to endorse or promote products derived from
//       this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// $Id$
//
using System;
using System.Reflection;
using System.IO;
using OpenMetaverse;

namespace METAbolt.Commands
{
    public class LoadPluginCommand : IMETAboltCommand
    {
        private METAboltInstance instance;
        public string Name
        {
            get { return "loadplugin"; }
        }

        public string Description
        {
            get { return "Loads plugins from a path"; }
        }

        public string Usage
        {
            get { return "loadplugin c:\\\\myplugindir\\\\plugin.dll"; }
        }

        public void StartCommand(METAboltInstance inst)
        {
            instance = inst;
        }

        public void Dispose()
        {
            instance = null;
        }

        public void Execute(string n, string[] cmdArgs, ConsoleWriteLine WriteLine)
        {
            string loadfilename = String.Join(" ", cmdArgs);
            try
            {
                instance.PluginManager.LoadAssembly(loadfilename, true);
            }
            catch (Exception ex)
            {
                WriteLine("ERROR in METAbolt Plugin: {0} because {1} {2}", loadfilename, ex.Message, ex.StackTrace);
            }
        }
    }
}