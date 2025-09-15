using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public struct EffectDescription
{
    public Sprite EffectImage;

    public string NameEng;
    public string NameRu;
    public string NameUk;

    public string DescriptionEng;
    public string DescriptionRu;
    public string DescriptionUk;


    public EffectDescription(string effectImagePath, string nameEng, string nameRu, string nameUk, string descriptionEng, string descriptionRu, string descriptionUk) 
    {
        EffectImage = Resources.Load<SpriteAtlas>("Sprites/Effects/EffectSpiteAtlas").GetSprite(effectImagePath);
        NameEng = nameEng;
        NameRu = nameRu;
        NameUk = nameUk;

        DescriptionEng = descriptionEng;
        DescriptionRu = descriptionRu;
        DescriptionUk = descriptionUk;
    }
}

public static class CardEffectsDescriptionList
{ 
    public static List<EffectDescription> effectDescriptionList = new List<EffectDescription>();
}

public class EffectsDescripton : MonoBehaviour
{
    private void Awake()
    {
        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Destroy", 
            "Destroy", 
            "����������", 
            "������", 
            "�hange card points to 0.", 
            "�������� ���� ����� �� 0.", 
            "����� ���� ������ �� 0."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Damage",
            "Damage",
            "����",
            "�����",
            "�hange card points to - value.",
            "�������� ���� ����� �� - ��������.",
            "����� ���� ������ �� - ��������."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Boost",
            "Boost",
            "��������",
            "ϳ��������",
            "�hange card points to + value.",
            "�������� ���� ����� �� + ��������.",
            "����� ���� ������ �� + ��������."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Spawn",
            "Spawn",
            "��������",
            "���������",
            "�reate a unit.",
            "�������� �����.",
            "������� ���i�."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Draw",
            "Draw card",
            "����� �����",
            "����� ������",
            "Add first card from deck to your hand.",
            "�������� ������ ����� �� ������ � ���� ����.",
            "������� ����� ����� � ������ �� ���� ����."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Near",
            "Near",
            "�����",
            "�����",
            "Cards to the left and right of the selected one.",
            "����� ����� � ������ �� ���������.",
            "����� ���� � ������ �� �������."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Armor",
            "Armor",
            "�����",
            "�����",
            "Block Damage",
            "��������� ����.",
            "����� �����."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Stun",
            "Stun",
            "���������",
            "���������",
            "The target's end of turn abilities are disabled for 1 turn.",
            "����������� ���� � ����� ���� ��������� �� 1 ���.",
            "������� ��� � ���� ���� ������� �� 1 ���."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Shield",
            "Shield",
            "���",
            "���",
            "Blocks 1 tick of damage.",
            "��������� 1 ��������� �����.",
            "����� 1 ��������� �����."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Illusion",
            "Illusion",
            "�������",
            "�����",
            "Receives 2 times more damage.",
            "�������� � 2 ���� ������ �����.",
            "������ � 2 ���� ����� �����."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Invisibility",
            "Invisibility",
            "�����������",
            "����������",
            "The card must be played onto the enemy field.",
            "����� ������ ���� ������� �� ���� �����.",
            "������ ������� ������ �� ��� ������."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Invulnerability",
            "Invulnerability",
            "������������",
            "������������",
            "Card cannot be targeted.",
            "����� �� ����� ���� ������� �����.",
            "������ �� ���� ���� ������ �����."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Bleeding",
            "Bleeding",
            "������������",
            "���������",
            "At the end of your turn damage card by 1 and change duration -1.",
            "� ����� ������ ���� �������� ����� 1 ���� � ��������� ����������������� �� 1.",
            "� ���� ������ ���� �������� ������ 1 ����� � �������� ��������� �� 1."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Endurance",
            "Endurance",
            "������������",
            "�����������",
            "At the end of your turn boost card by 1 and change duration -1.",
            "� ����� ������ ���� ��������� ���� ����� �� 1 � ��������� ����������������� �� 1.",
            "� ���� ������ ���� �������� ���� ������ �� 1 � �������� ��������� �� 1."
        ));

        CardEffectsDescriptionList.effectDescriptionList.Add(new EffectDescription(
            "Timer",
            "Timer",
            "������",
            "������",
            "At the end of your turn change value timer by -1, if it becomes 0, apply the effect.",
            "� ����� ������ ���� ��������� �������� ������� �� 1, ���� ��� ������ 0, ��������� ������.",
            "� ���� ������ ���� �������� �������� ������� �� 1, ���� ���� ����� 0, ���������� �����."
        ));
    }
}


