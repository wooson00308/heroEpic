using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Controller
{
    public abstract class AIController : ControllerBase
    {
        protected Unit _unit;

        protected FSM _fsm;

        protected FSM.State _idleState;
        protected FSM.State _runState;
        protected FSM.State _attackState;
        protected FSM.State _hitState;
        protected FSM.State _deathState;

        protected virtual void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        protected void Start()
        {
            _idleState = IdleState;
            _runState = RunState;
            _attackState = AttackState;
            _hitState = HitState;
            _deathState = DeathState;

            _fsm = new FSM();

            _fsm.Start(_idleState);
        }

        protected abstract void IdleState(FSM fsm, FSM.Step step, FSM.State state);
        protected abstract void RunState(FSM fsm, FSM.Step step, FSM.State state);
        protected abstract void AttackState(FSM fsm, FSM.Step step, FSM.State state);
        protected abstract void HitState(FSM fsm, FSM.Step step, FSM.State state);
        protected abstract void DeathState(FSM fsm, FSM.Step step, FSM.State state);


        public override void OnUpdate(Unit unit)
        {
            _fsm.OnUpdate();
        }
    }

}
