using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    // Amount of seconds until we show the next character
    public float untilNextCharacter = 0.1f;

    // The complete text we want to show
    public string[] completeText;

    // what text is currently being shown
    private string currentText = "";

    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Show());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Show()
    {
        // Loop through the complete text and increment current text by each character
        for(int i=0; i<completeText.Length; i++)
        {
            for(int z=0; z<=completeText[i].Length; z++)
            {
                currentText = completeText[i].Substring(0, z);
                this.GetComponent<TextMeshProUGUI>().text = currentText;
                yield return new WaitForSeconds(untilNextCharacter);
            }
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(2);

        // Fade into game
        PlayGame();
    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Do a transition...
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
