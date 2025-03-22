using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private InputActionReference move;

    private Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>().normalized;
        float movementMultiplier = moveSpeed * Time.deltaTime;
        transform.Translate(
            new Vector3(moveDirection.x * movementMultiplier, moveDirection.y * movementMultiplier, 0));
    }
}
