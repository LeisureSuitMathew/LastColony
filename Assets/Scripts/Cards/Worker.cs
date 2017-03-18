using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour {

	float[] skills;

	void Start()
	{
		skills = new float[5];
		for (int i = 0; i < skills.Length; i++)
		{
			skills[i] = Random.Range (0f, 10f);
		}
	}

	public float[] Skills()
	{
		return skills;
	}
}
