using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Data")]
    public CharacterStats stats;
    public Controller controller;

    [Header("Animator")]
    public Animator animator;
    public float moveSpeedAnimOffset = 2;

    [Header("Action")]
    public Movement movement;
    public Attack attack;


    private void Start()
    {
        UpdateStats();
    }

    private void Update()
    {
        controller.OnUpdate(this);
    }

    public void UpdateStats()
    {
        animator.SetFloat("AttackSpeed", stats.AttackSpeed);
        animator.SetFloat("MoveSpeed", stats.MoveSpeed / moveSpeedAnimOffset);
    }

    public void Attack(Vector2 mousePosition)
    {
        animator.SetTrigger("Attack");
        attack.Action(mousePosition);

        if (animator.GetInteger("AttackState") == 2) return;
        movement.Rotation((Vector3)mousePosition - transform.position);
    }

    public void Move(Vector2 moveVector)
    {
        if (animator.GetBool("IsAttack")) return;
        animator.SetBool("Run", moveVector != Vector2.zero);
        movement.Action(stats.MoveSpeed, moveVector);
    }

    public void Death()
    {

    }

    public void Hit()
    {

    }
}
