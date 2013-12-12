// Copyright 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using ProtoBuf;

namespace VsChromiumCore.Ipc.TypedMessages {
  [ProtoContract]
  [ProtoInclude(10, typeof(PairedTypedEvent))]
  [ProtoInclude(11, typeof(ProgressReportEvent))]
  public class TypedEvent : TypedMessage {
  }
}