using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float time;

    public float gameSpeed = 0f;
    public float maxGameSpeed = 100f;

    public float gameIncrementSpeed = 0f;

    public bool gameRunning = true;

    public CinemachineVirtualCamera vcam;

    private int originalCullingMask;

    public LayerMask cameraCullLayerMask;

    public Camera mainCam;

    public float score;

    public AudioSource audioData;

    public AudioClip footStepClip;


    private void Awake()
    {
        originalCullingMask = mainCam.cullingMask;
        audioData = GetComponent<AudioSource>();

        ResetGame();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetGame()
    {
        time = 0f;
        gameSpeed = 0f;
        mainCam.cullingMask = originalCullingMask;

    }

    public void IncreaseGameSpeed()
    {
        if (gameSpeed < maxGameSpeed)
        {
            gameSpeed += gameIncrementSpeed;

        }
    }

    private void Update()
    {
        if (gameRunning)
        {
            time += Time.deltaTime;
        }
    }

    public void EndGame()
    {
        gameRunning = false;
        vcam.Priority = 11;
        mainCam.cullingMask = ~cameraCullLayerMask;

        Invoke("Restart", 2);

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
