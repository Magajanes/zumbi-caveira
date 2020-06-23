using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public const float JUMP_SUSTAIN_THRESHOLD = 0.25f;
    public const string JUMP_TRIGGER_NAME = "Jump";

    [Header("Movement Parameters")]
    [SerializeField]
    private float jumpIntensity;
    [SerializeField]
    private float jumpSustain;

    [Header("References")]
    [SerializeField]
    private Rigidbody2D zombieRigidbody2D;
    [SerializeField]
    private Collider2D groundDetector;
    [SerializeField]
    private Animator zombieAnimator;

    private bool buttonPressed;
    private float _sustainCounter;
    private Touch _touch;

    private bool OnGround
    {
        get => groundDetector.IsTouchingLayers(LayerMask.GetMask("Static"));
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                buttonPressed = true;
                Jump();
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                buttonPressed = false;
            }
        }
#endif
    }

    private void Jump()
    {
        if (!OnGround)
            return;

        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        _sustainCounter = 0;
        zombieRigidbody2D.AddForce(jumpIntensity * Vector3.up, ForceMode2D.Impulse);
        zombieAnimator.SetTrigger(JUMP_TRIGGER_NAME);

#if UNITY_EDITOR
        while (Input.GetButton("Jump") && _sustainCounter < JUMP_SUSTAIN_THRESHOLD)
        {
            zombieRigidbody2D.AddForce(jumpSustain * Vector3.up, ForceMode2D.Force);
            _sustainCounter += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }
#elif UNITY_ANDROID
        while (buttonPressed && _sustainCounter < JUMP_SUSTAIN_THRESHOLD)
        {
            zombieRigidbody2D.AddForce(jumpSustain * Vector3.up, ForceMode2D.Force);
            _sustainCounter += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }
#endif
    }
}
