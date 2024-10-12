using System.Collections;
using UnityEngine;

public abstract class Controller : ScriptableObject
{
    public abstract void OnUpdate(Character character);
} 
