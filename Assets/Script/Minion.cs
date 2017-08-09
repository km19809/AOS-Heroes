using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion : StatusControls {

    public float minionSpeed = 5.0f; //미니언의 스피드
    public LayerMask whatIsEnemy; // 여기에 넣은 Layer를 공격함.
    public float range = 15.0f; // 미니언이 공격할 범위 (근거리라서 짧게함)
    public float attackPower = 10.0f;
    private float attackCountdown = 1.0f; // 공격주기를 구현하기 위해 사용하는 보조변수
    public float attackCycle = 2.0f; // 공격주기 (초) 
    private Transform target; // Q. Gameobject를 타입으로 쓸 수도 있나?
    public Transform enemyTower;
    private NavMeshAgent nav;


    // Use this for initialization.
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.isStopped = false;
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); /* 0초 때 UpdateTarget이란 함수를
        0.5초 간격으로 실행함.*/
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        //자신의 위치를 기준으로 range를 반지름으로 하는 구의 반경에 잡힌 whatIsEnemy에 넣어진 layer를 가진 Collider를 반환

        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider currentCollider in colliders)
        {
            float distance = Vector3.Distance(transform.position, currentCollider.transform.position);
            //이 Minion과 읽고있는 currentCollider과의 거리
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = currentCollider.transform;
            }
        }

        target = nearestEnemy;
    }
    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            idle();
        } //target 없을 때 적 타워로 이동.
        else if (target)
        {
            chase();
        }
        if (nav.isStopped == true && target)
        {
            attack(target);
        }
       
    }

    void idle()
    {
        nav.isStopped = false;
        nav.SetDestination(enemyTower.position);
    }

    void chase()
    {
        nav.isStopped = false;
        nav.SetDestination(target.position);   
    }

    void attack(Transform target)
    {
        if (attackCountdown < 0)
        {
            //target.healthController.OnDamage(minionDamage);
            attackCountdown = attackCycle; // 공격주기 (초)
        }
        attackCountdown -= Time.deltaTime;
        // 적 체력 깎기
    }
}
