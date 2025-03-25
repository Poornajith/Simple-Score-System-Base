using UnityEngine;

public class OrbitSelf : MonoBehaviour
{
    [SerializeField] private float orbitSpeed = 20f;
    private void Update()
    {
        Orbit();
    }
    private void Orbit()
    {
        transform.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
