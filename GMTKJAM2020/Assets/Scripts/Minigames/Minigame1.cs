using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Minigame1 : MonoBehaviour
{
    [SerializeField] private List<Minigame1_Card> cardList = new List<Minigame1_Card>();
    [SerializeField] private Transform cardHolder;
    [SerializeField] private Transform worldCardPosition;
    [SerializeField] private MinigameTinderWorldCard worldCardBase;
    
    private List<Minigame1_Card> cards = new List<Minigame1_Card>();

    private Minigame1_Card currentCard => cards[cards.Count - 1];

    private void OnEnable()
    {
        LeverButton.onLeverButtonPress += Refuse;
        GreenButton.onGreenButtonPress += Accept;
        BlueButton.onBlueButtonPress += SuperLike;
        
        GenerateList();
    }

    private void OnDisable()
    {
        LeverButton.onLeverButtonPress -= Refuse;
        GreenButton.onGreenButtonPress -= Accept;
        BlueButton.onBlueButtonPress -= SuperLike;
    }

    private void GenerateList()
    {
        cardList = cardList.OrderBy(x => Random.value).ToList();
        
        foreach (var card in cardList)
        {
            var obj = Instantiate(card, cardHolder);
            cards.Add(obj);
        }
    }

    private void SuperLike()
    {
        if (cards.Count <= 0) return;
        var obj = Instantiate(worldCardBase, worldCardPosition.position, Quaternion.identity);
        obj.SetTexture(currentCard.GetCardData.img.texture);
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