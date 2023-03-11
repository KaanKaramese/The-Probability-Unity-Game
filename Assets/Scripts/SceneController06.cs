using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController06 : MonoBehaviour
{
    public GameObject textBox;
    public GameObject gameOverMenu;
    public TextMeshProUGUI speechTxt;

    //Metin kutucuðundaki ileri butonuna basýnca bir sonraki metne geçer
    public void SkipText()
    {
        if (speechTxt.text == "We owe you big time, Mr. Davis! If it weren't for you, we wouldn't be able to solve this case.")
        {
            speechTxt.text = "Maybe you would like to know, when we investigated bank account transactions of Rick, we found out that Miller Jr. had paid a whole lot of money for him to murder Sarah, the wife of Miller Jr's brother.";
        }
        else if (speechTxt.text == "Maybe you would like to know, when we investigated bank account transactions of Rick, we found out that Miller Jr. had paid a whole lot of money for him to murder Sarah, the wife of Miller Jr's brother.")
        {
            speechTxt.text = "Man, I will definitely get a promotion for participating in a huge criminal case like this.";
        }
        else
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
