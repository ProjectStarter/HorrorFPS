using UnityEngine;
using System.Collections;

public class MecanimController : MonoBehaviour {

	[SerializeField] Animator anim;
	[SerializeField] float duration;

	private const float DURATION = 30f;

	private const string IDLE_STRING = "idle";
	private const string WALK_STRING = "walk";
	private const string IS_RUNNING_STRING = "isRunning";
	private const string IS_WALKING_FORWARD_STRING = "isWalkingForward";
	private const string IS_WALKING_BACKWARD_STRING = "isWalkingBackward";
	private const string IS_STRAFE_RIGHT_NORMAL_STRING = "isStrafeRight";
	private const string IS_STRAFE_LEFT_NORMAL_STRING = "isStrafeLeft";
	private const string IS_DIAGONAL_STRING = "isDiagonal";

	private const int WALK_BACKWARD = -1;
	private const int IDLE = 0;
	private const int WALK_FORWARD = 1;
	private const int RUN_FORWARD = 2;

	private bool isActivated = true;
	// Use this for initialization
	void Start () {
		duration = DURATION;
	}
	
	// Update is called once per frame
	void Update () {
		//NOTE: SET MECANIM PARAMETERS FIRST FIRST
#region RUNNING
		if ( Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
		{
			anim.SetBool(IS_RUNNING_STRING, true);
		}
		
		if ( Input.GetKeyUp(KeyCode.LeftShift))
		{
			anim.SetBool(IS_RUNNING_STRING, false);
		}
#endregion

#region DIAGONAL
		if ((Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) ||
		    (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) ||
		    (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) ||
		    (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) )
		{
			anim.SetBool(IS_DIAGONAL_STRING, true);
		}

		else
		{
			anim.SetBool(IS_DIAGONAL_STRING, false);
		}
#endregion

#region WALK_FORWARD
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool(IS_WALKING_FORWARD_STRING, true);
		}
		
		if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool(IS_WALKING_FORWARD_STRING, false);
			
			//force set isRunning to false
			anim.SetBool(IS_RUNNING_STRING, false);
		}
#endregion

#region WALK_BACKWARD
		if (Input.GetKey(KeyCode.S))
		{
			anim.SetBool(IS_WALKING_BACKWARD_STRING, true);
		}

		if (Input.GetKeyUp(KeyCode.S))
		{
			anim.SetBool(IS_WALKING_BACKWARD_STRING, false);
		}
#endregion

#region WALK_LEFT
		if (Input.GetKey(KeyCode.A))
		{
			anim.SetBool(IS_STRAFE_LEFT_NORMAL_STRING, true);
		}
		
		if (Input.GetKeyUp(KeyCode.A))
		{
			anim.SetBool(IS_STRAFE_LEFT_NORMAL_STRING, false);
			
			//force set isRunning to false
			anim.SetBool(IS_RUNNING_STRING, false);
		}
#endregion

#region WALK_RIGHT
		if (Input.GetKey(KeyCode.D))
		{
			anim.SetBool(IS_STRAFE_RIGHT_NORMAL_STRING, true);
		}
		
		if (Input.GetKeyUp(KeyCode.D))
		{
			anim.SetBool(IS_STRAFE_RIGHT_NORMAL_STRING, false);
			
			//force set isRunning to false
			anim.SetBool(IS_RUNNING_STRING, false);
		}
#endregion

#region SPECIAL_CONDITIONS_FOR_LEFT_RIGHT_FORWARD_BACKWARD
		if (anim.GetBool(IS_WALKING_FORWARD_STRING) && anim.GetBool(IS_WALKING_BACKWARD_STRING))
		{
			anim.SetBool(IS_WALKING_FORWARD_STRING, false);
			anim.SetBool(IS_WALKING_BACKWARD_STRING, false);

			//ForceIdle();
		}

		if (anim.GetBool(IS_STRAFE_LEFT_NORMAL_STRING) && anim.GetBool(IS_STRAFE_RIGHT_NORMAL_STRING))
		{
			anim.SetBool (IS_STRAFE_LEFT_NORMAL_STRING, false);
			anim.SetBool (IS_STRAFE_RIGHT_NORMAL_STRING, false);

			//ForceIdle();
		}

#endregion

		if (anim.GetBool(IS_WALKING_FORWARD_STRING) && 
		    !anim.GetBool(IS_RUNNING_STRING) 		&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			//Debug.LogError("WALKING");
			anim.SetInteger(WALK_STRING, WALK_FORWARD);
		}
		
