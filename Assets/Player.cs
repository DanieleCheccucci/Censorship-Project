using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
	public static float minTrust = -50f;
	public static float maxKnowledge = 50f;
	public static int globalTrust;
	public static int globalKnowledge;

	void Awake()
	 {
		 DontDestroyOnLoad(this.gameObject);
	 }
	void Start()
	{

	}

	void Update ()
    {
		UpdateValues();
    }

    void UpdateValues()
    {
    	float kRatio = (100*globalKnowledge)/maxKnowledge;
		float tRatio = (100*globalTrust)/(Math.Abs(minTrust));
    }
}
