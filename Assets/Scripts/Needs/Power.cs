using UnityEngine;
using System.Collections;

public class Power : BaseNeeds {

	public float foodProduction;
	public float oxygenProduction;
	public float hibernationProduction;

	public float rngMin;
	public float rngMax;

	public override bool CheckCriticalLevel ()
	{
		return base.CheckCriticalLevel ();
		//Debug.Log("I am Power!");
	}

	void Start ()
	{
		decay = Random.Range (minDecay, maxDecay);
		tickrate = Random.Range (minTickrate, maxTickrate);
		value = 10;
	}

	void Update ()
	{

	}

	public override void WorkCost (float cost, int mode)
	{
		base.WorkCost (cost, mode);

		switch (mode) 
		{
		case 0:
			ProduceFood ();
			break;
		case 1:
			break;
		case 2:
			ProduceOxygen ();
			break;
		case 3:
			ProduceHibernation ();
			break;
		default:
			break;
		}
	}

	void ProduceFood()
	{
		value += foodProduction;
		foodProduction += Random.Range (rngMin, rngMax);
	}

	void ProduceOxygen()
	{
		value += oxygenProduction;
		oxygenProduction += Random.Range (rngMin, rngMax);
	}

	void ProduceHibernation()
	{
		value += hibernationProduction;
		hibernationProduction += Random.Range (rngMin, rngMax);
	}
}