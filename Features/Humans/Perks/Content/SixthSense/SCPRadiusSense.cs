﻿using LabApi.Features.Wrappers;
using MapGeneration;
using SwiftUHC.Utils.Extensions;
using System.Linq;

namespace SwiftUHC.Features.Humans.Perks.Content.SixthSense
{
    public class SCPRadiusSense(SixthSense parent) : SenseBase(parent)
    {
        public static readonly string[] NoSCPMessages = [
            "You feel a sense of normalcy.",
            "The static in your thoughts begins to clear.",
            "You blink, and for the first time in a while, the world feels grounded.",
            "Your pulse steadies, though you're not sure when it had quickened.",
            "The air no longer hums. You wonder if it ever did.",
            "The world seems to have snapped back into place, like waking from a half-remembered dream.",
            "The walls look... right, somehow. As if they belong here.",
            "A faint pressure lifts from your skull. The silence isn't just quiet—it's real.",
            "The buzz behind your eyes fades into a manageable silence.",
            "Reality feels rigid here—as if someone finally tightened the bolts.",
            "You can't remember the last time your footsteps made sense.",
            "The taste of iron leaves your mouth. You didn't realize it was there.",
            "The flickering in the corners of your vision finally stops.",
            "You feel alone—and this time, it's comforting.",
            "Your thoughts line up neatly, like they used to.",
            "The world feels... sterile, in a good way.",
            "No eyes in the walls. No whispers in the vents. Just you."
            ];

        public static readonly string[] SCPNearbyMessages = [
            "Something skitters across your mind—too quick to name, too loud to forget.",
            "The walls shift when you're not looking. Or was it only an illusion?",
            "Your shadow twitches a half-beat behind you.",
            "You feel heavier, like the air itself is watching.",
            "The lights dim, but the bulbs don't flicker.",
            "A taste like static clings to the back of your tongue.",
            "Your thoughts begin to echo, as if someone else is rehearsing them.",
            "You try to blink something out of your vision—but your eyes were already closed.",
            "The floor feels softer. Or deeper.",
            "Breathing becomes deliberate. Forgetting to inhale feels... dangerous.",
            "The walls breathe with a rhythm not your own.",
            "Your name doesn't sound right when you think it.",
            "Something in your periphery refuses to resolve.",
            "You swore that you saw something jump across your vision.",
            "Every light source is just slightly wrong in color temperature.",
            "Your footsteps echo with a delay too long to be real.",
            "Your teeth itches.",
            "The ventilation hum becomes a melody—one you shouldn't recognize.",
            "You feel you're being studied by something that doesn't blink."
            ];

        public static readonly string[] PocketDimensionMessages = [
            "The floor bends like wet paper under your weight.",
            "Something skitters beneath your skin. It's wearing your voice.",
            "There are pathways here, one of them might be an exit...",
            "Time loops—but it never repeats the same way twice.",
            "You try to scream, but your mouth is filled with rust.",
            "Walls drip with memories that aren't yours.",
            "The air crackles like old bone. Breathing feels optional—and wrong.",
            "A clock ticks in reverse. It's inside your chest.",
            "Every surface wants to swallow you. Some already have."
            ];

        public static readonly string[] SCPMessages = [
            "You are the danger.",
            "You crave for the sight of a human.",
            "You don't feel anything but hunger.",
            "An unknown voice commands you to slaughter.",
            "The killing is not pointless, it is necessary.",
            "Slaughter seems to be the only way to prove your existance.",
            "You don't feel your own breathing.",
            "Survival is only wishful thinking.",
            "Bloodlust fills your veins.",
            "The humans' futile struggle is what excites you."
            ];

        public virtual float Range => 30f;

        int lastRand1;
        int lastRand2;
        int lastRand3;
        int lastRand4;

        public override string Message()
        {
            if (Player.IsSCP)
                return SCPMessages.GetRandom(ref lastRand1);

            if (Player.Room.Name == RoomName.Pocket)
                return PocketDimensionMessages.GetRandom(ref lastRand2);

            Player scp = GetNearSCPs();
            return scp == null ? NoSCPMessages.GetRandom(ref lastRand3) : SCPNearbyMessages.GetRandom(ref lastRand4);
        }

        public Player GetNearSCPs()
        {
            foreach (Player p in Player.List.Where(p => p.IsSCP && (p.Position - Player.Position).sqrMagnitude <= Range * Range))
                return p;
            return null;
        }
    }
}
