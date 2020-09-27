using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] float timeToWait = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreen());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);   
    }

    IEnumerator LoadStartScreen()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadOptionScreen()
    {
        SceneManager.LoadScene("Option Screen");
    }

    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");      
    }

    public void Quit()
    {
        Application.Quit();
    }
}
