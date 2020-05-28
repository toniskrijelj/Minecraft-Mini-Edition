using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public static DeathScreen Instance { get; private set; }
    Canvas canvas;
    public void SetActive(bool active)
    {
        canvas.enabled = active;
    }
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        Instance = this;
        canvas.enabled = false;
    }
}
