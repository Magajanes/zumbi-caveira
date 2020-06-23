using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public const string SPEED_TRIGGER_NAME = "Speed";

    [Header("Parameters")]
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float acceleration;

    [Header("References")]
    [SerializeField]
    private Rigidbody2D zombieRigidbody2D;
    [SerializeField]
    private Animator zombieAnimator;
    [SerializeField]
    private Collider2D obstacleDetector;

    private float _speed;
    private Vector3 _velocity;
    private Coroutine startWalkCoroutine;
    private Coroutine continuousWalkCoroutine;

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        StartWalk();
    }

    private void Update()
    {
        AnimateWalk();
    }

    public void StartWalk()
    {
        if (startWalkCoroutine != null)
            return;

        startWalkCoroutine = StartCoroutine(StartWalkingCoroutine());
    }

    private void ContinuousWalk()
    {
        if (continuousWalkCoroutine != null)
            return;

        continuousWalkCoroutine = StartCoroutine(ContinuousWalkCoroutine());
    }

    public void StopWalk()
    {
        StopAllCoroutines();
        startWalkCoroutine = null;
        continuousWalkCoroutine = null;

        _velocity = zombieRigidbody2D.velocity;
        _velocity.x = 0;
        zombieRigidbody2D.velocity = _velocity;
    }

    private void AnimateWalk()
    {
        _speed = zombieRigidbody2D.velocity.x;
        zombieAnimator.SetFloat(SPEED_TRIGGER_NAME, _speed);
    }

    private IEnumerator StartWalkingCoroutine()
    {
        while (_velocity.x < maxSpeed)
        {
            _velocity = zombieRigidbody2D.velocity;
            _velocity.x += acceleration * Time.fixedDeltaTime;
            zombieRigidbody2D.velocity = _velocity;

            yield return new WaitForFixedUpdate();
        }

        startWalkCoroutine = null;
        ContinuousWalk();
    }

    private IEnumerator ContinuousWalkCoroutine()
    {
        while (true)
        {
            _velocity = zombieRigidbody2D.velocity;
            _velocity.x = maxSpeed;
            zombieRigidbody2D.velocity = _velocity;

            yield return new WaitForFixedUpdate();
        }
    }
}
