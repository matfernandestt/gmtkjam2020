using System;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1 : MonoBehaviour
{
    [SerializeField] private List<Minigame1_Card> cardList = new List<Minigame1_Card>();
    [SerializeField] private Transform cardHolder;
    
    private List<Minigame1_Card> cards = new List<Minigame1_Card>();

    private Minigame1_Card currentCard => cards[cards.Count - 1];

    private void OnEnable()
    {
        RedButton.onRedButtonPress += Refuse;
        GreenButton.onGreenButtonPress += Accept;
        BlueButton.onBlueButtonPress += SuperLike;
        
        GenerateList();
    }

    private void OnDisable()
    {
        RedButton.onRedButtonPress -= Refuse;
        GreenButton.onGreenButtonPress -= Accept;
        BlueButton.onBlueButtonPress -= SuperLike;
    }

    private void GenerateList()
    {
        foreach (var card in cardList)
        {
            var obj = Instantiate(card, cardHolder);
            cards.Add(obj);
        }
    }

    private void SuperLike()
    {
        if (cards.Count <= 0) return;
        currentCard.OnClickSuperlike();
        cards.Remove(currentCard);
    }

    private void Refuse()
    {
        if (cards.Count <= 0) return;
        currentCard.OnClickRefuse();
        cards.Remove(currentCard);
    }

    private void Accept()
    {
        if (cards.Count <= 0) return;
        currentCard.OnClickAccept();
        cards.Remove(currentCard);
    }
}