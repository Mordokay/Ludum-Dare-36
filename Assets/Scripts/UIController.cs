using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject levelsMenu;
    public GameObject levelsPage2Menu;

    public GameObject[] allLevels;

    void Start()
    {
        levelsMenu.SetActive(false);
        levelsPage2Menu.SetActive(false);
        mainMenu.SetActive(true);

        
        PlayerPrefs.SetInt("Level1", 1);

        for (int i = 1; i <= allLevels.Length; i++)
        {

            if(PlayerPrefs.GetInt("Level" + i.ToString()) == 0 ){
                allLevels[i - 1].GetComponent<Button>().interactable = false;
            }
            else{
                allLevels[i - 1].GetComponent<Button>().interactable = true;
            }
        }
        
    }

    public void resetAllLevels (){
        for (int i = 1; i <= allLevels.Length; i++){
            PlayerPrefs.SetInt("Level" + i.ToString(), 0);
            allLevels[i - 1].GetComponent<Button>().interactable = false;
        }
        PlayerPrefs.SetInt("Level1", 1);
        allLevels[0].GetComponent<Button>().interactable = true;
    }

    public void unlockAllLevels()
    {
        for (int i = 1; i <= allLevels.Length; i++)
        {
            PlayerPrefs.SetInt("Level" + i.ToString(), 1);
            allLevels[i - 1].GetComponent<Button>().interactable = true;
        }
    }

    public void backToMenu()
    {
        levelsMenu.SetActive(false);
        levelsPage2Menu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void selectLevel(int i)
    {
        PlayerPrefs.SetInt("levelToLoad", i);
        SceneManager.LoadScene(1);
    }

    public void goToLevel()
    {
        levelsMenu.SetActive(true);
        mainMenu.SetActive(false);
        levelsPage2Menu.SetActive(false);
    }

    public void goToPage2Level()
    {
        levelsMenu.SetActive(false);
        mainMenu.SetActive(false);
        levelsPage2Menu.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }
}
