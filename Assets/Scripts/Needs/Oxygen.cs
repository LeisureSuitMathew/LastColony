using UnityEngine;
using System.Collections;

public class Oxygen : BaseNeeds {

	public float rngMin;
	public float rngMax;

	public float maxDecayIncrease;

	public override bool CheckCriticalLevel ()
	{
		return base.CheckCriticalLevel ();
		//Debug.Log("I am Oxygen!");
	}

	void Start ()
	{
		decay = Random.Range (minDecay, maxDecay);
		tickrate = Random.Range (minTickrate, maxTickrate);
	}

	void Update ()
	{
		if (lastTick <= 0)
		{
			lastTick = tickrate;
			tickrate = Random.Range (minTickrate, maxTickrate);
			value += decay + Random.Range (rngMin, rngMax);
			decay = Random.Range (minDecay, maxDecay);
		}
		lastTick -= Time.deltaTime;
	}

	public override void ChangeMe ()
	{
		base.ChangeMe ();

		float increase = Random.Range (0f, maxDecayIncrease);

		minDecay += increase;
		maxDecay += increase;
	}
}
