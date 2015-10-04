using UnityEngine;
using System.Collections;

public class MyBullet : MonoBehaviour {

    Collider bulletColl;
	// Use this for initialization
	void Start () {
        bulletColl = this.GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if(Random.Range(0,11) > 9)
            {
                bulletColl.transform.localScale *= 5;
                bulletColl.isTrigger = true;            
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
