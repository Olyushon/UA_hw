using UnityEngine;

public class Character : MonoBehaviour, IDamagable, IBombActivator
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _injuredHealthPercentLimit = 30;

    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 500f;

    private Health _health;
    private DirectionalMover _mover;
    private DirectionalRotator _rotator;
    private CharacterAnimator _characterAnimator;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    private void Awake()
    {
        _health = new Health(_maxHealth, _injuredHealthPercentLimit);
        _mover = new DirectionalMover(GetComponent<CharacterController>(), _movementSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);
        _characterAnimator = new CharacterAnimator(GetComponentInChildren<Animator>());
    }

    private void Update()
    {
        if (IsDead)
            return;

        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }

    private bool IsDead => _health.IsDead;
    private bool IsInjured => _health.IsInjured;

    public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);
    public void SetRotationDirection(Vector3 direction) => _rotator.SetInputDirection(direction);

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
