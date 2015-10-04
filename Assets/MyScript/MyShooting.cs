using UnityEngine;
using System.Collections;

public class MyShooting : MonoBehaviour
{

    public Rigidbody bulletRig;
    public float speed = 20;
    public float force = 50000;
    public static int shootFiled = 0;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody a = Instantiate(bulletRig, transform.GetChild(0).position + (transform.position - transform.GetChild(0).position) * 0.1f, transform.rotation) as Rigidbody;
        a.AddForce(transform.TransformDirection(new Vector3(Random.Range(-shootFiled, shootFiled + 1) * 1.5f + Random.Range(-0.1f, 0.1f), 0, force)));
        //Double the bullet when reach max value
        if (shootFiled >= 10)
        {
            Rigidbody b = Instantiate(bulletRig, transform.GetChild(0).position + (transform.position - transform.GetChild(0).position) * 0.1f, transform.rotation) as Rigidbody;
            b.AddForce(transform.TransformDirection(new Vector3(Random.Range(-shootFiled, shootFiled + 1) * 1.5f + Random.Range(-0.1f, 0.1f), 0, force)));
        }
        Destroy(a.gameObject, 3);
    }
}
