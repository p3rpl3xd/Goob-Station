// SPDX-FileCopyrightText: 2026 Aidenkrz <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2026 Aiden <aiden@djkraz.com>
// SPDX-License-Identifier: AGPL-3.0-or-later

using System.Diagnostics.CodeAnalysis;
using Content.Client.Guidebook.Richtext;
using Content.VoiceChat.Client.UI;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.Goobstation.Client.Voice;

public sealed partial class VoiceChatConnectPanel : BoxContainer, IDocumentTag
{
    public VoiceChatConnectPanel()
    {
        AddChild(new VoiceConnectPanel());
    }

    public bool TryParseTag(Dictionary<string, string> args, [NotNullWhen(true)] out Control? control)
    {
        control = this;
        return true;
    }
}

public sealed partial class VoiceChatStatusCard : BoxContainer, IDocumentTag
{
    public VoiceChatStatusCard()
    {
        AddChild(new VoiceConnectPanel());
    }

    public bool TryParseTag(Dictionary<string, string> args, [NotNullWhen(true)] out Control? control)
    {
        control = this;
        return true;
    }
}
