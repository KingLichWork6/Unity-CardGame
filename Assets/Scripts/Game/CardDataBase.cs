using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "Data/Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<CardData> AllCards = new List<CardData>();
}