using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Movement : MonoBehaviour
    {
        public void OnMove(Unit unit, Vector3 moveDir)
        {
            unit.transform.position += Time.deltaTime * unit.moveSpeed * moveDir;
        }
    }
}

