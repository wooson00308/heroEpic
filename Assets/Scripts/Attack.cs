using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Attack : MonoBehaviour
{
    public void OnAttack(Character target, Character owner)
    {
        target.Hit(owner);
    }
}
