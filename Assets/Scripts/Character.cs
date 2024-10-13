using UnityEngine;
using UnityEngine.TextCore.Text;

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
    public Inventory inventory;

    [Header("Collider")]
    public CollideHandler HitCollider;
    public CollideHandler AttackCollider;

    private void Start()
    {
        UpdateStats();
    }

    private void OnEnable()
    {
        AttackCollider.CollideEnterEvent += HitTarget;
    }

    private void OnDisable()
    {
        AttackCollider.CollideEnterEvent -= HitTarget;
    }

    private void Update()
    {
        if (controller == null) return;
        controller.OnUpdate(this);
    }

    public void UpdateStats()
    {
        animator.SetFloat("AttackSpeed", stats.AttackSpeed);
        animator.SetFloat("MoveSpeed", stats.MoveSpeed / moveSpeedAnimOffset);
    }

    public void Attack(Vector2 attackPos)
    {
        if (animator.GetBool("IsHit")) return;
        if (animator.GetFloat("AttackDelaying") > 0) return;
        animator.SetTrigger("Attack");

        animator.SetFloat("AttackDelaying", inventory.weapon.attackDelay);

        if (animator.GetInteger("AttackState") == 2) return;
        movement.Rotation((Vector3)attackPos);
    }

    public void Attack2MousePos(Vector2 attackPos)
    {
        animator.SetTrigger("Attack");

        if (animator.GetInteger("AttackState") == 2) return;
        movement.Rotation((Vector3)attackPos - transform.position);
    }

    public void HitTarget(Character target)
    {
        target.Hit(this);
    }

    public void Move(Vector2 moveVector)
    {
        if (animator.GetBool("IsHit")) return;
        if (animator.GetBool("IsAttack")) return;
        animator.SetBool("Run", moveVector != Vector2.zero);
        movement.Action(stats.MoveSpeed, moveVector);
    }

    public void Death()
    {

    }

    public void Hit(Character atttacker)
    {
        animator.SetTrigger("Hit");
    }
}
