using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // Goal on player
    [SerializeField]
    int playerOneGoal = 0, playerTwoGoal = 0;

    [SerializeField]
    TextMeshProUGUI textPoints;


    public static ScoreManager instance;

    private void Awake()
    {
        if(ScoreManager.instance == null)
        {
            ScoreManager.instance = this;
        } else
        {
            Destroy(this);
        }
    }


    // --------------------------- Add Point on each Player --------------------------------- //
    public void GoalPlayerOne()
    {
        playerOneGoal++;
        UpdateGoalText();
    }
    
    public void GoalPlayerTwo()
    {
        playerTwoGoal++;
        UpdateGoalText();
    }

    void UpdateGoalText()
    {
        textPoints.text = playerOneGoal.ToString("00") + " || " + playerTwoGoal.ToString("00");
    }
 
}
