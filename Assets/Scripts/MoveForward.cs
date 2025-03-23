using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveSpeedMin = 0.5f;
    [SerializeField] private float moveSpeedMax = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void RandomizeSpeed()
    {
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
    }
}
