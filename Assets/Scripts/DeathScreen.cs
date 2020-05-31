using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
	public static event Action OnQuit;


    public void Quit()
    {
		OnQuit?.Invoke();
		OnQuit = null;
		Time.timeScale = 1;
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

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			Quit();
		}
	}
}
