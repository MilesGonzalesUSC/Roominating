using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalBegin : MonoBehaviour
{
	public void BeginTransition( )
	{
		GameObject AnimObj = GameObject.Find( "AnimationObject" );
		AnimObj.GetComponent<BeginningTransition>().Transition();
	}
}
