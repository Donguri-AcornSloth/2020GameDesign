using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void Replaygame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
