using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessengerController : MonoBehaviour {

    public GameObject receivedMessage;
    public GameObject sentMessage;

    float timer = 0;

    List<int> requiredInput;
    int currentIndex = 0;

    bool replying = false;

	void Update ()
    {
        if (!replying)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                timer = 0;
                ReceiveMessage();
                replying = true;
            }
        }
	}

    void ReceiveMessage()
    {
        Instantiate(receivedMessage, transform.GetChild(0));
        requiredInput = new List<int>(){1,2,3};
    }

    void ClearMessages()
    {
        foreach(Transform child in transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }
        currentIndex = 0;
        replying = false;
    }

    public void PostMessage(int word)
    {
        if (replying)
        {
            if(word == requiredInput[currentIndex])
            {
                if (currentIndex == requiredInput.Count - 1)
                {
                    GameMaster.Instance.multiplier += 1;
                    ClearMessages();
                }
                else
                    currentIndex += 1;
            }
            else
            {
                GameMaster.Instance.multiplier = 1;
                ClearMessages();
            }
        }
    }
}
