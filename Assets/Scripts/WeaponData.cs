using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName ="New Weapon Data", menuName = "Create Weapon Data")]
public class WeaponData : EquipItemData
{
    [Header("Weapon")]
    public Vector3 attackOffset;
    public float attackRange;
    public float attackDelay;

    public Vector3 GetAttackRange(Character character)
    {
        var transform = character.transform;
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        return pos;
    }
}
