using UnityEngine;
using System.Collections;

public class myPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.tag == "Wall")
        {
            MyGameControl.hasPowerUp = false;
            Destroy(this.gameObject);
        }
    }
}
