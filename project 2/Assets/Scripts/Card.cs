using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private int score;
    private bool flipped;
    private string name;

    public Card(int num, string str)
    {
        score = num;
        flipped = false;
        name = str;
    }

    public int GetScore()
    {
        return score;
    }

    public void Flip()
    {
        flipped = !flipped;
    }

    public bool GetFlip()
    {
        return flipped;
    }

    public string GetName()
    {
        return name;
    }
}
