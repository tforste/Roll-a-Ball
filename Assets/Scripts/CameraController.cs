using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate gaurentees that everything in Update has run. By
    // Performing the camera move in LateUpdate, we know for sure the player
    // have been moved for that frame.
	void LateUpdate () {
	    transform.position = player.transform.position + offset;
    }

}
