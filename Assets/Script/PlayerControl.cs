using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking.NetworkSystem;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed = 10f;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsGround;
    public NavMeshAgent nav;
    public Collider target;


    void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = moveSpeed;
    }

	// Update is called once per frame
	void Update () {

	    if (Input.GetMouseButtonDown(1))
	    {
	        RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity,whatIsEnemy))
            {
                Debug.Log("Hit Enemy");
                nav.SetDestination(hit.point);
                nav.isStopped = false;
                target = hit.collider;
                
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity,whatIsGround))
	        {
                Debug.Log("Hit");
                nav.SetDestination(hit.point);
                nav.isStopped = false;
	        }

            if (target && nav.isStopped == true){
                Attack(target);
            }
	    }
	    
	}

    private void Attack(Collider target)
    {
        
    }
    
}
