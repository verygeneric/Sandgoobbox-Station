// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameObjects;

namespace Content.Goobstation.Common.Changeling;

/// <summary>
/// Flags a previously-hollowed body. Unlike <see cref="AbsorbedComponent"/> this stays after the body is revived.
/// </summary>
[RegisterComponent]
public sealed partial class WasAbsorbedComponent : Component
{
    /// <summary>
    /// Tracks the mind of the absorbing changeling to make sure it persists.
    /// </summary>
    [DataField]
    public EntityUid? AbsorberMind;
}