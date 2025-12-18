using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("Speed Player")]
    // --- Speed Player ---
    [SerializeField]
    float speedPlayer = 2.5f;

    [Header("KeyCode to move")]
    // --- KeyCode ---
    [SerializeField]
    KeyCode CodeUp = KeyCode.W;
    [SerializeField]
    KeyCode CodeDown = KeyCode.S;

    // Start
    void Start() {}

    // Update
    void Update()
    {
        if (Input.GetKey(CodeUp))
        {
            transform.position += Vector3.up * speedPlayer * Time.deltaTime;
        }
        if (Input.GetKey(CodeDown))
        {
            transform.position += Vector3.down * speedPlayer * Time.deltaTime;
        }
    }

}
