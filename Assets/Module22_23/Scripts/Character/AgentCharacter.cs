using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IDamagable, IBombActivator
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _injuredHealthPercentLimit = 30;

    [SerializeField] private float _rotationSpeed = 700f;


    private Health _health;
    private NavMeshAgent _agent;
    private DirectionalRotator _rotator;
    private CharacterViewAnimator _characterAnimator;


    public bool HasPath => IsDead == false && _agent.hasPath;
    public bool IsDestinationReached => _agent.remainingDistance <= _agent.stoppingDistance;
    public Vector3 Destination => _agent.destination;
    private bool IsDead => _health.IsDead;
    private bool IsInjured => _health.IsInjured;

    private void Awake()
    {
        _health = new Health(_maxHealth, _injuredHealthPercentLimit);

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _rotator = new DirectionalRotator(transform, _rotationSpeed);

        _characterAnimator = GetComponent<CharacterViewAnimator>();
    }

    private void Update()
    {
        if (IsDead)
            return;

        _characterAnimator.SetIsRunning(_agent.hasPath);

        if (_agent.hasPath)
        {
            _rotator.SetInputDirection(_agent.desiredVelocity);
            _rotator.Update(Time.deltaTime);
        }
    }

    public void SetDestination(Vector3 destination)
    {
        if (IsDead)
            return;

        _agent.SetDestination(destination);
    }

    public void TakeDamage(int damage)
    {
        if (_health.TryTakeDamage(damage))
        {
            _characterAnimator.TakeDamage();

            if (IsInjured)
                _characterAnimator.ActivateInjuredLayer();

            if (IsDead)
                _characterAnimator.Die();
        }
    }
}
