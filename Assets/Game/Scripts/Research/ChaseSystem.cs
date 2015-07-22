using UnityEngine;
using System.Collections;
using System;

public class ChaseSystem : MonoBehaviour {

	[SerializeField] NavMeshAgent monster;
	[SerializeField] Transform characterTransform;
//	Ray ray;

	// Use this for initialization
	void Start () {
		monster.SetDestination (characterTransform.position);
		//Transform hit = 
		//ray = monster.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		RaycastHit hit;

		Vector3 startPos = monster.transform.position;
//		Debug.DrawLine(startPos, characterTransform.position, Color.red);
		//ray = startPos;

//		if(Physics.Raycast(startPos, characterTransform.position, out hit, 5f, LayerMask.GetMask("Hero")))
//		{
//			//Debug.DrawRay(startPos, characterTransform.position, Color.red);
//			monster.SetDestination (characterTransform.position);
//		}
		//Physics.SphereCast (startPos, 3f);
//		if (Physics.SphereCast(startPos, monster.GetComponent<CapsuleCollider>().height*3, characterTransform.transform.position, out hit, monster.GetComponent<CapsuleCollider>().height))
//		{
//			//Color colorOfLine = hit. ? Color.green : Color.red;
//
//			//monster.SetDestination (characterTransform.position);
//			if (hit.collider.tag == "Player")
//			{
//				Debug.Log("detection");
//			}
//		}
	}

	private void Sample()
	{
		//Physics.
	}
}
