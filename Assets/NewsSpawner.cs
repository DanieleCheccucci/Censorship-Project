using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System;

public class NewsSpawner : MonoBehaviour {

	public GameObject[] NewsOrder;
	public GameObject censorship;
	public float timeToHold = 70f;
	int newsNumber;
	GameObject thiscensorship;
	GameObject currentNews;
	GameObject canvas;
	float time;
	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas");
		newsNumber = 0;
		time = 0;
		InstantiateObject();
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfHoldOrTap();
	}

	private void CheckIfHoldOrTap()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            time = time +1f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (time < timeToHold)
            {
                SpaceTap();
            }
			else
			{
				SpaceHold();
			}
        }
    }

	void SpaceTap()
    {
        Censorship();
        Destroy(thiscensorship, 2f);
        Destroy(currentNews, 2f);
        Invoke("InstantiateObject", 2f);
        time = 0f;
        UpdateTrustKnowledge();
    }

    private static void UpdateTrustKnowledge()
    {
        Player.globalKnowledge += NewsDisplay.newsKnowledge;
        Player.globalTrust += NewsDisplay.newsTrust;
    }

    void Censorship()
	{
		thiscensorship = Instantiate(censorship,canvas.transform);
	}

    void InstantiateObject()
	{

		if(newsNumber < NewsOrder.Length)
		{
			currentNews = Instantiate(NewsOrder[newsNumber],canvas.transform); 
		}
		newsNumber += 1;
		print(newsNumber + " " + NewsOrder.Length);
		if(newsNumber > NewsOrder.Length)
		{
			LoadNextScene();
		}
	}

	void LoadNextScene()
    {
		int currentSceneIndex = EditorSceneManager.GetActiveScene().buildIndex;
		int nextSceneIndex = currentSceneIndex +1;
		EditorSceneManager.LoadScene(nextSceneIndex);
	}

    void SpaceHold()
	{
		Destroy(thiscensorship,1f);
		Destroy(currentNews, 1f);
		Invoke("InstantiateObject",1f);
		time = 0f;
		UpdateTrustKnowledge();
	}
}
