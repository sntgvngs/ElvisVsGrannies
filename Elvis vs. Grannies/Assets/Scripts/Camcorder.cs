using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Camcorder : MonoBehaviour {
    public GameObject elvis;
    Transform elvisT;
    ElvisScript elvisS;

    public GrannyDirector director;

    public Canvas menu;
    public Canvas end;
    public Text result;

    public bool isPaused;
    private Vector3 offset;

	void Start () {
        offset = new Vector3(0, 8, 9);
        isPaused = true;
        elvisT = elvis.GetComponent<Transform>();
        elvisS = elvis.GetComponent<ElvisScript>();
        end.enabled = false;
    }
	

	void Update () {
        transform.position = elvisT.position + offset;
        if(Input.GetButtonUp("Pause") && !end.enabled)
        {
            Pause();
        }
        if (Input.GetButtonUp("Quit"))
        {
            Quit();
        }
        if (Input.GetButtonUp("Restart"))
        {
            Debug.Log("Restart please");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;
        menu.enabled = !menu.enabled;
        elvisS.Pause();
        director.Pause();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Win()
    {
        Pause();
        menu.enabled = false;
        result.text = "You Win!";
        end.enabled = true;
    }

    public void Lose()
    {
        Pause();
        menu.enabled = false;
        result.text = "You Lose!";
        end.enabled = true;
    }
}
