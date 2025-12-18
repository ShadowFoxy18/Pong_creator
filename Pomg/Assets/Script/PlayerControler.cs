using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    float speedPlayer = 2.5f;

    Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.up * speedPlayer * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.down * speedPlayer * Time.deltaTime;
        }
    }

}
