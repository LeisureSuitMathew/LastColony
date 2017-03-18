using UnityEngine;
using System.Collections;

public abstract class BaseNeeds : MonoBehaviour {

	public float minDecay;
	public float maxDecay;
	protected float decay;
	public float criticalLevel;
	public float minTickrate;
	public float maxTickrate;
	protected float tickrate;

	[HideInInspector] public float value;
	[HideInInspector] public float lastTick;

	public virtual void TakeHit (float hit)
	{
		value += hit;
	}

	public virtual bool CheckCriticalLevel ()
	{
		//Debug.Log ("Checking Critical Level " + i);
			if (value < criticalLevel)
			{
				return false;
			}
			else
				{Debug.Log ("Critical level reached!");
				return true;
			}
		
		//return false;
	}

	public virtual void ChangeMe () { }

	public virtual void WorkCost (float cost, int mode) {	}
}
