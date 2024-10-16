using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimatior : MonoBehaviour
{
    protected Animator _animator;

    protected readonly int _idleState = Animator.StringToHash("Idle");
    protected readonly int _runState = Animator.StringToHash("Run");
    protected readonly int _attackState = Animator.StringToHash("Attack");
    protected readonly int _hitState = Animator.StringToHash("Hit");
    protected readonly int _deathState = Animator.StringToHash("Death");

    public bool IsRun => _animator.GetBool(_runState);
    public bool IsAttack => _animator.GetBool(_attackState);
    public bool IsHit => _animator.GetBool(_hitState);
    public bool IsDeath => _animator.GetBool(_deathState);

    private int _currentStateHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _currentStateHash = _idleState;
    }

    public void Idle()
    {
        if (_currentStateHash == _idleState) return;
        _currentStateHash = _idleState;
        _animator.SetBool(_runState, false);
    }

    public void Run(Vector3 runDir)
    {
        if (_currentStateHash == _runState) return;
        _currentStateHash = _runState;
        _animator.SetBool(_runState, true);
    }

    public void Attack(Vector3 attackDir)
    {
        if (_currentStateHash == _attackState) return;
        _currentStateHash = _attackState;
        _animator.SetTrigger("AttackTrigger");
    }

    public void Hit()
    {
        //if (_currentStateHash == _hitState) return;
        _currentStateHash = _hitState;
        _animator.SetTrigger("HitTrigger");
    }

    public void Death()
    {
        if (_currentStateHash == _deathState) return;
        _currentStateHash = _deathState;
        _animator.SetBool(_deathState, true);
    }
}
