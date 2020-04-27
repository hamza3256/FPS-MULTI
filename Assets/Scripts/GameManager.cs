using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("Game ended");
        Restart();
    }

    void Restart()
    {
        SceneManager.LoadScene(4);
    }
}
