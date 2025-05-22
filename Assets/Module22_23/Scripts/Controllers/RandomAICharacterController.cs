using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAICharacterController : Controller
{
    [SerializeField] private Character _character;

    private float _time;
    private float _timeToChangeDirection;

    public RandomAICharacterController(Character character, float timeToChangeDirection)
    {
        _character = character;
        _timeToChangeDirection = timeToChangeDirection;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _time += deltaTime;

        if (_time >= _timeToChangeDirection)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
            _character.SetMoveDirection(randomDirection);
            _character.SetRotationDirection(randomDirection);

            _time = 0;
        }
    }
}
