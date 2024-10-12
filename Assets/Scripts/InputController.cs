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
            character.Attack(mousePosition);
        }
    }

    private void Move(Character character)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        var moveVector = new Vector2(moveX, moveY);
        moveVector.Normalize();

        character.Move(moveVector);
    }
}
