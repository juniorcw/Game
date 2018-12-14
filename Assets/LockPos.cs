using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPos : MonoBehaviour {
    float Lockpos = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(Lockpos, Lockpos, Lockpos);
	}
}
