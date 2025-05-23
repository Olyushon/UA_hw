using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private AgentCharacter _agentCharacter;
    [SerializeField] private OneFlagService _flagService;

    private Controller _controller;

    private void Awake()
    {
        _controller = new ByMouseClickAgentController(_agentCharacter, _flagService);
        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }
}
