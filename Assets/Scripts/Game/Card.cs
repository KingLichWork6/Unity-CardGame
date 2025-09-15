using UnityEngine;

public struct Card
{
    public BaseCard BaseCard;
    public BoostOrDamage BoostOrDamage;
    public EndTurnActions EndTurnActions;
    public Spawns Spawns;
    public DrawCard DrawCard;
    public UniqueMechanics UniqueMechanics;
    public StatusEffects StatusEffects;

    public Card(string name, string secondName, string descriptionEng, string descriptionRu, string descriptionUk, string spritePath, string startOrderSoundPath, Color color, int maxPoints, int points, string timerSoundPath = null, int armor = 0,

        int boost = 0, int rangeBoost = 0, int changeBoost = 0, int damage = 0, int nearDamage = 0, int changeDamage = 0,
        int selfBoost = 0, int selfDamage = 0, bool addictionWithSelfField = false, bool addictionWithEnemyField = false,

        int endTurnCount = 0, int endTurnRandomBoost = 0, int endTurnRandomDamage = 0,
        int endTurnSelfBoost = 0, int endTurnSelfDamage = 0, int endTurnNearBoost = 0, int endTurnNearDamage = 0, int timer = 0, bool timerEndTurnNoMoreAction = false, int armorOther = 0,

        int spawnCardCount = 0, int spawnCardNumber = 0,

        int drawCardCount = 0,

        bool shieldOther = false, bool stunOther = false, bool invisibility = false, bool invulnerability = false, bool isSelfShielded = false,
        int enduranceOrBleedingSelf = 0, int enduranceOrBleedingOther = 0, bool isEnemyTargetEnduranceOrBleeding = false,

        int destroyCardPoints = 0, bool swapPoints = false, int transformationNumber = -1, int returnDamageValue = 0, int healDamageValue = 0)

    {

        BaseCard = new BaseCard
        {
            Name = name,
            AbilityName = secondName,

            DescriptionEng = descriptionEng,
            DescriptionRu = descriptionRu,
            DescriptionUk = descriptionUk,

            MaxPoints = maxPoints,
            Points = points,

            ImageTexture = Resources.Load<Texture>(spritePath),
            Sprite = Resources.Load<Sprite>(spritePath),

            CardPlaySound = Resources.Load<AudioClip>(startOrderSoundPath),
            CardTimerSound = Resources.Load<AudioClip>(timerSoundPath),
            ColorTheme = color,
            ArmorPoints = armor
        };


        BoostOrDamage = new BoostOrDamage
        {
            Boost = boost,
            NearBoost = rangeBoost,
            ChangeNearBoost = changeBoost,
            SelfBoost = selfBoost,

            Damage = damage,
            NearDamage = nearDamage,
            ChangeNearDamage = changeDamage,
            SelfDamage = selfDamage,

            AddictionWithAlliedField = addictionWithSelfField,
            AddictionWithEnemyField = addictionWithEnemyField
        };


        EndTurnActions = new EndTurnActions
        {
            EndTurnActionCount = endTurnCount,
            EndTurnRandomDamage = endTurnRandomDamage,
            EndTurnRandomBoost = endTurnRandomBoost,

            EndTurnSelfBoost = endTurnSelfBoost,
            EndTurnSelfDamage = endTurnSelfDamage,
            EndTurnNearBoost = endTurnNearBoost,
            EndTurnNearDamage = endTurnNearDamage,
            Timer = timer,
            TimerNoMoreActions = timerEndTurnNoMoreAction,

            ArmorOther = armorOther
        };


        Spawns = new Spawns
        {
            SpawnCardNumber = spawnCardNumber,
            SpawnCardCount = spawnCardCount
        };


        DrawCard = new DrawCard
        {
            DrawCardCount = drawCardCount
        };


        StatusEffects = new StatusEffects
        {
            IsShieldOther = shieldOther,
            IsStunOther = stunOther,
            IsInvisibility = invisibility,
            IsInvulnerability = invulnerability,
            IsSelfShielded = isSelfShielded,

            SelfEnduranceOrBleeding = enduranceOrBleedingSelf,
            EnduranceOrBleedingOther = enduranceOrBleedingOther,
            IsEnemyTargetEnduranceOrBleeding = isEnemyTargetEnduranceOrBleeding
        };


        UniqueMechanics = new UniqueMechanics
        {
            DestroyCardPoints = destroyCardPoints,
            SwapPoints = swapPoints,
            TransformationNumber = transformationNumber,
            ReturnDamageValue = returnDamageValue,
            HealDamageValue = healDamageValue
        };
    }
}

public struct BaseCard
{
    public string Name;
    public string AbilityName;

    public string DescriptionEng;
    public string DescriptionRu;
    public string DescriptionUk;

    public int MaxPoints;
    public int Points;

    public Texture ImageTexture;
    public Sprite Sprite;

    public AudioClip CardPlaySound;
    public AudioClip CardTimerSound;
    public Color ColorTheme;

    public bool isDestroyed;
    public int ArmorPoints;
}

public struct BoostOrDamage
{
    public int Boost;
    public int NearBoost;
    public int ChangeNearBoost;
    public int SelfBoost;

    public int Damage;
    public int NearDamage;
    public int ChangeNearDamage;
    public int SelfDamage;

    public bool AddictionWithAlliedField;
    public bool AddictionWithEnemyField;
}

public struct EndTurnActions
{
    public int EndTurnActionCount;

    public int EndTurnRandomBoost;
    public int EndTurnRandomDamage;

    public int EndTurnSelfBoost;
    public int EndTurnSelfDamage;

    public int EndTurnNearBoost;
    public int EndTurnNearDamage;

    public int Timer;
    public bool TimerNoMoreActions;

    public int ArmorOther;
}

public struct Spawns
{
    public int SpawnCardNumber;
    public int SpawnCardCount;
}

public struct DrawCard
{
    public int DrawCardCount;
}

public struct StatusEffects
{
    public bool IsShieldOther;
    public bool IsIllusion;
    public bool IsInvisibility;
    public bool IsStunOther;
    public bool IsInvulnerability;

    public bool IsSelfShielded;
    public bool IsSelfStunned;

    public int EnduranceOrBleedingOther;
    public int SelfEnduranceOrBleeding;
    public bool IsEnemyTargetEnduranceOrBleeding;
}

public struct UniqueMechanics
{
    public int DestroyCardPoints;

    public bool SwapPoints;

    public int TransformationNumber;

    public int ReturnDamageValue;

    public int HealDamageValue;
}