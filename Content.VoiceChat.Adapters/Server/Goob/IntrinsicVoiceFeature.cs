// SPDX-FileCopyrightText: 2026 Aidenkrz <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2026 Aiden <aiden@djkraz.com>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.IntrinsicVoiceModulator.Components;
using Content.VoiceChat.Server;

namespace Content.VoiceChat.Server;

/// <summary>
/// Goob intrinsic voice modulator. Stock forks get the same behavior from <see cref="VoiceMaskFeature"/>.
/// </summary>
public sealed partial class IntrinsicVoiceFeature : EntitySystem, IVoiceFeature
{
    [Dependency] private VoiceFeatures _features = default!;

    public override void Initialize()
    {
        base.Initialize();
        _features.Add(this);
    }

    public bool HasVoiceChanger(EntityUid uid)
    {
        return HasComp<IntrinsicVoiceModulatorComponent>(uid);
    }

    public void DescribeState(EntityUid speaker, VoiceStateHints hints)
    {
        if (HasVoiceChanger(speaker))
            hints.VoiceChanger = true;
    }
}
