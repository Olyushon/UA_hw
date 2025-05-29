using UnityEngine;

public class CharacterViewAnimator : MonoBehaviour
{
    private readonly int _isRunningHash = Animator.StringToHash("IsRunning");
    private readonly int _isJumpingHash = Animator.StringToHash("IsJumping");
    private readonly int _takeDamageHash = Animator.StringToHash("HasPain");
    private readonly int _dieHash = Animator.StringToHash("IsDead");
    private readonly string _injuredLayerName = "Injured Layer";
    private readonly int _activeLayerWeight = 1;

    [SerializeField] private Animator _animator;
    private AgentCharacter _agentCharacter;

    private void Awake()
    {
        _agentCharacter = GetComponent<AgentCharacter>();
    }

    private void Update()
    {
        SetIsRunning(_agentCharacter.HasPath);
        SetIsJumping(_agentCharacter.IsJumping);
    }

    private void SetIsRunning(bool isRunning)
    {
        _animator.SetBool(_isRunningHash, isRunning);
    }

    private void SetIsJumping(bool isJumping)
    {
        _animator.SetBool(_isJumpingHash, isJumping);
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(_takeDamageHash);
    }

    public void Die()
    {
        _animator.SetTrigger(_dieHash);
    }

    public void ActivateInjuredLayer()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex(_injuredLayerName), _activeLayerWeight);
    }
}