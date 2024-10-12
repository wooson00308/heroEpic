using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Action(float moveSpeed, Vector3 moveVector)
    {
        Position(moveSpeed, moveVector);
        Rotation(moveVector);
    }

    public void Position(float moveSpeed, Vector3 moveVector)
    {
        transform.position += moveSpeed * Time.deltaTime * moveVector;
    }

    public void Rotation(Vector3 moveVector)
    {
        if (moveVector.x == 0) return;
        if (moveVector.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(moveVector.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
