using UnityEngine;

[CreateAssetMenu(fileName = "New Input Controller", menuName = "Create Input Controller")]
public class InputController : Controller
{
    public override void OnUpdate(Character character)
    {
        Move(character);
        Attack(character);
    }

    private void Attack(Character character)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            character.Attack2MousePos(mousePosition);
        }
    }

    private void Move(Character character)
    {
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
        character.Move(moveVector);
    }

}
