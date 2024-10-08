using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveScript : MonoBehaviour
{

	LineRenderer lineRenderer;

	public Transform[] Points;

	[SerializeField] private Transform pointA;
	[SerializeField] private Transform pointB;
	[SerializeField] private Transform pointC;
	[SerializeField] private Transform pointD;
	//[SerializeField] private Transform pointAB;
	//[SerializeField] private Transform pointBC;
	//[SerializeField] private Transform pointCD;
	//[SerializeField] private Transform pointAB_BC;
	//[SerializeField] private Transform pointBC_CD;
	[SerializeField] private Transform pointABCD;
	private float interpolateAmount;
	private void Awake( )
	{
		AssignLine();
	}
	private void Update( )
	{
		interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;

		/*
		pointAB.position = Vector3.Lerp( pointA.position, pointB.position, interpolateAmount );
		pointBC.position = Vector3.Lerp( pointB.position, pointC.position, interpolateAmount );
		pointCD.position = Vector3.Lerp( pointC.position, pointD.position, interpolateAmount );

		pointAB_BC.position = Vector3.Lerp( pointAB.position, pointBC.position, interpolateAmount );
		pointBC_CD.position = Vector3.Lerp( pointBC.position, pointCD.position, interpolateAmount );

		pointABCD.position = Vector3.Lerp( pointAB_BC.position, pointBC_CD.position, interpolateAmount );

		*/
		pointABCD.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);

	}

	private Vector3 QuadracticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
	{
		Vector3 ab = Vector3.Lerp(a,b,t);
		Vector3 bc = Vector3.Lerp(b,c,t);

		return Vector3.Lerp(ab,bc,interpolateAmount);
	}

	private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t) { 
		Vector3 ab_bc = QuadracticLerp(a,b, c, t);
		Vector3 bc_cd = QuadracticLerp(b,c, d, t);
		return Vector3.Lerp(ab_bc,bc_cd,interpolateAmount);

	}

	private void AssignLine( )
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = Points.Length;
		for(int i = 0; i < Points.Length; i++)
		{
			lineRenderer.SetPosition(i, Points[i].position);
		}
	}
}
