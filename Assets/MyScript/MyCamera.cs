using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

    GameObject player;
    Transform playerTransform;
    private Vector3 velocity = Vector3.zero;
    //Camera myCamera;
    Vector3 targetPosition;
    // Use this for initialization
    void Start () {
        //myCamera = GetComponent<Camera>();
        player = GameObject.Find("Cube");
        playerTransform = player.GetComponent<Transform>();
        Vector3 targetPosition = playerTransform.position + new Vector3(MyPlayerControl.h * 3.5f, 0, MyPlayerControl.v * 2.5f);
    }
	
	// Update is called once per frame
	void Update () {
        float vt = 0;
        float ht = 0;
        if(MyPlayerControl.h >= 0.9f || MyPlayerControl.h < -0.9f || MyPlayerControl.v >= 0.9f || MyPlayerControl.v <= -0.9f)
        {
            vt = MyPlayerControl.v;
            ht = MyPlayerControl.h;
        }
        targetPosition = playerTransform.position + new Vector3(ht * 3.5f, 0, vt * 3.5f);
        this.transform.position += new Vector3((targetPosition.x - this.transform.position.x) * Time.deltaTime * 4.5f, 0, (targetPosition.z - this.transform.position.z) * Time.deltaTime * 2.5f);
	}
   
}
