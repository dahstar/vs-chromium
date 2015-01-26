// Copyright 2015 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Design;
using Microsoft.VisualStudio;
using VsChromium.Package;
using VsChromium.Package.CommandHandler;

namespace VsChromium.Features.ToolWindows.SourceExplorer {
  [Export(typeof(IPackagePriorityCommandHandler))]
  public class GotoNextLocationPriorityCommandHandler : PackagePriorityCommandHandlerBase {
    private readonly IVisualStudioPackageProvider _visualStudioPackageProvider;

    [ImportingConstructor]
    public GotoNextLocationPriorityCommandHandler(IVisualStudioPackageProvider visualStudioPackageProvider) {
      _visualStudioPackageProvider = visualStudioPackageProvider;
    }

    public override CommandID CommandId {
      get {
        return new CommandID(VSConstants.GUID_VSStandardCommandSet97, (int)VSConstants.VSStd97CmdID.NextLocation);
      }
    }

    public override bool Supported {
      get {
        var window = _visualStudioPackageProvider.Package.FindToolWindow(typeof(SourceExplorerToolWindow), 0, false) as SourceExplorerToolWindow;
        if (window == null)
          return false;
        if (!window.IsVisible)
          return false;
        return window.HasNextLocation();
      }
    }

    public override void Execute(object sender, EventArgs e) {
      var window = _visualStudioPackageProvider.Package.FindToolWindow(typeof(SourceExplorerToolWindow), 0, false) as SourceExplorerToolWindow;
      if (window == null)
        return;
      window.NavigateToNextLocation();
    }
  }
}