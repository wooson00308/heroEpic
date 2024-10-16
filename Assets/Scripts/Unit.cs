using Scripts.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Unit : MonoBehaviour
    {
        [Header("Config")]
        public float moveSpeed;
        public float attackSpeed;

        protected Team _team;
        public Team Team => _team;

        protected UnitAnimatior _unitAnimatior;
        protected ControllerBase _controller;
        protected Movement _movement;
        protected Attack _attack;

        public bool IsRun => _unitAnimatior.IsRun; 
        public bool IsAttack => _unitAnimatior.IsAttack;
        public bool IsHit => _unitAnimatior.IsHit;
        public bool IsDeath => _unitAnimatior.IsDeath;

        private void Awake()
        {
            _unitAnimatior = GetComponentInChildren<UnitAnimatior>();
            _controller = GetComponent<ControllerBase>();
            _movement = GetComponent<Movement>();
            _attack = GetComponent<Attack>();
        }

        private void Update()
        {
            if (_controller != null) 
            {
                _controller.OnUpdate(this);
            }
        }

        public void Idle()
        {
            _unitAnimatior.Idle();
        }

        public void Run(Vector3 runDir)
        {
            _unitAnimatior.Run(runDir);
            _movement.OnMove(this, runDir);
        }

        public void Attack(Vector3 attackDir)
        {
            _unitAnimatior.Attack(attackDir);
        }

        public void Hit(Unit attacker)
        {
            _unitAnimatior.Hit();
        }

        public void Death(Unit attacker)
        {
            _unitAnimatior.Death();
        }

    }
}

