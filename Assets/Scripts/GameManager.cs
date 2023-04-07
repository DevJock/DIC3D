using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public float forceMultiplier;
	public int dieCount = 1;
	public int controlType = 0; // 0: touch 1: acc
	public bool guiHidden = false;
	public bool touchMode = true;
	public GameObject dies;
	public GameObject hideableGUI;
	public Button hideButton;
	public Button mode;
	public Button addButton;
	public Button removeButton;

	void Start () 
	{
		Application.targetFrameRate = 60;
		dies = new GameObject();
		dies.name = "Dice Holder";
		GameObject.Find ("Dice_1").transform.parent = dies.transform;
	}
		

	void Update()
	{
		if(dieCount > 1)
		{
			removeButton.enabled = true;
		}
		else
		{
			removeButton.enabled = false;
		}
	}


	public void simulateRoll()
	{
		Rigidbody[] rigidBodies = GameObject.FindObjectsOfType<Rigidbody> ();
		foreach(Rigidbody dice in rigidBodies)
		{
			float randX = Random.Range (-10, 11) * 2;
			float randZ = Random.Range (-10, 11) * 2;
			float randXRoll = Random.Range (-10, 11) * 2;
			float randYRoll = Random.Range (-10, 11) * 2;
			float randZRoll = Random.Range (-10, 11) * 2;
			Vector3 randomForce = new Vector3 (randX,3,randZ);
			Vector3 randomRoll = new Vector3 (randXRoll, randYRoll, randZRoll);
			dice.AddForce(randomForce,ForceMode.Impulse);
			dice.AddTorque (randomRoll,ForceMode.Impulse);
		}
	}
		

	public void addDice()
	{
		GameObject newDice = Instantiate (Resources.Load ("Prefabs/Dice") as GameObject);
		newDice.transform.position = new Vector3 (0.15f, 1.89f, -0.19f);
		newDice.transform.rotation = new Quaternion (337.48f, 39.99f, 342.18f, 0);
		newDice.name = "Dice_"+(++dieCount);
		Dice d = newDice.GetComponent<Dice> ();
		d.dieColor = Random.ColorHSV ();
		d.dieDetailColor = Random.ColorHSV ();
		if(controlType == 1)
		{
			newDice.AddComponent<Acceleration>().multiplier = forceMultiplier;
		}
		newDice.transform.parent = dies.transform;
	}


	public void removeDice()
	{
		if(dieCount > 1)
		{
			Destroy(dies.transform.GetChild (dies.transform.childCount - 1).gameObject);
			dieCount--;
		}
	}


	public void toggleMode()
	{
		if(controlType == 0)
		{
			mode.GetComponentInChildren<Text>().text = "ACC Mode";
			controlType = 1;
		}
		else
		{
			mode.GetComponentInChildren<Text>().text = "Touch Mode";
			controlType = 0;
			for(int i=0;i<dies.transform.childCount;i++)
			{
				dies.transform.GetChild (i).gameObject.AddComponent<Acceleration> ().multiplier = forceMultiplier;
			}
		}
	}


	public void toggleGUI()
	{
		if(guiHidden)
		{
			unHideGUI ();
			hideButton.GetComponentInChildren<Text>().text = "Hide GUI";
		}
		else
		{
			hideGUI ();
			hideButton.GetComponentInChildren<Text>().text = "UnHide GUI";
		}
	}


	public void hideGUI()
	{
		for(int i=0;i<hideableGUI.transform.childCount;i++)
		{
			hideableGUI.transform.GetChild (i).gameObject.SetActive (false);
		}
		guiHidden = true;
	}

	public void unHideGUI()
	{
		for(int i=0;i<hideableGUI.transform.childCount;i++)
		{
			hideableGUI.transform.GetChild (i).gameObject.SetActive (true);
		}
		guiHidden = false;
	}






}
