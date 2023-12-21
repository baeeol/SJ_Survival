using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacleManager : ObstacleManager
{
    public GameObject obstacle;
    public GameObject attackRange;

    private void Start() {
        SetRandomPlayerPosition();

        obstacle.SetActive(false);
        obstacle.SetActive(false);

        Rock ObstacleScript = obstacle.GetComponent<Rock>();
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
