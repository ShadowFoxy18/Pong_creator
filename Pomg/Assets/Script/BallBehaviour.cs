using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    float speedBall = 2.5f;
    [SerializeField]
    float maxSpeed = 10f;
    float _speedBall;

    [SerializeField]
    float increment = 1.5f;

    [SerializeField]
    Vector3 direction = Vector3.zero;
    Vector3 move;

    Vector3 ballOrigen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballOrigen = transform.position;

        _speedBall = speedBall;
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * Time.deltaTime * speedBall;

        if (Input.GetKey(KeyCode.R))
        {
            ResetBall();
        }

        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }


    void ResetBall()
    {
        speedBall = _speedBall;
        transform.position = Vector3.zero;

        do
        {
            if (direction.x == 0)
                direction.x = Random.Range(-1, 2);
        } while (direction.x == 0);


        do
        {
            if (direction.y == 0)
                direction.y = Random.Range(-1, 2);
        } while (direction.y == 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name.ToString() + " is collision on " + collision.gameObject.name.ToString());

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYEEEER");

            direction.x *= -1;
            speedBall *= increment;

        } else if (collision.gameObject.CompareTag("Border"))
        {
            Debug.Log("BORDEEER");

            direction.y *= -1;
            speedBall *= increment;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalZone1"))
        {
            ResetBall();
        } else if (other.gameObject.CompareTag("GoalZone2"))
        {
            ResetBall();
        }

    }
}
