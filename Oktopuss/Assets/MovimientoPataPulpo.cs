using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPataPulpo : MonoBehaviour {
    public Transform[] path;
    private Rigidbody rb;
    public float speed;
    int pathGoes;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        pathGoes = Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;         
            transform.position = Vector3.MoveTowards(transform.position, path[pathGoes].position, step);
            if (transform.position == path[pathGoes].position)
            {
             RandomMe(); 
            }       
	}

    void RandomMe()
    {
        pathGoes = Random.Range(0, 3);
    }

}
