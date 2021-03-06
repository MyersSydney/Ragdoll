using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptedObject/Recipe", order = 2)]
public class Recipe : ScriptableObject
{
    public Item[] items;
    public Item createdItem;
}
