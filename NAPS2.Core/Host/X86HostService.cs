﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Windows.Forms;
using NAPS2.Scan;
using NAPS2.Scan.Images;
using NAPS2.Scan.Twain;

namespace NAPS2.Host
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class X86HostService : IX86HostService
    {
        private readonly TwainWrapper twainWrapper;

        public Form ParentForm { get; set; }

        public X86HostService(TwainWrapper twainWrapper)
        {
            this.twainWrapper = twainWrapper;
        }

        public void DoWork()
        {
            MessageBox.Show("Hi from " + Process.GetCurrentProcess().Id + "!");
        }

        public ScanDevice TwainPromptForDevice(IntPtr hwnd)
        {
            return twainWrapper.PromptForDevice();
        }

        public List<IScannedImage> TwainScan(IntPtr hwnd, ScanDevice scanDevice, ScanProfile scanProfile, ScanParams scanParams)
        {
            return twainWrapper.Scan(ParentForm, scanDevice, scanProfile, scanParams);
        }
    }
}
