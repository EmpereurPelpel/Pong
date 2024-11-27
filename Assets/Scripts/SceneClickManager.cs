using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GoTo1PScene()
    {
        SceneManager.LoadScene("1PScene");
    }

    public void GoTo2PScene()
    {
        SceneManager.LoadScene("2PScene");
    }
}
