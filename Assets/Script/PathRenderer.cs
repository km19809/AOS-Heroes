using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathRenderer : MonoBehaviour {

    GameObject player;

    private NavMeshAgent playerNav;
	// Use this for initialization
	void Start () {
	    player = GameObject.FindWithTag("Player");
	    playerNav = player.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {

        
        if (playerNav == null || playerNav.path == null)
            return;

        var line = this.GetComponent<LineRenderer>();
        if (line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
            line.SetWidth(0.5f, 0.5f);
            line.SetColors(Color.yellow, Color.yellow);
        }

        var path = playerNav.path;

        line.SetVertexCount(path.corners.Length);

        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }

    }
}
