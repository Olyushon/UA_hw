using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IDamagable, IBombActivator
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _injuredHealthPercentLimit = 30;

    [SerializeField] private float _rotationSpeed = 700f;

    [SerializeField] private GameObject _destinationFlagPrefab;

    private Health _health;
    private NavMeshAgent _agent;
    private DirectionalRotator _rotator;
    private CharacterViewAnimator _characterAnimator;

    private GameObject _destinationFlag;

    private void Awake()
    {
        _health = new Health(_maxHealth, _injuredHealthPercentLimit);

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _rotator = new DirectionalRotator(transform, _rotationSpeed);

        _characterAnimator = new CharacterViewAnimator(GetComponentInChildren<Animator>());
    }

    private void Update()
    {
        if (IsDead)
            return;

        _characterAnimator.SetIsRunning(_agent.hasPath);

        if (_agent.hasPath)
        {
            if (_destinationFlag == null)
                PutDestinationFlag();

            _rotator.SetInputDirection(_agent.desiredVelocity);
            _rotator.Update(Time.deltaTime);
        }
        else if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            RemoveDestinationFlag();
        }
    }

    private bool IsDead => _health.IsDead;
    private bool IsInjured => _health.IsInjured;


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

    private void PutDestinationFlag()
    {
        _destinationFlag = Instantiate(_destinationFlagPrefab, _agent.destination, Quaternion.identity);
    }

    private void RemoveDestinationFlag()
    {
        Destroy(_destinationFlag);
        _destinationFlag = null;
    }
}
