using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideHandler : MonoBehaviour
{
    public Character owner;
    public Action<Character> CollideEnterEvent;
    public Action<Character> CollideExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CollideHandler hit))
        {
            if(hit.CompareTag("HitBox"))
            {
                var hitOwner = hit.owner;
                if (!hitOwner.GetInstanceID().Equals(owner.GetInstanceID()))
                {
                    CollideEnterEvent?.Invoke(hitOwner);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CollideHandler hit))
        {
            if (hit.CompareTag("HitBox"))
            {
                var hitOwner = hit.owner;
                if (!hitOwner.GetInstanceID().Equals(owner.GetInstanceID()))
                {
                    CollideExitEvent?.Invoke(hitOwner);
                }
            }
        }
    }
}
