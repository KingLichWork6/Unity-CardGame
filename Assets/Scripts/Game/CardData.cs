using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CardData
{
    public string Name;
    public string AbilityName;

    public bool IsBaseCard = true;

    [TextArea] public string DescriptionEng;
    [TextArea] public string DescriptionRu;

    public int MaxPoints;
    public int Points;
    public Color ColorTheme;
    public int ArmorPoints;

    public Sprite Sprite;
    public AudioClip CardPlaySound;
    public AudioClip CardTimerSound;

    // --- Boost/Damage ---
    public int Boost;
    public int NearBoost;
    public int ChangeNearBoost;
    public int SelfBoost;

    public int Damage;
    public int NearDamage;
    public int ChangeNearDamage;
    public int SelfDamage;

    public bool AddictionWithSelfField;
    public bool AddictionWithEnemyField;

    // --- End Turn Actions ---
    public int EndTurnCount;
    public int EndTurnRandomDamage;
    public int EndTurnRandomBoost;

    public int EndTurnSelfBoost;
    public int EndTurnSelfDamage;
    public int EndTurnNearBoost;
    public int EndTurnNearDamage;

    public int Timer;
    public bool TimerNoMoreActions;
    public int ArmorOther;

    // --- Spawns ---
    public string SpawnCardName;
    public int SpawnCardCount;

    // --- Draw ---
    public int DrawCardCount;

    // --- Status Effects ---
    public bool IsShieldOther;
    public bool IsStunOther;
    public bool IsInvisibility;
    public bool IsInvulnerability;
    public bool IsSelfShielded;

    public int SelfEnduranceOrBleeding;
    public int EnduranceOrBleedingOther;
    public bool IsEnemyTargetEnduranceOrBleeding;

    // --- Unique ---
    public int DestroyCardPoints;
    public bool SwapPoints;
    public string TransformationName;
    public int ReturnDamageValue;
    public int HealDamageValue;
}
