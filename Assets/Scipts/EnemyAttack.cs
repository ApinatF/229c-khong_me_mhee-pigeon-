using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject target;
    
    [SerializeField] private float speed = 10f;

    private float towerX, targetX, dist, nextX, baseY, height;
    
    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("EnemyUnit");
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        towerX = tower.transform.position.x;
        targetX = target.transform.position.x;

        dist = targetX - towerX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(tower.transform.position.y, target.transform.position.y, (nextX - towerX) / dist);
        height = 2 * (nextX - towerX) * (nextX - towerX) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
