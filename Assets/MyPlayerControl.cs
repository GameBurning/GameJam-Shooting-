using UnityEngine;
using System.Collections;

public class MyPlayerControl : MonoBehaviour
{

    float maxSpeed = 1;
    float moveForce = 10;
    float speed = 5;

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Speed" + this.GetComponent<Rigidbody>().velocity);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h * Time.deltaTime, 0, v * Time.deltaTime) * speed, Space.World);
        //if (this.GetComponent<Rigidbody>().velocity.magnitude > 0.5)
        transform.LookAt(transform.position + new Vector3(h, 0, v));
        #region question
        //How to translate it using force
        //GetComponent<Rigidbody>().AddForce((Vector3.right * h + Vector3.forward * v) * moveForce);
        #endregion
    }
}
