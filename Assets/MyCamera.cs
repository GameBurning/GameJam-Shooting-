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
            //Debug.Log(transform.position);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}
    float duration = 0.1f;
    float magnitude = 0.5f;

    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float z = Random.value * 2.0f - 1.0f;
            
            x *= magnitude * damper;
            z *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, originalCamPos.y, z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
