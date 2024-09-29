using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
	Vector3 inputDir = new Vector3(0, 0, 0);
	[Header("Maximum Camera Bounds")]
	public float MaxX = 20f;
	public float MaxY = 20f;

	public bool CanMoveCam;

	public int edgeScrollSize = 20;

	public int ClickMoveSpeed = 3;

	private Transform ClickedTran;

	private void Awake( )
	{
		CanMoveCam = true;
		ClickedTran = null;
	}
	private void Update( )
	{
		MoveCamera();

		if(ClickedTran != null)
		{
		}
	}

	
	//Called by object that is clicked to load Scene and move camera to its position
	public void ObjectClick(Transform tran, Scene SceneToLoad)
	{
		CanMoveCam = false;
		ClickedTran = tran;
		Vector3 MoveVec = new Vector3( tran.position.x, tran.position.y, this.transform.position.z );
		this.transform.position = MoveVec;


	}


	//Controls Camera Movement
	public void MoveCamera( )
	{
		if(CanMoveCam)
		{

			if(Input.mousePosition.x < edgeScrollSize && transform.position.x >= -MaxX)
			{
				inputDir.x = -.25f;
			} else
			{
				inputDir.x = 0f;
			}
			if(Input.mousePosition.y < edgeScrollSize && transform.position.y >= -MaxY)
			{
				inputDir.y = -.25f;
			} else
			{
				inputDir.y = 0f;

			}
			if(Input.mousePosition.x > Screen.width - edgeScrollSize && transform.position.x <= MaxX)
			{
				inputDir.x = +.25f;
			}

			if(Input.mousePosition.y > Screen.height - edgeScrollSize && transform.position.y <= MaxY)
			{
				inputDir.y = +.25f;
			}
		}


		float moveSpeed = 10f;
		transform.position += inputDir * moveSpeed * Time.deltaTime;


	}
}
