using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class CardManagerList
{
    public static List<Card> AllCards = new List<Card>();

    public static Card FindCard(string name)
    {
        Card findedCard = new Card();

        foreach (var card in AllCards)
        {
            if(card.BaseCard.Name == name)
                findedCard = card;
        }

        return findedCard;
    }
}

public class CardManager : MonoBehaviour
{
    private void Awake()
    {
        CardDatabase database = Resources.Load<CardDatabase>("Data/CardDatabase");

        List<Card> cards = new List<Card>();
        foreach (var data in database.AllCards)
        {
            cards.Add(ToCard(data));
        }

        CardManagerList.AllCards = cards;
    }

    public Card ToCard(CardData data)
    {
        Card card = new Card();

        card.BaseCard = new BaseCard
        {
            Name = data.Name,
            AbilityName = data.AbilityName,

            IsBaseCard = data.IsBaseCard,

            DescriptionEng = data.DescriptionEng,
            DescriptionRu = data.DescriptionRu,

            MaxPoints = data.MaxPoints,
            Points = data.Points,
            ImageTexture = data.Sprite != null ? data.Sprite.texture : null,
            Sprite = data.Sprite,

            CardPlaySound = data.CardPlaySound,
            CardTimerSound = data.CardTimerSound,
            ColorTheme = data.ColorTheme,
            ArmorPoints = data.ArmorPoints
        };

        card.BoostOrDamage = new BoostOrDamage
        {
            Boost = data.Boost,
            NearBoost = data.NearBoost,
            ChangeNearBoost = data.ChangeNearBoost,
            SelfBoost = data.SelfBoost,

            Damage = data.Damage,
            NearDamage = data.NearDamage,
            ChangeNearDamage = data.ChangeNearDamage,
            SelfDamage = data.SelfDamage,

            AddictionWithAlliedField = data.AddictionWithSelfField,
            AddictionWithEnemyField = data.AddictionWithEnemyField
        };

        card.EndTurnActions = new EndTurnActions
        {
            EndTurnActionCount = data.EndTurnCount,
            EndTurnRandomDamage = data.EndTurnRandomDamage,
            EndTurnRandomBoost = data.EndTurnRandomBoost,
            EndTurnSelfBoost = data.EndTurnSelfBoost,
            EndTurnSelfDamage = data.EndTurnSelfDamage,
            EndTurnNearBoost = data.EndTurnNearBoost,
            EndTurnNearDamage = data.EndTurnNearDamage,
            Timer = data.Timer,
            TimerNoMoreActions = data.TimerNoMoreActions,
            ArmorOther = data.ArmorOther
        };

        card.Spawns = new Spawns
        {
            SpawnCardName = data.SpawnCardName,
            SpawnCardCount = data.SpawnCardCount
        };

        card.DrawCard = new DrawCard
        {
            DrawCardCount = data.DrawCardCount
        };

        card.StatusEffects = new StatusEffects
        {
            IsShieldOther = data.IsShieldOther,
            IsStunOther = data.IsStunOther,
            IsInvisibility = data.IsInvisibility,
            IsInvulnerability = data.IsInvulnerability,
            IsSelfShielded = data.IsSelfShielded,
            SelfEnduranceOrBleeding = data.SelfEnduranceOrBleeding,
            EnduranceOrBleedingOther = data.EnduranceOrBleedingOther,
            IsEnemyTargetEnduranceOrBleeding = data.IsEnemyTargetEnduranceOrBleeding
        };

        card.UniqueMechanics = new UniqueMechanics
        {
            DestroyCardPoints = data.DestroyCardPoints,
            SwapPoints = data.SwapPoints,
            TransformationCardName = data.TransformationName,
            ReturnDamageValue = data.ReturnDamageValue,
            HealDamageValue = data.HealDamageValue
        };

        return card;
    }
}
