using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button StartButton;
    public Button ExitButton;


	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        StartButton = StartButton.GetComponent<Button>();
        ExitButton = ExitButton.GetComponent<Button>();
        quitMenu.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        StartButton.enabled = false;
        ExitButton.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        StartButton.enabled = true;
        ExitButton.enabled = true;
            }
    public void StartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
