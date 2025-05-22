using UnityEngine;

public class CharacterAnimator
{
    private readonly int _velocityHash = Animator.StringToHash("Velocity");
    private readonly int _takeDamageTriggerHash = Animator.StringToHash("HasPain");
    private readonly int _dieTriggerHash = Animator.StringToHash("IsDead");
    private readonly string _injuredLayerName = "Injured Layer";
    private readonly int _activeLayerWeight = 1;

    private Animator _animator;

    public CharacterAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void SetVelocity(float velocity)
    {
        _animator.SetFloat(_velocityHash, velocity);
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(_takeDamageTriggerHash);
    }

    public void Die()
    {
        _animator.SetTrigger(_dieTriggerHash);
    }

    public void ActivateInjuredLayer()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex(_injuredLayerName), _activeLayerWeight);
    }
}