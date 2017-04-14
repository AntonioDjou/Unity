using UnityEngine;
using System.Collections;

public class BlinkCorScript : MonoBehaviour {
	public float veloc = 0.1f;
	Material materialGO;
	Color[] cores = {Color.yellow, Color.red};
	float tempo = 1f;

	void Start () {
		materialGO = GetComponent<Renderer>().material;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag.Equals("Inimigo")){
			StartCoroutine(Blink(tempo, veloc));
		}
	}

	IEnumerator Blink(float temp, float vel){
		float elipseTime = 0f;
		int index = 0;
		while ( elipseTime < temp ){
			materialGO.color = cores[index % 2];
			elipseTime += Time.deltaTime;
			index++;
			yield return new WaitForSeconds(vel);
		}
		materialGO.color = Color.white;
	}
}
