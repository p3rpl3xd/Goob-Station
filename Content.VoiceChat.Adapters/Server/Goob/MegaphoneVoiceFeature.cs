// SPDX-FileCopyrightText: 2026 Aidenkrz <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2026 Aiden <aiden@djkraz.com>
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Loudspeaker.Components;
using Content.VoiceChat.Server;

namespace Content.VoiceChat.Server;

/// <summary>
/// Goob loudspeakers. Do not compile this into a fork that does not have those components.
/// </summary>
public sealed partial class MegaphoneVoiceFeature : EntitySystem, IVoiceFeature
{
    [Dependency] private VoiceFeatures _features = default!;

    public override void Initialize()
    {
        base.Initialize();
        _features.Add(this);
    }

    public void AdjustRange(EntityUid speaker, ref float range, ref bool megaphone)
    {
        if (!IsActive(speaker))
            return;

        megaphone = true;
        if (range < 15f)
            range = 15f;
    }

    private bool IsActive(EntityUid uid)
    {
        if (!TryComp<LoudspeakerHolderComponent>(uid, out var holder))
            return false;

        foreach (var item in holder.Loudspeakers)
        {
            if (TryComp<LoudspeakerComponent>(item, out var loudspeaker) && loudspeaker.IsActive && loudspeaker.AffectChat)
                return true;
        }

        return false;
    }
}
