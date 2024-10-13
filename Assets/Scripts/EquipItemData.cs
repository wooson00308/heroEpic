using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemData : ItemData, IStatSetable
{
    [Header("Stats")]
    public float moveSpeed;
    public float attackSpeed;
   
    public void SetUp(IStats stats)
    {
        stats.MoveSpeed += moveSpeed;
        stats.AttackSpeed += attackSpeed;
    }
}
