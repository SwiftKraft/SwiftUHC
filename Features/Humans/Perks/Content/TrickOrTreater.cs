﻿namespace SwiftUHC.Features.Humans.Perks.Content
{
    [Perk("TrickOrTreater", Rarity.Legendary)]
    public class TrickOrTreater(PerkInventory inv) : PerkItemReceiveBase(inv)
    {
        public override string Name => "Trick Or Treater";

        public override string Description => "Receive a candy. " + base.Description;

        public override float Cooldown => 25f;

        public override ItemType ItemType => ItemType.SCP330;
    }
}
