using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody playerRigidbody;
	public float moveSpeed = 700f;
	public GameObject CubeSolidRed1;
    public GameObject CubeSolidRed2;
    public GameObject CubeSolidBlue1;
    public GameObject CubeSolidBlue2;
	public GameObject player;
	public float distance = 100f;

	public bool MoveRight ;
	public bool  CanMoveRight;

	public bool MoveLeft;
	public bool  CanMoveLeft;	

	public bool MoveDown;
	public bool  CanMoveDown;

	public bool MoveUp;
	public bool  CanMoveUp;

//	public Color mycolor;

    RaycastHit LeftHit , RightHit , UpHit , DownHit;
    public enum MoveingState { left , right , up , down , stop};
    public MoveingState state;
    
    void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Goal")
		{
            GetComponent<PlayerMovement>().enabled = false;
			//print("End");
			//gameObject.GetComponent<Renderer> ().material.color = mycolor;
			
		}

		// if (col.gameObject.tag == "RightWall")
		// {
		// 	print("right wall");
		// 	CanMoveRight = false;
		// 	MoveRight = false;
		// }



		if (col.gameObject.tag == "RedCube")
		{
			print("CollisionRed...");
			CubeSolidRed1.GetComponent<BoxCollider>().enabled = false;
            CubeSolidRed2.GetComponent<BoxCollider>().enabled = false;
		}

        if (col.gameObject.tag == "BlueCube")
		{
			print("CollisionBlue...");
			CubeSolidBlue1.GetComponent<BoxCollider>().enabled = false;
            CubeSolidBlue2.GetComponent<BoxCollider>().enabled = false;
            
		}
	}

	void Start () 
	{
		playerRigidbody = GetComponent<Rigidbody>();
		CanMoveRight = true;
		CanMoveLeft = true;
		CanMoveDown = true;
		CanMoveUp = true;
        state = MoveingState.stop;

	}

	void Update()
	{
        /*RaycastHit LeftHit;
		if(Physics.Raycast(player.transform.position , Vector3.left , out LeftHit , distance))
		{
			//Debug.Log(hit.transform.name);
			if(LeftHit.transform.tag == "LeftWall" && LeftHit.distance<.5f ){
				print("LeftWall");
				CanMoveLeft = false;
				MoveLeft = false;
			}
		}*/

        CheckRaycast();

		if(MobileInput.Instance.SwipeLeft)
		{
			MoveLeft = true;
			CanMoveRight = true;
			MoveRight = false;
		}

		if(MobileInput.Instance.SwipeRight)
		{
			MoveRight = true;
			CanMoveLeft = true;
			CanMoveDown = true;
			//CanMoveUp = false;
			MoveLeft = false;
			MoveDown = false;

		}
		if(MobileInput.Instance.SwipeUp)
		{
			MoveUp = true;
			CanMoveRight = true;
			MoveRight = false;
			CanMoveLeft = true;
			MoveLeft = false;
			CanMoveDown = true;
			MoveDown = false;
		}
		
		if(MobileInput.Instance.SwipeDown)
		{
			MoveDown = true;
			CanMoveRight = true;
			MoveRight = false;
			CanMoveLeft = true;
			MoveLeft = false;
			MoveUp = false;
		}
	}

	 void FixedUpdate () 
	{
        #region PressKey
        if (state == MoveingState.stop)
        {
            //Right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //if (!MoveRight )
                if(CanMoveRight)
                {
                    MoveRight = true;

                }

            }


            //Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //if (!MoveLeft)
                if(CanMoveLeft)
                {
                    MoveLeft = true;

                }

            }
            

            //Down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //if (!MoveDown)
                if(CanMoveDown)
                {
                    MoveDown = true;        
                }

            }
            

            //Up
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //if (!MoveUp)
                if(CanMoveUp)
                {
                    MoveUp = true;
                    /*CanMoveRight = true;
                    MoveRight = false;
                    CanMoveLeft = true;
                    MoveLeft = false;
                    CanMoveDown = true;
                    MoveDown = false;*/

                }

            }
            
        }
        #endregion PressKey

        if (MoveRight)
        {
            RightMove();
        }
        else if (MoveUp)
        {
            UpMove();
        }
        else if (MoveDown)
        {
            DownMove();
        }
        else if (MoveLeft)
        {
            LeftMove();
        }else
        {
            state = MoveingState.stop;
        }



    }

	void RightMove()
	{
		if(CanMoveRight == true)
		{
            state = MoveingState.right;
			playerRigidbody.transform.Translate(new Vector3(1,0,0) * moveSpeed* Time.deltaTime);
		}
	}


	void LeftMove()
	{
		if(CanMoveLeft == true)
		{
            state = MoveingState.left;
			playerRigidbody.transform.Translate(new Vector3(-1,0,0) * moveSpeed* Time.deltaTime);
		}
	}


	void DownMove()
	{
		if(CanMoveDown == true)
		{
            state = MoveingState.down;
			playerRigidbody.transform.Translate(new Vector3(0,0,-1) * moveSpeed* Time.deltaTime);
		}
	}

	void UpMove()
	{
		if(CanMoveUp == true)
		{
            state = MoveingState.up;
			playerRigidbody.transform.Translate(new Vector3(0,0,1) * moveSpeed* Time.deltaTime);
		}
	}

    public void CheckRaycast()
    {
        
        if (Physics.Raycast(player.transform.position, Vector3.left, out LeftHit, distance))
        {
            //Debug.Log(hit.transform.name);
            if (LeftHit.transform.tag == "LeftWall" && LeftHit.distance < 2f)
            {
                print("LeftWall");
                CanMoveLeft = false;
                MoveLeft = false;
                

            }else
            {
                CanMoveLeft = true;
            }
        }

        if (Physics.Raycast(player.transform.position, Vector3.right, out RightHit, distance))
        {
            //Debug.Log(hit.transform.name);
            if (RightHit.transform.tag == "RightWall" && RightHit.distance < 4f)
            {
                print("rightWall");
                CanMoveRight = false;
                MoveRight = false;


            }
            else
            {
                CanMoveRight = true;
            }
        }

        if (Physics.Raycast(player.transform.position, Vector3.forward, out UpHit, distance))
        {
            //Debug.Log(hit.transform.name);
            if (UpHit.transform.tag == "UpWall" && UpHit.distance < .8f)
            {
                print("UpWall");
                CanMoveUp = false;
                MoveUp = false;
                

            }
            else
            {
                CanMoveUp = true;
            }
        }
        if (Physics.Raycast(player.transform.position, Vector3.back, out DownHit, distance))
        {
            //Debug.Log(hit.transform.name);
            if (DownHit.transform.tag == "DownWall" && DownHit.distance < 2f)
            {
                print("DownWall");
                CanMoveDown = false;
                MoveDown = false;
                
            }
            else
            {
                CanMoveDown = true;
            }
        }

    //  if (Physics.Raycast(player.transform.position, Vector3.forward, out UpHit, distance))
    //     {
    //         if (UpHit.transform.tag == "CubeSolid" && UpHit.distance < .8f)
    //         {
    //             print("CubeSolid");
    //             CanMoveUp = false;
    //             MoveUp = false;
                
    //         }
    //         else
    //         {
    //             CanMoveUp = true;
    //         }
    //     }

        // if (Physics.Raycast(player.transform.position, Vector3.right, out RightHit, distance))
        // {
        //     //Debug.Log(hit.transform.name);
        //     if (RightHit.transform.tag == "CubeSolid" && RightHit.distance < 4f)
        //     {
        //         print("CubeSolid");
        //         CanMoveRight = false;
        //         MoveRight = false;
                

        //     }
        //     else
        //     {
        //         CanMoveRight = true;
        //     }
        // }
         
        // if (Physics.Raycast(player.transform.position, Vector3.left, out LeftHit, distance))
        // {
        //     //Debug.Log(hit.transform.name);
        //     if (LeftHit.transform.tag == "CubeSolidBlue" && LeftHit.distance < 2f)
        //     {
        //         print("CubeSolidBlue");
        //         CanMoveLeft = false;
        //         MoveLeft = false;
                

        //     }else
        //     {
        //         CanMoveLeft = true;
        //     }
        // }
}
}