		if (anim.GetBool(IS_WALKING_FORWARD_STRING) && 
		    anim.GetBool(IS_RUNNING_STRING)			&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			//Debug.LogError("RUNNING");
			anim.SetInteger(WALK_STRING, RUN_FORWARD);
		}

		if (anim.GetBool(IS_STRAFE_LEFT_NORMAL_STRING) 	&& 
		    !anim.GetBool(IS_RUNNING_STRING)			&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			anim.SetInteger(WALK_STRING, WALK_FORWARD);
		}

		if (anim.GetBool(IS_STRAFE_LEFT_NORMAL_STRING) 	&& 
		    anim.GetBool(IS_RUNNING_STRING)				&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			anim.SetInteger(WALK_STRING, RUN_FORWARD);
		}

		if (anim.GetBool(IS_STRAFE_RIGHT_NORMAL_STRING) && 
		    !anim.GetBool(IS_RUNNING_STRING)			&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			anim.SetInteger(WALK_STRING, WALK_FORWARD);
		}

		if (anim.GetBool(IS_STRAFE_RIGHT_NORMAL_STRING) && 
		    anim.GetBool(IS_RUNNING_STRING)				&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			anim.SetInteger(WALK_STRING, RUN_FORWARD);
		}

		if (anim.GetBool(IS_WALKING_BACKWARD_STRING)	&&
		    !anim.GetBool(IS_DIAGONAL_STRING))
		{
			//Debug.LogError("WALK BACKWARD");
			anim.SetInteger(WALK_STRING, WALK_BACKWARD);
		}

		if(anim.GetBool(IS_DIAGONAL_STRING) && anim.GetBool(IS_WALKING_FORWARD_STRING))
		{
			if(anim.GetBool(IS_RUNNING_STRING))
			{

			}

			else
			{
				if (anim.GetBool(IS_STRAFE_LEFT_NORMAL_STRING))
				{
					//anim.SetInteger(STRAFE_STRING, STRAFE_LEFT);
					anim.SetLayerWeight(2, 0.0f);
					anim.SetLayerWeight(1, 1.0f);
				}
				
				else if (anim.GetBool(IS_STRAFE_RIGHT_NORMAL_STRING))
				{
					//anim.SetInteger(STRAFE_STRING, STRAFE_RIGHT);
					anim.SetLayerWeight(1, 0.0f);
					anim.SetLayerWeight(2, 1.0f);
				}
			}



//			if(anim.GetInteger(STRAFE_STRING) != IDLE)
//			{
//				anim.SetLayerWeight(1, 1.0f);
//			}

		}

		if (!anim.GetBool(IS_DIAGONAL_STRING))
		{
			anim.SetLayerWeight(1, 0.0f);
			anim.SetLayerWeight(2, 0.0f);
		}

		if (!anim.GetBool(IS_WALKING_FORWARD_STRING) && 
		    !anim.GetBool(IS_WALKING_BACKWARD_STRING) && 
		    !anim.GetBool(IS_STRAFE_LEFT_NORMAL_STRING) && 
		    !anim.GetBool(IS_STRAFE_RIGHT_NORMAL_STRING))
		{
			//Debug.LogError("IDLE");
			anim.SetInteger(WALK_STRING, IDLE);
			if (isActivated)
			{
				isActivated = false;
				ForceIdle();
			}
		}
	}

	void FixedUpdate()
	{
		if(anim.GetInteger(WALK_STRING) != IDLE)
		{
			return;
		}

		duration -= Time.deltaTime;
		
		if (isActivated)
		{
			if (duration <= 0)
			{
				duration = DURATION;
				isActivated = false;
				
				float rand = RandomFloatGenerator();
				//Debug.Log("rand: " + rand);
				anim.SetFloat(IDLE_STRING, rand);
			}
		}
		
		else
		{
			if (duration <= 0)
			{
				duration = DURATION;
				isActivated = true;
				
			}
		}
	}

	private void ForceIdle()
	{
		float rand = RandomFloatGenerator ();
		duration = DURATION;
		anim.SetInteger(WALK_STRING, IDLE);
		anim.SetFloat (IDLE_STRING, rand);
	}

	private float RandomFloatGenerator()
	{
		int rand;

		rand = Random.Range (-1, 2);
		return rand;
	}
}
