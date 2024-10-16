using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Controller.AI
{
    public class BasicEnemyAI : AIController
    {
        private TargetDetector _detector;

        [Header("Config")]
        public float chaseDistance;
        public float attackDistance;

        protected override void Awake()
        {
            base.Awake();
            _detector = GetComponent<TargetDetector>();
        }

        protected override void IdleState(FSM fsm, FSM.Step step, FSM.State state)
        {
            if(step == FSM.Step.Enter)
            {
                _unit.Idle();
            }
            else if(step == FSM.Step.Update)
            {
                if (_detector.Target == null) return;

                if(_detector.Distance(_unit) <= chaseDistance)
                {
                    fsm.TransitionTo(RunState);
                }
            }
            else
            {

            }
        }

        protected override void RunState(FSM fsm, FSM.Step step, FSM.State state)
        {
            if (step == FSM.Step.Enter)
            {
                
            }
            else if (step == FSM.Step.Update)
            {
                if (_detector.Distance(_unit) > chaseDistance)
                {
                    fsm.TransitionTo(IdleState);
                    return;
                }
                if(_detector.Distance(_unit) <= attackDistance)
                {
                    fsm.TransitionTo(AttackState);
                    return;
                }

                _unit.Run(_detector.Direction(_unit));
            }
            else
            {

            }
        }

        protected override void AttackState(FSM fsm, FSM.Step step, FSM.State state)
        {
            if (step == FSM.Step.Enter)
            {
                _unit.Attack(_detector.Direction(_unit));
            }
            else if (step == FSM.Step.Update)
            {
                var distnace = _detector.Distance(_unit);
                if (distnace > attackDistance)
                {
                    fsm.TransitionTo(RunState);
                    return;
                }
            }
            else
            {

            }
        }

        protected override void HitState(FSM fsm, FSM.Step step, FSM.State state)
        {
            if (step == FSM.Step.Enter)
            {
                
            }
            else if (step == FSM.Step.Update)
            {

            }
            else
            {

            }
        }

        protected override void DeathState(FSM fsm, FSM.Step step, FSM.State state)
        {
            if (step == FSM.Step.Enter)
            {

            }
            else if (step == FSM.Step.Update)
            {

            }
            else
            {

            }
        }
    }
}

