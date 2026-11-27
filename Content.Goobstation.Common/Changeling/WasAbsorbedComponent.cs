// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Goobstation.Common.Changeling;

/// <summary>
/// Flags a body that has been hollowed at any point, even if unhusked.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class WasAbsorbedComponent : Component
{
    /// <summary>
    /// Tracks the mind of the absorbing changeling to make sure it persists.
    /// </summary>
    [DataField]
    public EntityUid? AbsorberMind;
}