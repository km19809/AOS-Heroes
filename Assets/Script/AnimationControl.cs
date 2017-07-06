using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationControl : PlayerControl
{
    private Rigidbody rb;
    private Animator anim;

    private Vector3 targetPosition;
    private Vector3 formerTargetPosition;

    // Use this for initialization
    void Start ()
	{
	    rb = GetComponent<Rigidbody>();
	    anim = GetComponent<Animator>();
	    nav = GetComponent<NavMeshAgent>();
        targetPosition=new Vector3(475,0,475);
	}
	
	// Update is called once per frame
	void Update () {
	    TargetToLookAt();
	    if (targetPosition != formerTargetPosition)
	    {
	        Vector3 dir = targetPosition - transform.position;
	        Quaternion lookRotation = Quaternion.LookRotation(dir); //해당방향으로 회전하기위한 쿼터니언 제공

	        transform.rotation =
	            Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime); //(a,b,비율)입력된 비율에 맞는 중간값 반환 0이면 a 1이면 b
	        Vector3 curRotation = transform.rotation.eulerAngles; //사원수를 오일러각으로
	        transform.rotation = Quaternion.Euler(0, curRotation.y, 0);
	    }
	    else
	    {
	        transform.LookAt(targetPosition);
	    }


	    anim.SetFloat("Speed",nav.velocity.magnitude);
	}

    void TargetToLookAt()
    {
        formerTargetPosition = targetPosition;
        //차후 영웅 상태(공견, 이동)에 따라 다르게 타겟을 정할 것. 이동시엔 목적지, 가는 방향. 공격시 목표, 쉴 때 이전.
        if (nav.velocity.magnitude > 0.1f)
        {
            targetPosition = nav.destination;
        }
        else
        {
            targetPosition = formerTargetPosition;
        }


    }
}
