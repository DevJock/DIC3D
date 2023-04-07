using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour 
{
	GameObject me;
	public Color dieColor = Color.clear;
	public Color dieDetailColor = Color.clear;

	// Use this for initialization
	void Start () 
	{
		me = gameObject;
		setDieColor ();
	}


	void setDieColor()
	{
		if(dieColor != Color.clear)
		{
			me.GetComponent<Renderer>().material.color = dieColor;
		}
		else
		{
			me.GetComponent <Renderer> ().material.color = Color.red;
		}


		if(dieDetailColor != Color.clear)
		{
			for(int i = 0;i<me.transform.childCount;i++)
			{
				for(int j=0;j<me.transform.GetChild (i).childCount;j++)
				{
					GameObject thisObject = me.transform.GetChild (i).GetChild (j).gameObject;
					thisObject.GetComponent<Renderer>().material.color = dieDetailColor;
				}
			}
		}
		else
		{
			for(int i = 0;i<me.transform.childCount;i++)
			{
				for (int j = 0; j < me.transform.GetChild (i).childCount; j++) 
				{
					GameObject thisObject = me.transform.GetChild (i).GetChild (j).gameObject;
					thisObject.GetComponent<Renderer>().material.color = dieDetailColor;
				}
			}
		}


	}

}

