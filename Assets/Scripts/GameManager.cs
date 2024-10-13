using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Character _player;
    public Character Player => _player;

    public void FixedUpdate()
    {
        if (_player != null) return;

        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _player = playerObj.GetComponent<Character>();
        }
    }

}
