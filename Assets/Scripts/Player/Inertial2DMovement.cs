using System.Collections.Generic;
using UnityEngine;

public class Inertial2DMovement : MonoBehaviour
{
    [SerializeField]
    private WorldVelocityController worldVelocityController;

    [Header("Inputs")]
    [SerializeField]
    private List<KeyCode> upButtons = new List<KeyCode> { KeyCode.UpArrow, KeyCode.W };

    [SerializeField]
    private List<KeyCode> downButtons = new List<KeyCode> { KeyCode.DownArrow, KeyCode.S };

    [SerializeField]
    private List<KeyCode> leftButtons = new List<KeyCode> { KeyCode.LeftArrow, KeyCode.A };

    [SerializeField]
    private List<KeyCode> rightButtons = new List<KeyCode> { KeyCode.RightArrow, KeyCode.D };

    [Header("Physics parameters")]
    [SerializeField]
    private float maxVelocityCoeff = 5f;

    [SerializeField]
    private float accelerationCoeff = 8f;

    [SerializeField]
    private float frictionCoeff = 5f;

    private new Rigidbody2D rigidbody2D;

    private float maxVelocity;
    private float acceleration;
    private float friction;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateConstraints();
        UpdateVelocity(GetInputDirection());
    }

    private void UpdateConstraints()
    {
        maxVelocity = maxVelocityCoeff * worldVelocityController.velocity;
        acceleration = accelerationCoeff * worldVelocityController.velocity;
        friction = frictionCoeff * worldVelocityController.velocity;
    }

    private void UpdateVelocity(Vector2? inputDirection)
    {
        Vector2 velocity = rigidbody2D.velocity;
        if (inputDirection != null)
        {
            velocity += (Vector2)inputDirection * Time.deltaTime * acceleration;
        }
        Vector2 frictionVelocity = velocity.normalized * -1 * Time.deltaTime * friction;
        if (frictionVelocity.sqrMagnitude < velocity.sqrMagnitude)
        {
            velocity += frictionVelocity;

            float velocityMagnitude = velocity.magnitude;
            if (velocityMagnitude > maxVelocity)
            {
                velocity *= maxVelocity / velocityMagnitude;
            }
        }
        else
        {
            velocity = Vector2.zero;
        }
        rigidbody2D.velocity = velocity;
    }

    private Vector2? GetInputDirection()
    {
        Vector2 inputDirection = new Vector2();
        bool somethingPressed = false;
        if (IsAnyHold(upButtons))
        {
            somethingPressed = true;
            inputDirection.y += 1f;
        }
        if (IsAnyHold(downButtons))
        {
            somethingPressed = true;
            inputDirection.y -= 1f;
        }
        if (IsAnyHold(rightButtons))
        {
            somethingPressed = true;
            inputDirection.x += 1f;
        }
        if (IsAnyHold(leftButtons))
        {
            somethingPressed = true;
            inputDirection.x -= 1f;
        }
        if (somethingPressed)
        {
            inputDirection.Normalize();
            return inputDirection;
        } else
        {
            return null;
        }
    }

    private bool IsAnyHold(IList<KeyCode> buttonsList)
    {
        foreach (KeyCode code in buttonsList)
        {
            if (Input.GetKey(code))
            {
                return true;
            }
        }
        return false;
    }
}
