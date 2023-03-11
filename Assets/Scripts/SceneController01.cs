using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController01 : MonoBehaviour
{
    public Button reportBtn;
    public Button evidenceBtn;
    public Button karakter1;
    public Button karakter2;
    public Button karakter3;
    public GameObject wrongAnswer;
    public GameObject evidencePopup;
    public GameObject evidence1;
    public GameObject evidence2;
    public GameObject report;
    public GameObject report2;
    public GameObject report3;
    public GameObject reportBtns;
    public GameObject report2Btns;
    public GameObject report3Btns;
    public GameObject textBox;
    public static string chosenCharacter;
    public static string selectedBtn2;
    public static string selectedBtn3;
    public TextMeshProUGUI speechTxt;
    private bool evidenceClicked1 = false;
    private bool evidenceClicked2 = false;
    Vector3 openReport = new Vector3(1, 1, 1);
    Vector3 closeReport = new Vector3(0, 0, 1);
    Color selectedColor = new Color(0.5f, 0.5f, 0.5f);
    Color unselectedColor = new Color(1.0f, 1.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        karakter1.interactable = false;
        karakter2.interactable = false;
        karakter3.interactable = false;
    }

    public void ChangeColor(Button clickedBtn)
    {
        foreach (Button btn in reportBtns.GetComponentsInChildren<Button>())
        {
            if (btn == clickedBtn)
            {
                btn.image.color = selectedColor;
            }
            else
            {
                btn.image.color = unselectedColor;
            }
        }
    }

    public void ChangeColor2(Button clickedBtn)
    {
        foreach (Button btn in report2Btns.GetComponentsInChildren<Button>())
        {
            if (btn == clickedBtn)
            {
                btn.image.color = selectedColor;
            }
            else
            {
                btn.image.color = unselectedColor;
            }
        }
        selectedBtn2 = clickedBtn.name;
    }

    public void ChangeColor3(Button clickedBtn)
    {
        foreach (Button btn in report3Btns.GetComponentsInChildren<Button>())
        {
            if (btn == clickedBtn)
            {
                btn.image.color = selectedColor;
            }
            else
            {
                btn.image.color = unselectedColor;
            }
        }
        selectedBtn3 = clickedBtn.name;
    }

    public void OpenReportButton()
    {
        reportBtn.interactable = false;
        evidenceBtn.interactable = false;
        report.transform.localScale = openReport;
        karakter1.interactable = false;
        karakter2.interactable = false;
        karakter3.interactable = false;
    }

    public void CloseReportButton()
    {
        report.transform.localScale = closeReport;
        report2.transform.localScale = closeReport;
        report3.transform.localScale = closeReport;
        reportBtn.interactable = true;
        evidenceBtn.interactable = true;
        if (evidenceClicked1 && evidenceClicked2)
        {
            karakter1.interactable = true;
            karakter2.interactable = true;
            karakter3.interactable = true;
        }
    }

    public void NextReportButton()
    {
        if (report.transform.localScale == openReport)
        {
            report.transform.localScale = closeReport;
            report2.transform.localScale = openReport;
        }
        else
        {
            report2.transform.localScale = closeReport;
            report3.transform.localScale = openReport;
        }
    }

    public void PrevReportButton()
    {
        if (report3.transform.localScale == openReport)
        {
            report3.transform.localScale = closeReport;
            report2.transform.localScale = openReport;
        }
        else
        {
            report2.transform.localScale = closeReport;
            report.transform.localScale = openReport;
        }
    }

    public void SuspectSelection(GameObject button)
    {
        if (button.name != "karakter1")
        {
            // Do something if the correct button was clicked
            wrongAnswer.SetActive(true);
        }
        else
        {
            // Do something if the incorrect button was clicked
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            chosenCharacter = button.name;
        }
    }

    public void TryAgain()
    {
        wrongAnswer.SetActive(false);
    }

    public void WatchExpertVideo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ShowEvidences()
    {
        evidencePopup.SetActive(true);
        reportBtn.interactable = false;
        evidenceBtn.interactable = false;
        karakter1.interactable = false;
        karakter2.interactable = false;
        karakter3.interactable = false;
    }

    public void CloseEvidences()
    {
        evidencePopup.SetActive(false);
        reportBtn.interactable = true;
        evidenceBtn.interactable = true;
        if (evidenceClicked1 && evidenceClicked2)
        {
            karakter1.interactable = true;
            karakter2.interactable = true;
            karakter3.interactable = true;
        }
    }

    public void InspectEvidence(GameObject button)
    {
        if (button.name == "evidence1Icon")
        {
            evidenceClicked1 = true;
            evidence1.SetActive(true);
        }
        else if (button.name == "evidence2Icon")
        {
            evidenceClicked2 = true;
            evidence2.SetActive(true);
        }
    }

    public void CloseEvidence()
    {
        evidence1.SetActive(false);
        evidence2.SetActive(false);
    }

    public void SkipText()
    {
        if (speechTxt.text == "There has been a murder in the Miller Mansion during a party, Mr. Davis. You are assigned to solve the case. Sarah Miller was murdered in cold blood. There is a high suspicion about this crime being a part of a bigger conflict, the future inheritance of Henry Miller's wealth.")
        {
            speechTxt.text = "We caught 3 suspects. We also brought 2 evidences for you to inspect. You can check them by clicking the button on top-left. You can also check personal information about suspects by clicking the button on top-right.";
        }
        else if (speechTxt.text == "We caught 3 suspects. We also brought 2 evidences for you to inspect. You can check them by clicking the button on top-left. You can also check personal information about suspects by clicking the button on top-right.")
        {
            speechTxt.text = "Choose a suspect who you think is not the murderer based on the evidences you inspected by clicking on the suspect.";
        }
        else if (speechTxt.text == "Choose a suspect who you think is not the murderer based on the evidences you inspected by clicking on the suspect.")
        {
            speechTxt.text = "Good luck Mr. Davis!";
        }
        else
        {
            textBox.SetActive(false);
        }
    }
}
