using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panic : MonoBehaviour {

	float panicLevel;

	public float hpMax;
	float hp;
	public float hpDecrease;
	public float hpIncrease;

	public float tickrate;
	float lastTick;

	bool isPanic;

	void Start () 
	{
		isPanic = false;
		panicLevel = 0;
		hp = hpMax;
	}
	
	void Update () 
	{
		isPanic = CheckForPanic();

		if (lastTick <= 0)
		{
			ManagePanic();
			ManageHitPoints();

			lastTick = tickrate;
		}	

		lastTick -= Time.deltaTime;

		Debug.Log ("isPanic: " + isPanic);
		Debug.Log ("Panic: " + panicLevel);
	}

	bool CheckForPanic ()
	{
		for (int i = 0; i<BaseController.Instance.criticalLevels.Length; i++)
		{
			if (BaseController.Instance.criticalLevels[i])
				return true;
		}
		return false;
	}

	void ManagePanic ()
	{
		if(isPanic)
		{
			panicLevel += 0.01f;
		}
		if (!isPanic)
		{
			panicLevel -= 0.01f;
		}
		if (panicLevel >= 1)
			panicLevel = 1;
		if (panicLevel <= 0)
			panicLevel = 0;
	}

	void ManageHitPoints ()
	{
		if (panicLevel >= 1)
			hp -= hpDecrease;
		if (panicLevel < 1)
			hp += hpIncrease;
		if (hp >= hpMax)
			hp = hpMax;
		if (hp <= 0)
			Death();
		
	}

	void Death ()
	{
		BaseController.Instance.dead = true;
	}

	public float GivePanicLevel ()
	{
		return panicLevel * 100;
	}

	public bool GivePanic()
	{
		Debug.Log ("Panic!");
		return isPanic;
	}
}
