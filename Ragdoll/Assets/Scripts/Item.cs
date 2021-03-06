using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptedObject/Item", order = 1)]
public class Item : ScriptableObject
{
    public enum Quality {poor, good, great, amazing, awesome, theBomb}
    public string myName;
    public string description;
    public int points;
    public Quality quality;
    public int price;
}
