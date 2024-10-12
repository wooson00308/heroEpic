using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IStats
{
    private StatData _data;
    public float MoveSpeed { get; set; }
    public float AttackSpeed { get; set; }

    public StatData Data;

    private void Awake()
    {
        Initialize(Data);
    }

    public void Initialize(StatData data) 
    {
        _data = data;

        _data.SetUp(this);
    }
}
