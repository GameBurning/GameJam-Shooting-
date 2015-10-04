using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

    GameObject player;
    Transform playerTransform;
    private Vector3 velocity = Vector3.zero;
    Camera myCamera;
    public float dampTime = 0.15f;
	// Use this for initialization
	void Start () {
        myCamera = GetComponent<Camera>();
        player = GameObject.Find("Cube");
        playerTransform = player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerTransform)
        {
            Vector3 point = myCamera.WorldToViewportPoint(playerTransform.position);
            Vector3 delta = playerTransform.position - myCamera.ViewportToWorldPoint(new Vector3(0.5f,  0.5f, point.z));
            Vector3 destination = transform.position + delta;
            Debug.Log(transform.position);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}
}
