using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPataPulpo : MonoBehaviour {
    public Transform[] path;
    private Rigidbody rb;
    public float speed;
    int pathGoes;
    float i = 0;

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
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y,0);
            
                 if (i >= 2.0f)
                  { 
                     RandomMe();
                       i = 0;
                  }
                  else
                  {
                     i += Time.deltaTime;
                  }
            }       
	}

    void RandomMe()
    {
        pathGoes = Random.Range(0, 3);
    }

}
