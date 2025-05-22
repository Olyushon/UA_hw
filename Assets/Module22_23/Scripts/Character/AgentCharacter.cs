using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 500f;

    private NavMeshAgent _agent;
    private DirectionalRotator _rotator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _rotator = new DirectionalRotator(transform, _rotationSpeed);
    }

    private void Update()
    {
        if (_agent.hasPath)
        {
            _rotator.SetInputDirection(_agent.desiredVelocity);
        }

        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
}
