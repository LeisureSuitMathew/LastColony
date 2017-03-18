using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Text food;
	public Text oxygen;
	public Text power;
	public Text panic;
	public Text survived;
	public Text survivedScore;
	public Image panicOverlay;
	public GameObject gameOverOverlay;

	void Start () 
	{
		panicOverlay.GetComponent<Image>().enabled = true;
	}

	void Update () 
	{
		food.text = "Food: " + BaseController.Instance.GiveNeed(0);
		power.text = "Power: " + BaseController.Instance.GiveNeed(1);
		oxygen.text = "Oxygen: " + BaseController.Instance.GiveNeed(2);
		panic.text = "Panic: " + BaseController.Instance.panic.GivePanicLevel() + "%";
		survived.text = "Survived: " + BaseController.Instance.survivedTime.GiveTime ();
		survivedScore.text = "Survived: " + BaseController.Instance.survivedTime.GiveTime ();

		panicOverlay.GetComponent<Image>().enabled = BaseController.Instance.panic.GivePanic ();
		if (BaseController.Instance.panic.GivePanicLevel () == 100) {
			panicOverlay.GetComponent<Animator> ().SetBool ("TakingDamage", true);
		} else 
		{
			panicOverlay.GetComponent<Animator> ().SetBool ("TakingDamage", false);
		}

		if (BaseController.Instance.dead)
			gameOverOverlay.SetActive(true);
	}
}
