﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckBuildManager : MonoBehaviour
{
    private static DeckBuildManager _instance;

    public static DeckBuildManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DeckBuildManager>();
            }

            return _instance;
        }
    }

    [SerializeField] private GameObject _cardPref;
    [SerializeField] private GameObject _cardInDeckPref;

    [SerializeField] private GameObject _deckGameObject;
    [SerializeField] private GameObject _cardContentView;

    [SerializeField] private TextMeshProUGUI _countCard;
    [SerializeField] private TextMeshProUGUI _needCountCard;

    [SerializeField] private AudioSource _audioSourceVoice;
    [SerializeField] private AudioSource _audioSourceEffects;

    [SerializeField] private GameObject[] _howToPlayList;

    private List<Card> _deck = new List<Card>();
    private List<GameObject> _allCards = new List<GameObject>();

    private List<CardInfoScript> _cardInfoDeckList = new List<CardInfoScript>();
    private List<CardInfoScript> _randomDeckList = new List<CardInfoScript>();

    private int _needCountCardInDeck = 20;
    private int _countCardInDeck = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _needCountCard.text = "/ " + _needCountCardInDeck.ToString();

        ChangeCountCard();

        foreach (Card card in CardManagerList.AllCards)
        {
            GameObject newCard = Instantiate(_cardPref, Vector3.zero, Quaternion.identity, _cardContentView.transform);
            newCard.transform.position = new Vector3(0, 0, 100);
            newCard.AddComponent<ClickCardOnDeckBuild>().IsMainCard = true;
            CardInfoScript cardInfo = newCard.GetComponent<CardInfoScript>();
            cardInfo.ShowCardInfo(card);
            cardInfo.IsDeckBuildCard = true;
            newCard.GetComponent<CardMove>().enabled = false;

            _allCards.Add(newCard);
            _cardInfoDeckList.Add(cardInfo);
        }

        float height = (Mathf.Ceil((float)_cardContentView.transform.childCount / 6) * 150 + (Mathf.Ceil((float)_cardContentView.transform.childCount / 6) - 1) * 100) - 1065 + 250;
        _cardContentView.GetComponent<RectTransform>().sizeDelta = new Vector2(_cardContentView.GetComponent<RectTransform>().sizeDelta.x, height);
        _cardContentView.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -height / 2);

        if (Object.FindObjectOfType<HowToPlay>() != null)
            HowToPlay.Instance.HowToPlayDeckBuild(_howToPlayList);
    }

    public void AddCard(CardInfoScript card)
    {
        _countCardInDeck++;

        ChangeCountCard();

        GameObject newCardInDeck = Instantiate(_cardInDeckPref, Vector3.zero, Quaternion.identity, _deckGameObject.transform);
        newCardInDeck.transform.position = new Vector3(0, 0, 100);

        ClickCardOnDeckBuild click = newCardInDeck.AddComponent<ClickCardOnDeckBuild>();
        click.IsInDeck = true;
        click.CardInfoScript = card;

        CardInDeck cardInDeck = newCardInDeck.GetComponent<CardInDeck>();
        cardInDeck.Image.sprite = card.SelfCard.BaseCard.Sprite;
        cardInDeck.Name.text = card.Name.text + ": " + card.SecondName.text;
        cardInDeck.Points.text = card.Point.text;

        _deck.Add(card.SelfCard);

        float height = (_deckGameObject.transform.childCount * _cardInDeckPref.GetComponent<RectTransform>().sizeDelta.y + _deckGameObject.transform.childCount * 5) - 1065 + 100;

        if (height > 0)
            _deckGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_deckGameObject.GetComponent<RectTransform>().sizeDelta.x, height);

        CardSound(card);
    }

    public void RemoveCard(CardInfoScript card, GameObject cardInDeck)
    {
        _countCardInDeck--;
        ChangeCountCard();

        _deck.Remove(card.SelfCard);
        card.GetComponent<ClickCardOnDeckBuild>().IsInDeck = false;

        Destroy(cardInDeck);

        float height = _deckGameObject.transform.childCount * _cardInDeckPref.GetComponent<RectTransform>().sizeDelta.y + _deckGameObject.transform.childCount * 5 - 1065 + 100;

        if (height > 0)
            _deckGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_deckGameObject.GetComponent<RectTransform>().sizeDelta.x, height);
    }

    public void StartGame()
    {
        if (_countCardInDeck == _needCountCardInDeck)
        {
            DeckManager.Instance.SetDeck(_deck);
            SceneManager.LoadScene("Game");
        }
    }

    public void RandomDeck()
    {
        _randomDeckList = new List<CardInfoScript>(_cardInfoDeckList);
        int currentCardInDeck = _countCardInDeck;

        List<CardInfoScript> removeCards = new List<CardInfoScript>();

        foreach (CardInfoScript card in _randomDeckList)
        {
            if (_deck.Contains(card.SelfCard))
            {
                removeCards.Add(card);
            }
        }

        foreach (CardInfoScript card in removeCards)
        {
            _randomDeckList.Remove(card);
        }

        for (int i = 0; i < _needCountCardInDeck - currentCardInDeck; i++)
        {
            int random = Random.Range(0, _randomDeckList.Count);
            CardInfoScript newCard = _randomDeckList[random];

            AddCard(newCard);
            _randomDeckList.Remove(newCard);
        }

        foreach (CardInfoScript card in _cardInfoDeckList)
        {
            if (_deck.Contains(card.SelfCard))
            {
                card.GetComponent<ClickCardOnDeckBuild>().CardInDeck(card);
            }
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClearDeck()
    {
        _countCardInDeck = 0;
        ChangeCountCard();

        for (int i = _deckGameObject.transform.childCount - 1; i >= 0; i--)
        {
            _deckGameObject.transform.GetChild(i).GetComponent<ClickCardOnDeckBuild>().CardRemoveFromDeck(_deckGameObject.transform.GetChild(i).GetComponent<ClickCardOnDeckBuild>().CardInfoScript);
            Destroy(_deckGameObject.transform.GetChild(i).gameObject);
        }

        _deck.Clear();

        _deckGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_deckGameObject.GetComponent<RectTransform>().sizeDelta.x, 1075);
    }

    private void ChangeCountCard()
    {
        _countCard.text = _countCardInDeck.ToString();

        if (_countCardInDeck != _needCountCardInDeck)
        {
            _countCard.color = Color.red;
        }

        else
            _countCard.color = Color.green;
    }

    private void CardSound(CardInfoScript card)
    {
        _audioSourceVoice.clip = Resources.Load<AudioClip>("Sounds/Cards/Deployment/" + card.SelfCard.BaseCard.Name + Random.Range(0, 6));
        _audioSourceVoice.Play();

        _audioSourceEffects.clip = card.SelfCard.BaseCard.CardPlaySound;
        _audioSourceEffects.Play();
    }
}
