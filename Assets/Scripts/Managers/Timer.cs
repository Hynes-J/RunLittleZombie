using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private TMP_Text ScoreText;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameRunning)
        {
            timer += Time.deltaTime;

            if (timer > 1f)
            {

                GameManager.Instance.score += 1;

                timer = 0;
                GameManager.Instance.IncreaseGameSpeed();
            }

            ScoreText.text = "Score: " + GameManager.Instance.score.ToString();

        }

    }

}
