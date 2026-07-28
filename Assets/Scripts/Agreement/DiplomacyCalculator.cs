using UnityEngine;

public static class DiplomacyCalculator
{


public static AgreementRarity GetRandomRarity(int intelligence)
    {
        int roll = Random.Range(1, 101);

        if (intelligence < 25)
        {
            if (roll <= 60) return AgreementRarity.Common;
            if (roll <= 85) return AgreementRarity.Uncommon;
            if (roll <= 95) return AgreementRarity.Rare;
            if (roll <= 99) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (intelligence < 50)
        {
            if (roll <= 45) return AgreementRarity.Common;
            if (roll <= 75) return AgreementRarity.Uncommon;
            if (roll <= 91) return AgreementRarity.Rare;
            if (roll <= 98) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (intelligence < 75)
        {
            if (roll <= 30) return AgreementRarity.Common;
            if (roll <= 60) return AgreementRarity.Uncommon;
            if (roll <= 83) return AgreementRarity.Rare;
            if (roll <= 96) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (intelligence < 100)
        {
            if (roll <= 18) return AgreementRarity.Common;
            if (roll <= 43) return AgreementRarity.Uncommon;
            if (roll <= 71) return AgreementRarity.Rare;
            if (roll <= 92) return AgreementRarity.Epic;

            return AgreementRarity.Legendary;
        }

        if (roll <= 10) return AgreementRarity.Common;
        if (roll <= 28) return AgreementRarity.Uncommon;
        if (roll <= 55) return AgreementRarity.Rare;
        if (roll <= 85) return AgreementRarity.Epic;

        return AgreementRarity.Legendary;
    }

public static int GetSuccessChance(
        Player player,
        Player enemy,
        AgreementData agreement)
    {
        int chance = agreement.baseSuccessChance;

        int difference =
            player.Diplomat.Persuasion -
            enemy.Diplomat.Resistance;

        chance += difference / 2;

        chance = Mathf.Clamp(chance, 10, 95);

        return chance;
    }

public static int GetDecisionTime(
    Player player,
    AgreementData agreement)
    {
    int time = agreement.baseDecisionTime;

    time -= player.Diplomat.Negotiation / 4;

    time = Mathf.Clamp(time, 60, agreement.baseDecisionTime);

    return time;
    }
}