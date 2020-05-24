using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pick : MonoBehaviour
{
    public Image img1;
    public Image img2;
    public Image img3;

    public GameObject panelUI;
    public GameObject panelEnd;
    public Text endText;

    private int goodRoom = 1;
    private int goodNPC = 2;
    private int goodTool = 3;
    
    private int chosenRoom = 0;
    private int chosenNPC = 0;
    private int chosenTool = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var actualRoom = 0;

        var position = transform.position;
        if (position.z > 6)
        {
            actualRoom = 1;
        }
        else if (position.x > 7)
        {
            actualRoom = 4;
        }
        else if (position.x < -5)
        {
            actualRoom = 2;
        }
        else if (position.z < -5)
        {
            actualRoom = 3;
        }
        
        if(actualRoom == 0)
            return;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switch (actualRoom)
            {
                case 1:
                    img1.color = Color.red;
                    break;
                case 2:
                    img1.color = Color.blue;
                    break;
                case 3:
                    img1.color = Color.yellow;
                    break;
                case 4:
                    img1.color = Color.green;
                    break;
            }
            
            chosenRoom = actualRoom;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            img2.sprite = Resources.Load<Sprite>("NPC" + actualRoom);

            chosenNPC = actualRoom;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            img3.sprite = Resources.Load<Sprite>("Tool" + actualRoom);

            chosenTool = actualRoom;
        }

        if (chosenRoom != 0 && chosenTool != 0 && chosenNPC != 0)
        {
            if(chosenRoom != goodRoom)
                endText.text = "Bad room";
            else if(chosenNPC != goodNPC)
                endText.text = "Bad NPC";
            else if(chosenTool != goodTool)
                endText.text = "Bad Tool";
            else
                endText.text = "You won";
            
            panelUI.SetActive(false);
            panelEnd.SetActive(true);
            
            
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
