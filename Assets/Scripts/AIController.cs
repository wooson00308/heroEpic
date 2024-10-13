using UnityEngine;

[CreateAssetMenu(fileName = "New AI Controller", menuName = "Create AI Controller")]
public class AIController : Controller
{
    public float moveDuration;
    public float attackDistance;

    public override void OnUpdate(Character character) { }
}
