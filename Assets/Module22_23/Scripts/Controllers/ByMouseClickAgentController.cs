using UnityEngine;

public class ByMouseClickAgentController : Controller
{
    private readonly int LeftMouseButton = 0;

    private AgentCharacter _agentCharacter;

    public ByMouseClickAgentController(AgentCharacter agentCharacter)
    {
        _agentCharacter = agentCharacter;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _agentCharacter.SetDestination(hit.point);
            }
        }
    }
}
