using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler
{
    private Card[] hand;
    private int gamblerScore;

    public Gambler()
    {
        gamblerScore = 0;
        hand = new Card[5];
    }

    public int GetGamblerScore()
    {
        return gamblerScore;
    }

    public void SetGamblerScore(int num)
    {
        gamblerScore = num;
    }

    public Card[] GetHand()
    {
        return hand;
    }

    public Card GetExactHand(int n)
    {
        return hand[n];
    }

    public void SetHand(Card[] c)
    {
        hand = c;
    }

    public void SetExactHand(int n, Card c)
    {
        hand[n] = c;
    }
}
