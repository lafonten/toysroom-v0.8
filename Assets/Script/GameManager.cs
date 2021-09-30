using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int groupNumber = 1;
    public static GameManager instanceGameManager;
    public int Spawned = 0;
    public Text hud_text;
    public GameObject winTEXT;
    public bool finished = false;
    public GameObject next_Gameobject;


    void Start()
    {
        instanceGameManager = this;
        //SpawnToy(GetGroupName(groupNumber));

    }

    void Update()
    {
       // SpawnToy(GetGroupName(groupNumber));
        TextUpdate();
        if (SceneManager.sceneManagerInstance.CameraPosition())
        {
            hud_text.gameObject.SetActive(true);
        }
        AfterWin();
    }

    void AfterWin()
    {
        if (GameObject.FindGameObjectWithTag("Calendar") != null && SceneManager.sceneManagerInstance.OnBeforeWin)
        {
            Debug.Log("Worked");
            GameObject.FindGameObjectWithTag("Calendar").GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Glasses").GetComponent<BoxCollider>().enabled = false;

        }


        if (GameObject.FindGameObjectWithTag("Rabbit") != null && SceneManager.sceneManagerInstance.OnBeforeWin)
        {
            GameObject.FindGameObjectWithTag("Rabbit").GetComponent<MeshCollider>().enabled = false;
        }


        if (GameObject.FindGameObjectWithTag("MapPuzzle1") != null && SceneManager.sceneManagerInstance.OnBeforeWin)
        {
            MapPuzzle.mapINSTANCE.MapColliderOff();
        }


    }

    string GetGroupName(int GroupNo)
    {
        string groupName = "Calendar";
        switch (GroupNo)
        {
            case 1:
                groupName = "Calendar";
                break;
            case 2:
                groupName = "Rabbit";
                break;
            case 3:
                groupName = "MapPuzzle";
                break;
            case 4:
                groupName = "Helikopter";
                break;
            case 5:
                groupName = "KutuBulmaca";
                break;
            default:
                Debug.Log("WRONG WAY");
                break;

        }

        return groupName;
    }


    void SpawnToy(string toy_name)
    {
        if (toy_name == "Calendar" && GameObject.FindGameObjectWithTag("Calendar") == null)
        {

            int randomNumber = Random.Range(1, 31);
            hud_text.text = "CAN U FIND " + randomNumber + " ON THE CALENDAR?";
            Instantiate(Resources.Load("Prefabs/Calendar", typeof(GameObject)), new Vector3(-2.94f, -0.5f, -2),
                 Quaternion.identity);
            GameObject.FindGameObjectWithTag("Calendar").transform.Rotate(270, 180, 0);
            Instantiate(Resources.Load("Prefabs/Glasses", typeof(GameObject)), new Vector3(-6f, 0f, -3f),
                Quaternion.identity);
            GameObject.FindGameObjectWithTag("Glasses").transform.Rotate(90, 90, 0);
            Instantiate(Resources.Load("Prefabs/initialPoint", typeof(GameObject)), new Vector3(-7.77f, 1.6f, -3f),
                Quaternion.identity);


            if (GameObject.FindGameObjectWithTag("Rabbit") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Rabbit"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle1") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle1"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle2") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle2"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle3") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle3"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle4") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle4"));
            }
        }
        if (toy_name == "Rabbit" && GameObject.FindGameObjectWithTag("Rabbit") == null)
        {
            //CalendarTEXT.SetActive(false);
            //RabbitTEXT.SetActive(true);
            //MapTEXT.SetActive(false);
            //hud_object_name.text = "SECRET DUCK";
            if (GameObject.FindGameObjectWithTag("Calendar") != null)
            {
                GameObject[] Calendars = GameObject.FindGameObjectsWithTag("Calendar");
                Destroy(Calendars[0]);
                Destroy(Calendars[1]);
                Destroy(GameObject.FindGameObjectWithTag("Glasses"));
            }

            if (GameObject.FindGameObjectWithTag("Rabbit") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Rabbit"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle1") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle1"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle2") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle2"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle3") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle3"));
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle4") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle4"));
            }

            Instantiate(Resources.Load("Prefabs/rabbit", typeof(GameObject)), new Vector3(-3f, 1.5f, -4),
                Quaternion.identity);
            GameObject.FindGameObjectWithTag("Rabbit").transform.Rotate(0, 90, 0);
        }

        if (toy_name == "MapPuzzle")
        {

            if (GameObject.FindGameObjectWithTag("Helikopter") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Helikopter"));
            }

            if (GameObject.FindGameObjectWithTag("Rabbit") != null && Spawned == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Rabbit"));
            }

            if (GameObject.FindGameObjectWithTag("Calendar") != null)
            {
                GameObject[] Calendars = GameObject.FindGameObjectsWithTag("Calendar");
                Destroy(Calendars[0]);
                Destroy(Calendars[1]);
                Destroy(Calendars[2]);
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle1") == null)
            {
                Instantiate(Resources.Load("Prefabs/MapPuzzle_1", typeof(GameObject)), new Vector3(-3.1f, 0, -2f), Quaternion.identity);
                GameObject.FindGameObjectWithTag("MapPuzzle1").transform.Rotate(-90, -120, 40);
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle2") == null)
            {
                Instantiate(Resources.Load("Prefabs/MapPuzzle_2", typeof(GameObject)), new Vector3(-3.1f, 0, -2f), Quaternion.identity);
                GameObject.FindGameObjectWithTag("MapPuzzle2").transform.Rotate(-90, -120, -40);
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle3") == null)
            {
                Instantiate(Resources.Load("Prefabs/MapPuzzle_3", typeof(GameObject)), new Vector3(-3.1f, 0, -2), Quaternion.identity);
                GameObject.FindGameObjectWithTag("MapPuzzle3").transform.Rotate(-90, -120, 170);
            }

            if (GameObject.FindGameObjectWithTag("MapPuzzle4") == null)
            {
                Instantiate(Resources.Load("Prefabs/MapPuzzle_4", typeof(GameObject)), new Vector3(-3.1f, 0, -2), Quaternion.identity);
                GameObject.FindGameObjectWithTag("MapPuzzle4").transform.Rotate(-90, -120, 115);
            }

            
        }

        if (toy_name == "Helikopter")
        {
            if (GameObject.FindGameObjectWithTag("MapPuzzle1") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle1"));
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle2"));
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle3"));
                Destroy(GameObject.FindGameObjectWithTag("MapPuzzle4"));

            }

            if (GameObject.FindGameObjectWithTag("Pervane") == null)
            {
                Instantiate(Resources.Load("Prefabs/f", typeof(GameObject)), new Vector3(-3.004108f, -1.997138f, -2.061769f),
                    Quaternion.identity);
            }

            if (GameObject.FindGameObjectWithTag("Rabbit") != null && Spawned == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Rabbit"));
            }

            if (GameObject.FindGameObjectWithTag("Calendar") != null)
            {
                GameObject[] Calendars = GameObject.FindGameObjectsWithTag("Calendar");
                Destroy(Calendars[0]);
                Destroy(Calendars[1]);
                Destroy(Calendars[2]);
            }
        }

        if (toy_name == "KutuBulmaca")
        {
            if (GameObject.FindGameObjectWithTag("KutuBulmaca") == null)
            {
                Instantiate(Resources.Load("Prefabs/kutubulmaca", typeof(GameObject)), new Vector3(-3.3f, 0.5f, -7f),
                    Quaternion.identity);
            }

            if (GameObject.FindGameObjectWithTag("Helikopter") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Helikopter"));
            }
        }
    }

    void TextUpdate()
    {
        if (GetGroupName(groupNumber) == "Calendar")
        {
            hud_text.text = "CAN U FIND " + Calendar.instance.randomNumber + " ON THE CALENDAR?";
        }
        else if (GetGroupName(groupNumber) == "Rabbit")
        {
            hud_text.text = "CAN U FIND THE RABBIT";
        }
        else if (GetGroupName(groupNumber) == "MapPuzzle")
        {
            hud_text.text = "CAN U FIXED THIS MAP ";
        }
    }

}
