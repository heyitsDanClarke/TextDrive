using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

    public float speed = 100;
    public GameObject segment;
    public Material alternate;
    public int numSegments = 16;
    float segmentLength;
    float trackLength;

    private void Start()
    {
        segmentLength = segment.GetComponent<Renderer>().bounds.size.z;
        trackLength = segmentLength * numSegments;
        for (int i = 0; i < numSegments; i++)
        {
            Transform tempSegment = Instantiate(segment, transform).transform;
            tempSegment.position = new Vector3(0, 0, i * segmentLength);
            if (i % 2 == 0)
                tempSegment.GetComponent<Renderer>().material = alternate;
        }
        
    }

    private void Update()
    {
        foreach(Transform child in transform)
        {
            child.localPosition = new Vector3(0, 0, child.localPosition.z - Time.deltaTime * speed);
            if (child.localPosition.z <= 0)
            {
                child.localPosition = new Vector3(0, 0, child.localPosition.z + trackLength);
            }
        }
    }
}
