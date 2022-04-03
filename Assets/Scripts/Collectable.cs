using UnityEngine;

public class Collectable : MonoBehaviour
{


    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            GameManager.Instance.score += 1;
            DeleteObject();
        }
    }

    private void DeleteObject()
    {
        GameManager.Instance.audioData.Play();

        Destroy(gameObject);

    }
}
