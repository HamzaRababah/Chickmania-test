using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private string heroName;
    private int power, baseHealth, magic;

    public void SetName(string name)
    {
        heroName = name;
    }

    public void SetPower(int power)
    {
        this.power = power;
    }

    public void SetBaseHealth(int value)
    {
        baseHealth = value;
    }

    public void SetMagic(int magic)
    {
        this.magic = magic;
    }


    public void GenerateRandomStats()
    { 
    
    }

}
