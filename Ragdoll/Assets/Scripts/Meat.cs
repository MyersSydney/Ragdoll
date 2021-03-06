using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Meat", menuName = "ScriptedObject/Meat", order = 3)]
public class Meat : Item
{
    public enum howDone {rare, mediumRare, Done, WellDone}
    public howDone meDone;
}
