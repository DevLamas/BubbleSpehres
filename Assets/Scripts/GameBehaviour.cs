using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameBehaviour : MonoBehaviour
{

    private int ViePlayer = 3;
    public bool showWinScreen = false;
    public bool showLooseSreen = false;
    public string labelResultat = "";

    public void Finish()
    {

        showWinScreen = true;
        Time.timeScale = 0f;

        Debug.Log("test");

    }
    public int HP
    {
        get { return ViePlayer; }
        set
        {
            ViePlayer = value;

            if (ViePlayer <= 0)
            {
                labelResultat = "☠GAME OVER☠";
                showLooseSreen = true;
                Time.timeScale = 0;

            }

            Debug.LogFormat("vie : {0}", ViePlayer);

        }

    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Santé du joueurs:" + ViePlayer);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelResultat);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Vous avez gagné !"))
            {

                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;

            }
        }
        if (showLooseSreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), labelResultat))
            {

                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;


            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
