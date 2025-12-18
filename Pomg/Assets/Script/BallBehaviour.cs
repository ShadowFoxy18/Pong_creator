using TMPro;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // ---------------------------------------- Values ------------------------------------ // 
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


    // ---------------------------------------- Game & Update ------------------------------------ //

    // Start
    void Start()
    {
        ballOrigen = transform.position;

        _speedBall = speedBall;
        ResetBall();
    }


    // Update
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

    // -------------------------------------------------------------------------------------------- //

    /// <summary>
    /// Resetea la bola y randomiza la posicion de salida
    /// </summary>
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

    bool SpeedComprobation(float speedActual)
    {
        bool speedComprobation = false;

        if (speedActual < maxSpeed)
        {
            speedComprobation = true;
        }

        return speedComprobation;
    }


    // -------------------------------------- Colission & Trigger ------------------------------------ //

    /// <summary>
    /// Dectect colission on player & border
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        float _increment = increment;
        
        //Debug.Log(this.name.ToString() + " is collision on " + collision.gameObject.name.ToString());

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYEEEER");

            direction.x *= -1;
            

        } else if (collision.gameObject.CompareTag("Border"))
        {
            Debug.Log("BORDEEER");

            direction.y *= -1;
        }
        

        if (SpeedComprobation(speedBall))
        {
            speedBall *= _increment;
        }
        
    }


    /// <summary>
    /// Detect trigger zone goal
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalZone1"))
        {
            ScoreManager.instance.GoalPlayerTwo();
        } else if (other.gameObject.CompareTag("GoalZone2"))
        {
            ScoreManager.instance.GoalPlayerOne();
        }
        ResetBall();
    }

    // ---------------------------------------------------------------------------------------------- //
}
