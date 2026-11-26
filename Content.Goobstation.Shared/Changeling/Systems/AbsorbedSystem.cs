// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Common.Changeling;
using Content.Shared.Examine;
using Content.Shared.IdentityManagement;
using Content.Shared.Mobs;

namespace Content.Goobstation.Shared.Changeling.Systems;

public sealed partial class AbsorbedSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AbsorbedComponent, ExaminedEvent>(OnExamine);
        SubscribeLocalEvent<AbsorbedComponent, MobStateChangedEvent>(OnMobStateChange);
        SubscribeLocalEvent<WasAbsorbedComponent, ExaminedEvent>(OnWasAbsorbedExamine);
    }

    private void OnExamine(Entity<AbsorbedComponent> ent, ref ExaminedEvent args)
    {
        args.PushMarkup(Loc.GetString("changeling-absorb-onexamine"));
    }

    private void OnMobStateChange(Entity<AbsorbedComponent> ent, ref MobStateChangedEvent args)
    {
        // in case one somehow manages to dehusk someone
        if (args.NewMobState != MobState.Dead)
            RemComp<AbsorbedComponent>(ent);
    }

    private void OnWasAbsorbedExamine(Entity<WasAbsorbedComponent> ent, ref ExaminedEvent args)
    {
        if (HasComp<AbsorbedComponent>(ent))
            return;

        // shows someone was rezzed after being husked
        args.PushMarkup(Loc.GetString("changeling-absorb-revived-onexamine", ("target", Identity.Entity(ent, EntityManager))));
    }
}