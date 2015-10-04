using UnityEngine;
using System.Collections;

public class MyPlayerControl : MonoBehaviour
{

    float maxSpeed = 1;
    float moveForce = 10;
    float speed = 5;
    bool isJump = false;
    Rigidbody rig;

    // Use this for initialization
    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.J))
        {
            rig.AddRelativeTorque(100000, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 10;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 5;
        }
        #region question
        //How to translate it using force
        //GetComponent<Rigidbody>().AddForce((Vector3.right * h + Vector3.forward * v) * moveForce);
        #endregion
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "PowerUp")
        {
            if (MyShooting.shootFiled <= 10)
                MyShooting.shootFiled++;
            MyGameControl.hasPowerUp = false;
            Destroy(coll.gameObject);
        }
    }
}
