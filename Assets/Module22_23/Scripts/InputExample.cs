using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Controller _controller;

    private void Awake()
    {
        _controller = new UserCharacterController(_character);
        // _controller = new RandomAICharacterController(_character, 1f);
        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }
}
