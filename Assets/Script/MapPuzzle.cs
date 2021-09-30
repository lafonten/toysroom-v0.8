using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MapPuzzle : MonoBehaviour
{
    public static MapPuzzle mapINSTANCE;
    public float rotationSpeed;
    public bool IsInitialized=false;
    public GameObject Puzzle_piece_1;
    public GameObject Puzzle_piece_2;
    public GameObject Puzzle_piece_3;
    public GameObject Puzzle_piece_4;
    private List<int> randomNumberList = new List<int>();
    public int mapNumber;
    public bool DidStart = false;

    int GetRandomAngle()
    {
        randomNumberList = new List<int>()
        {
            12,23,34,54,65,78,0,45,180,167,134,120,102,89,154
        };

        int randomNumbers = Random.Range(0, 14);

        return randomNumberList[randomNumbers];

    }

    void Start()
    {
        mapINSTANCE = this;
        Puzzle_piece_1 = GameObject.FindGameObjectWithTag("MapPuzzle1");
        Puzzle_piece_2 = GameObject.FindGameObjectWithTag("MapPuzzle2");
        Puzzle_piece_3 = GameObject.FindGameObjectWithTag("MapPuzzle3");
        Puzzle_piece_4 = GameObject.FindGameObjectWithTag("MapPuzzle4");
        OnStart();
        DidStart = false;

    }

    void Update()
    {
        MapRotateChecker();
    }


    public void OnStart()
    {
        StartPosition();
    }

    void OnBack()
    {
        transform.DORotate(new Vector3(-90, -120, transform.rotation.eulerAngles.z),0.5f);
        transform.DOMove(new Vector3(-3.1f, 0, -3f), 0.5f);
        
    }

    void StartPosition()
    {
        DOTween.Kill(this.gameObject);
        transform.DOMove(new Vector3(-3.1f,3.65f, -5.5f), 2f);
        transform.DORotate(new Vector3(0, -180,GetRandomAngle()), 2f);
        IsInitialized = true;
        

    }


    private void OnMouseDrag()
    {
        Rotate();
        CheckPuzzleName();
        DidStart = true;
    }

    private void OnMouseUp()
    {
        ForEasierWin();
    }

    void Rotate()
    {
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed *Time.deltaTime;

        this.transform.RotateAround(Vector3.forward, -rotationX);
    }

    void ForEasierWin()
    {
        float map1_rotation = Puzzle_piece_1.transform.rotation.eulerAngles.z;
        float map2_rotation = Puzzle_piece_2.transform.rotation.eulerAngles.z;
        float map3_rotation = Puzzle_piece_3.transform.rotation.eulerAngles.z;
        float map4_rotation = Puzzle_piece_4.transform.rotation.eulerAngles.z;

        if (CheckPuzzleName() == "1")
        {
            if (map1_rotation - map2_rotation >= -5 || map1_rotation - map2_rotation <= 5 )
            {
                Puzzle_piece_1.transform.DORotate(Puzzle_piece_2.transform.rotation.eulerAngles, 0.2f);
                mapNumber++;
            }
        }

        if (CheckPuzzleName() == "2")
        {
            if (map2_rotation - map3_rotation >= -5 || map2_rotation - map3_rotation <= 5)
            {
                Puzzle_piece_2.transform.DORotate(Puzzle_piece_3.transform.rotation.eulerAngles, 0.2f);
                mapNumber++;
            }
        }

        if (CheckPuzzleName() == "3")
        {
            if (map3_rotation - map4_rotation >= -5 || map3_rotation - map4_rotation <= 5)
            {
                Puzzle_piece_3.transform.DORotate(Puzzle_piece_4.transform.rotation.eulerAngles, 0.2f);
                mapNumber++;
            }
        }

        if (CheckPuzzleName() == "4")
        {
            if (map4_rotation - map3_rotation >= -5 || map4_rotation - map3_rotation <= 5)
            {
                Puzzle_piece_4.transform.DORotate(Puzzle_piece_3.transform.rotation.eulerAngles, 0.2f);
                mapNumber++;
            }
        }

    }

    string CheckPuzzleName()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "MapPuzzle1")
            {
                return "1";
            }
            if (hit.collider.gameObject.tag == "MapPuzzle2")
            {
                return "2";
            }
            if (hit.collider.gameObject.tag == "MapPuzzle3")
            {
                return "3";
            }
            if (hit.collider.gameObject.tag == "MapPuzzle4")
            {
                return "4";
            }
        }

        return null;
    }

    public bool MapRotateChecker()
    {
        if (DidStart)
        {
            Debug.Log("map1 rotate z : " + Puzzle_piece_1.transform.rotation.eulerAngles.z);
            Debug.Log("map2 rotate z : " + Puzzle_piece_2.transform.rotation.eulerAngles.z);
            Debug.Log("map3 rotate z : " + Puzzle_piece_3.transform.rotation.eulerAngles.z);
            Debug.Log("map4 rotate z : " + Puzzle_piece_4.transform.rotation.eulerAngles.z);

            if (Puzzle_piece_1.transform.rotation.eulerAngles.z == Puzzle_piece_2.transform.rotation.eulerAngles.z && Puzzle_piece_3.transform.rotation.eulerAngles.z == Puzzle_piece_4.transform.rotation.eulerAngles.z && Puzzle_piece_1.transform.rotation.eulerAngles.z == Puzzle_piece_4.transform.rotation.eulerAngles.z)
            {
                return true;
            }
        }
        return false;
    }

    public void MapColliderOff()
    {
        Puzzle_piece_1.GetComponent<MeshCollider>().enabled = false;
        Puzzle_piece_2.GetComponent<MeshCollider>().enabled = false;
        Puzzle_piece_3.GetComponent<MeshCollider>().enabled = false;
        Puzzle_piece_4.GetComponent<MeshCollider>().enabled = false;
    }

    public void MapColliderOn()
    {
        Puzzle_piece_1.GetComponent<MeshCollider>().enabled = true;
        Puzzle_piece_2.GetComponent<MeshCollider>().enabled = true;
        Puzzle_piece_3.GetComponent<MeshCollider>().enabled = true;
        Puzzle_piece_4.GetComponent<MeshCollider>().enabled = true;
    }

}
