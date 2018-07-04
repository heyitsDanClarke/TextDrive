using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

    public float speed = 3;

    private void Update()
    {
        foreach(Transform child in transform)
        {
            child.localPosition = new Vector3(0, 0, child.localPosition.z - Time.deltaTime * speed);
            if (child.localPosition.z <= -20)
            {
                child.localPosition = new Vector3(0, 0, child.localPosition.z + 150);
            }
        }
    }
}
