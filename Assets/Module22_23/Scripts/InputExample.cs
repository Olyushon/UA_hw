using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private AgentCharacter _agentCharacter;

    private Controller _controller;

    private void Awake()
    {
        _controller = new ByMouseClickAgentController(_agentCharacter);
        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }
}
