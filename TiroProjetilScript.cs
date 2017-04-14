using UnityEngine;
using System.Collections;

public class TiroProjetilScript : MonoBehaviour {

	public float taxaTiro = 0.25f;									// Tempo em segs de controle do disparo
	public Transform ponta;											// Referência a ponteira da arma
	public GameObject bala;											// Referência ao prefab da bala

	private LineRenderer laser;
	private AudioSource tiroAudio;
	private Camera fpsCamera;										// Referência à câmera do FPS

	private WaitForSeconds duracao = new WaitForSeconds(0.07f);		// Determina o tempo do tiro
	private float proxTiro;											// Tempo que o jogador poderá atirar novamente

	private float alcance = 30f;
	private float velocidade = 30f;


	void Start () {
		tiroAudio = GetComponent<AudioSource>();
		fpsCamera = GetComponentInParent<Camera>();
		laser = GetComponent<LineRenderer>();
		laser.enabled = false;
	}

	void FixedUpdate () {
		Vector3 origem = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		laser.SetPosition(0, ponta.position);
		laser.SetPosition(1, origem + (fpsCamera.transform.forward * alcance));

		if (Input.GetKeyDown(KeyCode.L)){
			laser.enabled = !laser.enabled;
		}

		if (Input.GetButtonDown("Fire1") && Time.time > proxTiro) {
			proxTiro = Time.time + taxaTiro;

			GameObject novaBala = (GameObject) Instantiate(bala, 
															ponta.transform.position, 
															ponta.transform.rotation);
			novaBala.GetComponent<Rigidbody>().velocity = ponta.TransformDirection(
															Vector3.forward * velocidade);

			Destroy(novaBala, 2);
			StartCoroutine (ShotEffect());
		}
	}

	private IEnumerator ShotEffect() {
		tiroAudio.Play();
		yield return duracao;
	}
}
