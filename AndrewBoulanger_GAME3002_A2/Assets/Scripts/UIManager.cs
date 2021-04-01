using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text livesText = null;
    [SerializeField]
    private Text livesDisplay = null;

    private int score;

    [SerializeField] private Canvas GameOverHud = null;

    // Start is called before the first frame update
    void Start()
    {
        BallBehaviour.OnRespawn = UpdateLives;
        Collidable.CollectPointsDelegate = UpdateScore;
    }


    void UpdateScore(int val)
    {
        score += val;
        scoreText.text = score.ToString();
    }

    void UpdateLives(int lives)
    {
        switch (lives)
        {
            case 1:
                livesText.color = Color.red;
                livesDisplay.color = Color.red;
                break;
            case 2:
                livesText.color = Color.yellow;
                livesDisplay.color = Color.yellow;
                break;
            case 3:
                livesText.color = Color.green;
                livesDisplay.color = Color.green;
                break;
            case 0:
                GameOverHud.gameObject.SetActive(true);
                break;
            default:
                break;
        }

        string ballIcon = "";
        for (int i = 0; i < lives; i++)
        {
            ballIcon = ballIcon + "o ";
        }

        livesDisplay.text = ballIcon;
    }

}
