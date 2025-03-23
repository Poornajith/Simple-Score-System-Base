using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
}
