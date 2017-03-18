using UnityEngine;
using System.Collections;

public class Food : BaseNeeds {

	public float maxDecayIncrease;

	public override bool CheckCriticalLevel ()
	{
		return base.CheckCriticalLevel ();
		//Debug.Log("I am Food! " + value);
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
			value += decay;
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

	public override void WorkCost (float cost, int mode)
	{
		base.WorkCost (cost, mode);
		value += cost;
	}
}
