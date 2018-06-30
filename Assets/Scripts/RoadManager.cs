using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {

    public float speed = 2;
	
	void Update () {
        foreach(Transform child in transform)
        {
            child.position = new Vector2(0, child.position.y - Time.deltaTime * speed);
            if (child.position.y <= -20)
                GenerateChunk(child);
        }
	}

    void GenerateChunk(Transform chunk)
    {
        chunk.position = new Vector2(0, chunk.position.y + 60);
    }
}
