using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController04 : MonoBehaviour
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
    public GameObject evidence3;
    public GameObject report2;
    public GameObject report3;
    public GameObject report2Btns;
    public GameObject report3Btns;
    public GameObject textBox;
    public TextMeshProUGUI speechTxt;
    private bool evidenceClicked1 = false;
    private bool evidenceClicked2 = false;
    private bool evidenceClicked3 = false;
    Vector3 openReport = new Vector3(1, 1, 1);
    Vector3 closeReport = new Vector3(0, 0, 1);
    Color selectedColor = new Color(0.5f, 0.5f, 0.5f);
    Color unselectedColor = new Color(1.0f, 1.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button btn in report2Btns.GetComponentsInChildren<Button>())
        {
            if (btn.name == SceneController01.selectedBtn2)
            {
                btn.image.color = selectedColor;
            }
            else
            {
                btn.image.color = unselectedColor;
            }
        }

        foreach (Button btn in report3Btns.GetComponentsInChildren<Button>())
        {
            if (btn.name == SceneController01.selectedBtn3)
            {
                btn.image.color = selectedColor;
            }
            else
            {
                btn.image.color = unselectedColor;
            }
        }

        //�nceki sahnede se�ilmi� karakterin oyun i�inde g�r�nmemesi
        if (karakter1 != null && karakter1.gameObject.name == SceneController01.chosenCharacter)
        {
            karakter1.gameObject.SetActive(false);
        }
        else if (karakter2 != null && karakter2.name == SceneController01.chosenCharacter)
        {
            karakter2.gameObject.SetActive(false);
        }
        if (karakter1.gameObject.activeSelf)
        {
            karakter1.interactable = false;
        }
        else if (karakter2.gameObject.activeSelf)
        {
            karakter2.interactable = false;
        }
        karakter3.interactable = false;
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
    }

    //Rapor butonunun a��lmas�n� sa�lar
    public void OpenReportButton()
    {
        reportBtn.interactable = false;
        evidenceBtn.interactable = false;
        report2.transform.localScale = openReport;
        if (karakter1.gameObject.activeSelf)
        {
            karakter1.interactable = false;
        }
        else if (karakter2.gameObject.activeSelf)
        {
            karakter2.interactable = false;
        }
        karakter3.interactable = false;
    }

    //Rapor butonunun kapat�lmas�n� sa�lar
    public void CloseReportButton()
    {
        report2.transform.localScale = closeReport;
        report3.transform.localScale = closeReport;
        reportBtn.interactable = true;
        evidenceBtn.interactable = true;
        if (evidenceClicked1 && evidenceClicked2 && evidenceClicked3)
        {
            if (karakter1.gameObject.activeSelf)
            {
                karakter1.interactable = true;
            }
            else if (karakter2.gameObject.activeSelf)
            {
                karakter2.interactable = true;
            }
            karakter3.interactable = true;
        }
    }

    //S�radaki rapora ge�ilmesini sa�lar
    public void NextReportButton()
    {
        report2.transform.localScale = closeReport;
        report3.transform.localScale = openReport;
    }

    //�nceki rapora ge�ilmesini sa�lar
    public void PrevReportButton()
    {
        report2.transform.localScale = openReport;
        report3.transform.localScale = closeReport;
    }

    //��pheliyi se�er
    public void SuspectSelection(GameObject button)
    {
        if (button.name == "karakter1" || button.name == "karakter2")
        {
            wrongAnswer.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Try again butonuna bas�ld���nda Yanl�� Cevap pop-up'�n� kapat�r
    public void TryAgain()
    {
        wrongAnswer.SetActive(false);
    }

    public void ShowEvidences()
    {
        evidencePopup.SetActive(true);
        reportBtn.interactable = false;
        evidenceBtn.interactable = false;
        if (karakter1.gameObject.activeSelf)
        {
            karakter1.interactable = false;
        }
        else if (karakter2.gameObject.activeSelf)
        {
            karakter2.interactable = false;
        }
        karakter3.interactable = false;
    }


    //Kan�tlar�n oldu�u pop-up'� kapat�r
    public void CloseEvidences()
    {
        evidencePopup.SetActive(false);
        reportBtn.interactable = true;
        evidenceBtn.interactable = true;
        if (evidenceClicked1 && evidenceClicked2 && evidenceClicked3)
        {
            if (karakter1.gameObject.activeSelf)
            {
                karakter1.interactable = true;
            }
            else if (karakter2.gameObject.activeSelf)
            {
                karakter2.interactable = true;
            }
            karakter3.interactable = true;
        }
    }

    //Kan�t�n simgesine t�klay�nca kan�t� a�ar
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
        else
        {
            evidenceClicked3 = true;
            evidence3.SetActive(true);
        }
    }

    public void CloseEvidence()
    {
        evidence1.SetActive(false);
        evidence2.SetActive(false);
        evidence3.SetActive(false);
    }

    //Metin kutucu�undaki ileri butonuna bas�nca bir sonraki metne ge�er
    public void SkipText()
    {
        if (speechTxt.text == "Good job on proving the innocence of Steve Melvin, Mr. Davis.")
        {
            speechTxt.text = "New evidences have arrived. We need you to find the murderer.";
        }
        else if (speechTxt.text == "New evidences have arrived. We need you to find the murderer.")
        {
            speechTxt.text = "Click on the suspect you think is the murderer after you finish inspecting the evidences.";
        }
        else if (speechTxt.text == "Click on the suspect you think is the murderer after you finish inspecting the evidences.")
        {
            speechTxt.text = "Good luck Mr. Davis!";
        }
        else
        {
            textBox.SetActive(false);
        }
    }
}
