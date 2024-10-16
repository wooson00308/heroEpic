using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Controller
{
    public class PlayerController : ControllerBase
    {
        public override void OnUpdate(Unit unit)
        {
            if (unit == null) return;
            TryRun(unit);
            TryAttack(unit);
        }
        
        private void TryRun(Unit unit)
        {
            if (unit.IsAttack) return;
            if (unit.IsHit) return;
            if (unit.IsDeath) return;

            Vector2 moveVector = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) // 위로 이동
                moveVector.y += 1;
            if (Input.GetKey(KeyCode.S)) // 아래로 이동
                moveVector.y -= 1;
            if (Input.GetKey(KeyCode.A)) // 왼쪽으로 이동
                moveVector.x -= 1;
            if (Input.GetKey(KeyCode.D)) // 오른쪽으로 이동
                moveVector.x += 1;

            moveVector.Normalize();

            if (moveVector == Vector2.zero) unit.Idle();
            else unit.Run(moveVector);
        }

        private void TryAttack(Unit unit)
        {
            if (unit.IsHit) return;
            if (unit.IsDeath) return;

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                unit.Attack(mousePosition);
            }
        }
    }
}

