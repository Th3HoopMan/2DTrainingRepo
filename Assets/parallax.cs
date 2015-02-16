using UnityEngine;
using System.Collections;

public class parallax : MonoBehaviour {
	
	public Transform[] backgrounds; //Array of all the back- and foregrounds to be parallaxed
	private float[] parallaxScales; //proportion of the camera's movement to move the backgrnds by
	public float smoothing = 1f;    //How smooth the parallaxing will be
	
	private Transform cam;			//reference to the main cameras transform
	private Vector3 previousCamPos;  //the position of the camera in previous frame
	
	//Is called before Start(). Great for references.
	void Awake () {
		// set up the reference
		cam = Camera.main.transform;
	}
	
	
	// Use this for initialization
	void Start () {
		//The previous frame had the current frame's camera position
		previousCamPos = cam.position;
		
		// assigning corresponding parallax scales
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z *-1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//for each background
		for (int i = 0; i<backgrounds.Length; i++) {
			//the parallax is the opposite of the camera movement because the previous fram multiplied by the scale
			float parallax = (previousCamPos.x-cam.position.x) * parallaxScales[i];
			
			//set a target x pos which is the current pos plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			
			//Create a target pos whihc is the backgrounds cur pos with it's targ x pos
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			
			// fade between cur pos and target pos using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		
		//set the prev camPos to the camera's pos at the end of the fram
		previousCamPos = cam.position;
	}
}
