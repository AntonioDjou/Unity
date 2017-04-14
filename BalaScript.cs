using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {

	float veloc = 5;

	void Update () {
		transform.Translate(0, veloc * Time.deltaTime, 0);	
	}
		
	void OnTriggerEnter2D(Collider2D col){
		// Destroys the bullet when it collides with the asteroid
		if (col.tag.Equals("Inimigo")){
			Destroy(gameObject);
		}
	}

	void OnBecameInvisible(){
		// Destroys the bullet wehn leave the screen
		Destroy(gameObject);
	}
}
