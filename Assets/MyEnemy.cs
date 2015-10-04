using UnityEngine;
using System.Collections;

public class MyEnemy : MonoBehaviour
{

    int life = 10;
    bool invincible = false;
    Transform target;
    float speed = 0.9f;
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Cube").GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            
            if (!invincible)
            {
                this.life--;
                if (life <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if(coll.gameObject.tag == "Enemy")
        {
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate((target.position - this.transform.position).normalized * speed * Time.deltaTime, Space.World);
        
    }
}
