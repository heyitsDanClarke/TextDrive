using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown("left"))
            transform.position = transform.position.x <= -1.5 ? transform.position : new Vector3(transform.position.x - 1.5f, transform.position.y,transform.position.z);
        if(Input.GetKeyDown("right"))
            transform.position = transform.position.x >= 1.5 ? transform.position : new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
            Destroy(gameObject);
    }
}
