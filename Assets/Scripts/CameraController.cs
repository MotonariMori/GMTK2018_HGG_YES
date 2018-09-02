using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Target;

	// Use this for initialization
	void Start () {

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, -10);  

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Target.transform.position.x, transform.position.y, -10);

        if (Mathf.Abs(transform.position.y - Target.transform.position.y) > 1)
            transform.position = Vector3.Lerp(transform.position, Target.transform.position, 5f * Time.deltaTime);

        if (transform.position.y < -1)
            transform.position = new Vector3(transform.position.x, -1, -10);

	}


}
