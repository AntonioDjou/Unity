using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float veloc = 25f;
    float velocRot = 270f;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    Vector3 movement;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
    }

    void Move(float h, float v)
    {
        float desloc = Mathf.Clamp(v, 0f, 1f) * veloc * Time.deltaTime;
        float deslocV = h * velocRot * Time.deltaTime;
        transform.Translate(0, 0, desloc);
        transform.Rotate(0, deslocV, 0);
    }

}
