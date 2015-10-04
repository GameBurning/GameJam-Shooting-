using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MyPlayerControl : MonoBehaviour
{

    float maxSpeed = 1;
    float moveForce = 10;
    float speed = 5;
    bool isJump = false;
    Rigidbody rig;
    [SerializeField]
    Transform myCamera;
    static public float h;
    static public float v;
    public Transform gun;
    int life = 3;

    // Use this for initialization
    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
        myCamera = Camera.main.GetComponent<Transform>();
        DOTween.Init();
        gun.DOScaleZ(0.3f, 0.1f).SetLoops(-1);
        //transform.DOShakePosition(0.1f).SetLoops(-1);
        //
    }

    void FixedUpdate()
    {
        //
        //
        rig.AddRelativeForce(-Vector3.forward * 5);
        if (h < 0.1f && v > -0.1f && v < 0.1f && h > -0.1f) ;
        //            rig.AddRelativeForce(-Vector3.forward * 5);
        else
            rig.AddRelativeForce(Vector3.forward * 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Speed" + this.GetComponent<Rigidbody>().velocity);
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
       
        transform.Translate(new Vector3(h * Time.deltaTime, 0, v * Time.deltaTime) * speed, Space.World);
        //if (this.GetComponent<Rigidbody>().velocity.magnitude > 0.5)
        transform.LookAt(transform.position + new Vector3(h, 0, v));
        //transform.DOShakePosition(0.1f)s(-1);
        if (Input.GetKey(KeyCode.J))
        {
            rig.AddRelativeTorque(100000, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 10;
            //myCamera.GetComponent<Transform>().DOShakePosition(0.1f);
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
        else if(coll.gameObject.tag == "Enemy")
        {
            life--;
            if (life <= 0)
            {
                #region question about local and global position
                transform.DOJump(new Vector3(0, 1, 0) + transform.position, 3, 1, 0.5f);
                #endregion
                Time.timeScale = 0.2f;
                Invoke("GameOver", 0.5f);
            }
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }
}
