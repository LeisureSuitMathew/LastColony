using UnityEngine;
using System.Collections;

public class BaseFactory : MonoBehaviour {

	public BaseNeeds need;
	public BaseNeeds[] costs;

	public int needNumber;

	public float workDifficulty;
	public int[] skillsRequired;

	public float[] costValues;
	public float[] costModifiers;

	public virtual void WorkAt (Worker worker)
	{
		float [] skills = worker.Skills();

		for (int i = 0; i < skillsRequired.Length; i++)
		{
			float workDone = 0;
			workDone = skills[skillsRequired[i]] * workDifficulty;
			need.TakeHit (-workDone);
			if (need.value <= 0)
				need.value = 0;
		}

		for (int y = 0; y < costs.Length; y++)
		{
			costs[y].WorkCost(costValues[y] * costModifiers[y], needNumber);
		}

		// PLACEHOLDER zwiększenie decay dla OXYGEN przy każdej akcji
		BaseController.Instance.needs[2].ChangeMe();
	}

	public void Action()
	{
		if (BaseController.Instance.activeCard == null)
			return;
		if (need != null) 
		{
			WorkAt (BaseController.Instance.activeCard.worker);
		}
		Destroy (BaseController.Instance.activeCard.gameObject);
		BaseController.Instance.cards--;
	}
}
