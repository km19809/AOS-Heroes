using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking.NetworkSystem;

public class PlayerControl : MonoBehaviour {
     public float moveSpeed = 10f;

    public NavMeshAgent nav;
    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = moveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1))
	    {
	        RaycastHit hit;
	        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000))
	        {

	            nav.destination = hit.point;
	        }
	    }
	    
	}

    
}
