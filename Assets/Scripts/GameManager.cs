using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //check if scene is tile screen
       if(SceneManager.GetActiveScene().name == "Title Screen")
        {

            //Press enter start game
            if (Input.GetKeyUp(KeyCode.Return))
            {
                SceneManager.LoadScene("Level");
            }
            //Press escape to exit game
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("Quitting");
            }


        }
       //do nothing for level
       else if(SceneManager.GetActiveScene().name == "Level")
        {

        }
       //else take back to title screen
        else
        {
            //Press enter to go back
            if (Input.GetKeyUp(KeyCode.Return))
            {
                SceneManager.LoadScene("Title Screen");
            }

        }



    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    
}
