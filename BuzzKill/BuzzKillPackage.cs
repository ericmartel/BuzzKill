﻿/*
 * Copyright (c) 2013 Eric Martel <emartel@gmail.com> http://www.ericmartel.com

   Permission is hereby granted, free of charge, to any person obtaining a copy of this software
   and associated documentation files (the "Software"), to deal in the Software without restriction,
   including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
   and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
   subject to the following conditions:

   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
   OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
   LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
   CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;
using SlimDX;
using SlimDX.XInput;

namespace EricMartel.BuzzKill
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute makes the Extension load as soon as a Solution is Loaded
    [ProvideAutoLoad("{f1536ef8-92ec-443c-9ed7-fdadf150da82}")]
    [Guid(GuidList.guidBuzzKillPkgString)]
    public sealed class BuzzKillPackage : Package
    {
        // Keep a pointer to the events otherwise it gets Garbage Collected and nothing happens
        private EnvDTE.DebuggerEvents mEvents;
        private static Vibration mResetVibration;

        public EnvDTE.DebuggerEvents Events
        {
            get { return mEvents; }
            set
            {
                if (mEvents != null)
                {
                    mEvents.OnEnterBreakMode -= BreakHandler;
                }
                mEvents = value;
                if (mEvents != null)
                {
                    mEvents.OnEnterBreakMode += BreakHandler;
                    Trace.WriteLine("[BuzzKill] Attached to the Break Events");
                }
            }
        }

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public BuzzKillPackage()
        {
            Trace.WriteLine("Loaded BuzzKill");
        }

        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            DTE2 dte = GetService(typeof(DTE)) as DTE2;
            if (dte != null)
            {
                Events = dte.Events.DebuggerEvents;
            }

            mResetVibration = new Vibration();
            mResetVibration.LeftMotorSpeed = 0;
            mResetVibration.RightMotorSpeed = 0;
        }
        #endregion

        public static void BreakHandler(dbgEventReason reason, ref dbgExecutionAction execAction)
        {
            // UserIndex contains Users One to Four
            for (int i = 0; i < 4; ++i)
            {
                Controller controller = new Controller((UserIndex)i);
                if (controller != null && controller.IsConnected)
                {
                    controller.SetVibration(mResetVibration);
                }
            }
        }

    }
}
