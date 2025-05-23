using UnityEngine;

public class ByMouseClickAgentController : Controller
{
    private readonly int LeftMouseButton = 0;

    private AgentCharacter _agentCharacter;
    private OneFlagService _flagService;

    public ByMouseClickAgentController(AgentCharacter agentCharacter, OneFlagService flagService)
    {
        _agentCharacter = agentCharacter;
        _flagService = flagService;
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
        if (_agentCharacter.HasPath)
        {
            _flagService.PutFlag(_agentCharacter.Destination);
        }
        else if (_agentCharacter.IsDestinationReached)
        {
            _flagService.RemoveFlag();
        }
    }
}
