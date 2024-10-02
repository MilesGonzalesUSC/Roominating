using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
	public int SceneNum;
	private GameObject Cam;
	[SerializeField] public Vector3 CamPos;

	public void Awake( )
	{
		Cam = FindObjectOfType<Camera>().gameObject;
		CamPos = Cam.transform.position;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		SceneController.instance.NextLevel(SceneNum, CamPos);
		Debug.Log( "Clicked" );

	}

	public void OnPointerUp(PointerEventData eventData)
	{
		
	}


}
