using UnityEngine;

public class UserCharacterController : Controller
{
    private Character _character;

    public UserCharacterController(Character character)
    {
        _character = character;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _character.SetMoveDirection(inputDirection);
        _character.SetRotationDirection(inputDirection);
    }
}
