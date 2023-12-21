using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampObstacleManager : ObstacleManager
{
    public GameObject obstacle;
    public GameObject attackRange;

    private void Start() {
        obstacle.SetActive(false);
        obstacle.SetActive(false);

        Swamp ObstacleScript = obstacle.GetComponent<Swamp>();
        CircleAttackRange AttackRangeScript = attackRange.GetComponent<CircleAttackRange>();

        StartCoroutine((new[] {
            AttackRangeScript.Excute(),
            ObstacleScript.Excute(),
            Destroy()
            
        }).GetEnumerator());
    }

    public IEnumerator Destroy() {
        Destroy(gameObject);
        
        yield return null;
    }
}
