using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class SceneManager : MonoBehaviour
{
    public GameObject CamInitialPosition;
    public GameObject CamGamePosition;
    public GameObject Cam;

    public GameObject textPanel;
    public GameObject HeaderTEXT;

    public static SceneManager sceneManagerInstance;

    public Text winText;
    public GameObject next_toy_button;
    public bool OnBeforeWin = false;

    private void Start()
    {
        sceneManagerInstance = this;
        Cam.transform.DOMove(CamInitialPosition.transform.position, 4f);

    }

    private void Update()
    {
        BeforeWin();
        
    }

    public bool CameraPosition()
    {

        if (Cam.transform.position == CamInitialPosition.transform.position)
        {
            return true;

        }

        return false;
    }


    public void ToysNumberDecrease()
    {
        GameManager.instanceGameManager.groupNumber++;
        OnBeforeWin = false;
        next_toy_button.SetActive(false);

    }

    public void ToysNumberIncrease()
    {
        GameManager.instanceGameManager.groupNumber--;
        if (GameManager.instanceGameManager.groupNumber == 0)
        {
            GameManager.instanceGameManager.groupNumber = 1;
        }
    }


    void BeforeWin()
    {
        if (Glasses.glassesInstance.WinCalendar() && GameManager.instanceGameManager.groupNumber == 1 && !OnBeforeWin)
        {
            StartCoroutine(win());
            OnBeforeWin = true;
            Debug.Log("win worked!");

        }
        else
        {
            Debug.Log("afterwin worked!");
        }

        if (rabbitControler.rabbitInstance.WinRabbit() && GameManager.instanceGameManager.groupNumber == 2 && !OnBeforeWin)
        {
            StartCoroutine(win());
            OnBeforeWin = true;

        }
        else
        {
        }

        if (MapPuzzle.mapINSTANCE.MapRotateChecker() && GameManager.instanceGameManager.groupNumber == 3 && !OnBeforeWin)
        {
            StartCoroutine(win());
            OnBeforeWin = true;

        }
        else
        {
        }

        if (pervaneControler.PervaneInstance.WinHelicopter() && GameManager.instanceGameManager.groupNumber == 4 && !OnBeforeWin)
        {
            StartCoroutine(win());
            OnBeforeWin = true;

        }
        else
        {
        }



    }

    IEnumerator win()
    {
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        winText.gameObject.SetActive(false);
        next_toy_button.SetActive(true);
    }

    
}
