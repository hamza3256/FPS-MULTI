using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurePickup : MonoBehaviour
{
    float speed = 50.0f;

    public float transitionTime = 2.0f;

    public Animator transition;

    public void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Destroy the cure object
            Destroy(gameObject);

            // Load the victory scene then go back to the main menu
            SceneManager.LoadScene(3);
        }
    }

    public void EndGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Do a transition...
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        
    }
}
