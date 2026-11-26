// SPDX-License-Identifier: AGPL-3.0-or-later
using Content.Goobstation.Common.Changeling;
using Content.Shared.EntityEffects;
using Content.Shared.Traits.Assorted;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

public sealed partial class UnhuskAbsorbedSystem : EntityEffectSystem<AbsorbedComponent, UnhuskAbsorbed>
{
    // check for AbsorbedComponent before removing Unrevivable which still leaves room for error but it's good enough
    protected override void Effect(Entity<AbsorbedComponent> entity, ref EntityEffectEvent<UnhuskAbsorbed> args)
    {
        RemComp<AbsorbedComponent>(entity);
        RemComp<UnrevivableComponent>(entity);
    }
}

public sealed partial class UnhuskAbsorbed : EntityEffectBase<UnhuskAbsorbed>
{
    public override string EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("entity-effect-guidebook-unhusk-absorbed", ("chance", Probability));
}