using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ByMouseClickAgentController : Controller
{
    private readonly int LeftMouseButton = 0;

    private AgentCharacter _agentCharacter;

    public ByMouseClickAgentController(AgentCharacter agentCharacter, OneFlagService flagService)
    {
        _agentCharacter = agentCharacter;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (_agentCharacter.IsOnMeshLink(out OffMeshLinkData offMeshLinkData))
        {
            if (_agentCharacter.IsJumping == false)
            {
                _agentCharacter.SetRotation(offMeshLinkData.endPos - offMeshLinkData.startPos);
                _agentCharacter.Jump(offMeshLinkData);
            }
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
            return;

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
