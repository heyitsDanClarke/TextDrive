using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Vector2 touchOrigin = -Vector2.one;

	void Update () {
#if UNITY_STANDALONE
        if (Input.GetKeyDown("left"))
            transform.position = transform.position.x <= -5.5 ? transform.position : new Vector3(transform.position.x - 4.5f, transform.position.y,transform.position.z);
        if(Input.GetKeyDown("right"))
            transform.position = transform.position.x >= 5.5 ? transform.position : new Vector3(transform.position.x + 4.5f, transform.position.y, transform.position.z);

#elif UNITY_IOS || UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
                touchOrigin = myTouch.position;
            else if(myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                touchOrigin.x = -1;
                if(x > 0)
                    transform.position = transform.position.x >= 5.5 ? transform.position : new Vector3(transform.position.x + 4.5f, transform.position.y, transform.position.z);
                else
                    transform.position = transform.position.x <= -5.5 ? transform.position : new Vector3(transform.position.x - 4.5f, transform.position.y, transform.position.z);

            }
        }
#endif
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
            Destroy(gameObject);
    }
}
