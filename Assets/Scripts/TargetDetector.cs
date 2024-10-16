using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public enum Team 
    { 
        Blue,
        Red
    }

    public class TargetDetector : MonoBehaviour
    {
        private Unit _target;
        public Unit Target => _target;

        private void Awake()
        {
            _target = GameManager.Instance.Player;
        }

        public float Distance(Unit unit)
        {
            if(unit == null || _target == null)
            {
                return 999f;
            }

            var distance = Vector2.Distance(unit.transform.position, _target.transform.position);
            return distance;
        }

        public Vector3 Direction(Unit unit)
        {
            if (unit == null || _target == null)
            {
                return Vector3.zero;
            }

            var dir = _target.transform.position - unit.transform.position;
            dir.Normalize();
            return dir;
        }
    }
}

