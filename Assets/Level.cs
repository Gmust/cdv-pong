using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public Button startButton;
    public Ball ball;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ball.BallMovement();
            startButton.gameObject.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (ball.goal == true)
        {
            startButton.gameObject.SetActive(true);
            ball.goal = false;
        }
    }
}
