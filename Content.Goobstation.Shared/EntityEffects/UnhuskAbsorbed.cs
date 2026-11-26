// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Common.Changeling;
using Content.Shared.Body.Systems;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.Database;
using Content.Shared.EntityEffects;
using Content.Shared.Popups;
using Content.Shared.Traits.Assorted;
using Robust.Shared.Prototypes;

namespace Content.Goobstation.Shared.EntityEffects;

/// <summary>
/// Unhusks a hollowed body to allow revival
/// </summary>
public sealed partial class UnhuskAbsorbedSystem : EntityEffectSystem<AbsorbedComponent, UnhuskAbsorbed>
{
    [Dependency] private SharedBloodstreamSystem _blood = default!;
    [Dependency] private SharedPopupSystem _popup = default!;

    // // check for AbsorbedComponent before removing Unrevivable which still leaves room for error but it's good enough
    protected override void Effect(Entity<AbsorbedComponent> entity, ref EntityEffectEvent<UnhuskAbsorbed> args)
    {
        RemComp<AbsorbedComponent>(entity);
        RemComp<UnrevivableComponent>(entity); // added alongside Absorbed by changeling absorption

        // turns out being linged also swaps blood type so we have to change it back
        _blood.ChangeBloodReagents(entity.Owner, new Solution([new ReagentQuantity(args.Effect.BloodReagent, 1)]));

        _popup.PopupEntity(Loc.GetString("solidizium-effect-cured"), entity, PopupType.Medium);
    }
}

public sealed partial class UnhuskAbsorbed : EntityEffectBase<UnhuskAbsorbed>
{
    [DataField]
    public ProtoId<ReagentPrototype> BloodReagent = "Blood"; // pegs it to normal blood
    // you could probably do something more sophisticated by looking up victim species and setting the appropriate bloodtype but it's beyond me

    public override LogImpact? Impact => LogImpact.Low;

    public override string EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("entity-effect-guidebook-unhusk-absorbed", ("chance", Probability));
}