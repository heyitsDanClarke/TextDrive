using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {

    public float speed = 2;
    public GameObject[] hazards;

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

        int numHazards = Random.Range(0, 6);
        foreach (Transform child in chunk.GetChild(3))
            Destroy(child.gameObject);
        int spawnY = -8;
        for (int i = 0; i < numHazards; i++)
        {
            int lane = Random.Range(0, 3);
            Transform newHazard = Instantiate(hazards[Random.Range(0, hazards.Length)], chunk.GetChild(3)).transform;
            if (lane == 0)
                newHazard.localPosition = new Vector2(-1.5f, spawnY);
            else if(lane == 1)
                newHazard.localPosition = new Vector2(0, spawnY);
            else
                newHazard.localPosition = new Vector2(1.5f, spawnY);
            spawnY += 4;
        }
    }
}
