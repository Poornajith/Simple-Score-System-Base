using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyIndicator;
    private void OnEnable()
    {
        //if (enemyIndicator == null)
        //{
        //    enemyIndicator = EnemyIndicatorPool.Instance.GetEnemyIndicator();
        //}
        //enemyIndicator.GetComponent<LookForObject>().SetLookTransform(transform);
    }
    private void Update()
    {
        //if (enemyIndicator == null)
        //{
        //    enemyIndicator = EnemyIndicatorPool.Instance.GetEnemyIndicator();
        //}
        //Debug.Log("Enemy Update" + enemyIndicator);
    }
    private void OnDisable()
    {
        //if (enemyIndicator != null)
        //{
        //    enemyIndicator.SetActive(false);
        //}
    }
}
