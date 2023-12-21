using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogObstacleManager : ObstacleManager
{
    public GameObject obstacle;
    public GameObject attackRange;

    private void Start() {
        SetRandomRotation(false, true, false);

        obstacle.SetActive(false);
        obstacle.SetActive(false);

        Log ObstacleScript = obstacle.GetComponent<Log>();
        StraightAttackRange AttackRangeScript = attackRange.GetComponent<StraightAttackRange>();

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
