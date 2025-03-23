using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float deactivateX = -10f;

    private void Update()
    {
        if (transform.position.x < deactivateX)
        {
            gameObject.SetActive(false);
        }
    }
}
