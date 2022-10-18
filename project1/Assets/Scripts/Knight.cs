using System;

public class Knight
{
    private int health;
    private int power;
    private int speed;
    private string name;

    public Knight(string na)
    {
        name = na;
        health = 20;
    }

    public void SetHealth(int newHP)
    {
        health = newHP;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetPower(int newPower)
    {
        power = newPower;
    }

    public int GetPower()
    {
        return power;
    }

    public void SetSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public string GetName()
    {
        return name;
    }

    public void UpdatePower()
    {
        power = 1 + health / 5;
    }

    public void UpdateSpeed()
    {
        speed = 1 + health / 4;
    }


}
