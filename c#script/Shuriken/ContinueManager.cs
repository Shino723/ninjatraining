using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManager : MonoBehaviour
{
    public void ContinueGame()
    {
        SceneManager.LoadScene("Start_S");
    }
}
