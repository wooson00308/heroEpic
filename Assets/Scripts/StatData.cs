using UnityEngine;

public interface IStats
{
    public float MoveSpeed { get; set; }
    public float AttackSpeed { get; set; }
}

public interface IStatSetable
{
    public void SetUp(IStats stats);
}

[CreateAssetMenu(fileName ="New Stat Data", menuName = "Create Stat Data")]
public class StatData : ScriptableObject, IStatSetable
{
    public float moveSpeed;
    public float attackSpeed;

    public void SetUp(IStats stats)
    {
        stats.MoveSpeed = moveSpeed;
        stats.AttackSpeed = attackSpeed;
    }
}
