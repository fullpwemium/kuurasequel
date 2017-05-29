using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifGameInfo : MonoBehaviour
{
    public Button infoButton;
    public GameObject infoPanel;
    public GameObject infoPicture1, infoPicture2;
    public List<Sprite> infoImages;
    public Text infoText;
    public Text pageNumber;
    public Button infoNextButton;
    public Button infoPrevButton;
    public int infoPage;

    // Use this for initialization
    void Start()
    {
        infoPage = 1;
        infoPanel.SetActive(false);
    }

    //When clicking info button
    public void openInfoPanel()
    {
        infoPanel.SetActive(true);
        infoPage = 1;
        infoText.text = "Sivu 1";
    }

    //When clicking closing info button
    public void closeInfoPanel()
    {
        infoPanel.SetActive(false);
    }

    //When clicking next page button
    public void infoPanelNextPage()
    {
        //Check if infoPage is inside wanted numbers.
        if (infoPage >= 1 && infoPage <= 3)
        {
            infoPage++;
            Debug.Log("Info page = " + infoPage);
        }
    }

    //When clicking previous page button
    public void infoPanelPrevPage()
    {
        //Check if infoPage is inside wanted numbers.
        if (infoPage >= 1 && infoPage <= 3)
        {
            infoPage--;
            Debug.Log("Info page = " + infoPage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Define contents and actions in each page numbers when infoPanel is active.
        if (infoPanel.activeInHierarchy == true)
        {
            if (infoPage == 1)
            {
                infoPicture1.SetActive(false);
                infoPicture2.SetActive(false);
                infoText.text = "Sivu 1";
                pageNumber.text = infoPage + " / 3";

                infoPrevButton.interactable = false;
                infoNextButton.interactable = true;
            }
            if (infoPage == 2)
            {
                infoPicture1.SetActive(true);
                infoPicture2.SetActive(true);
                infoPicture1.GetComponent<SpriteRenderer>().sprite = infoImages[1];
                infoPicture2.GetComponent<SpriteRenderer>().sprite = infoImages[0];
                infoText.text = "Sivu 2";
                pageNumber.text = infoPage + " / 3";

                infoPrevButton.interactable = true;
                infoNextButton.interactable = true;
            }
            if (infoPage == 3)
            {
                infoPicture1.GetComponent<SpriteRenderer>().sprite = infoImages[0];
                infoPicture2.GetComponent<SpriteRenderer>().sprite = infoImages[0];
                infoText.text = "Sivu 3";
                pageNumber.text = infoPage + " / 3";

                infoPrevButton.interactable = true;
                infoNextButton.interactable = false;
            }
        }
    }
}
