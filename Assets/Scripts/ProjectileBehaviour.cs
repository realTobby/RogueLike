using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float TimeToLive = 0.4f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // =>
        if(collision.collider.gameObject.tag == "WALL")
        {
            CameraController.Shake(0.08f, 0.1f);

            GameObject ex = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(ex, 2f);
            Destroy(this.gameObject);
        }
    }
}
