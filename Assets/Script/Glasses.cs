using DG.Tweening;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Glasses : MonoBehaviour
{

    public static Glasses glassesInstance;

    public GameObject initialPlace;
    public GameObject joint;
    public LayerMask CalendarLayerMask;

    public TextMeshPro winText;

    public bool OnCalendar = false;
    public bool CanBackToInitialPosition = false;

    private Rigidbody glassesRigidbody;

    private float mZCoord;
    private Vector3 mOffset;

    public Vector3[] numberPositions;

    public float distancebetweentwovector;

    public int onNumber;

    public GlassesState gState = GlassesState.FreeMove;




    void Start()
    {
        glassesInstance = this;
        glassesRigidbody = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        Checker();

    }


    private void FixedUpdate()
    {
        if (Calendar.instance.startRotation)
        {
            BackToInitial();
            gState = GlassesState.FreeMove;
        }

        if (gState == GlassesState.DeterminatingMove)
        {
            RigidBodyOnOff();
        }

    }

    void Checker()
    {
        RaycastHit hit;

        Vector3 originMiddle = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Ray rayMiddle = new Ray(originMiddle, Vector3.forward);

        if (Physics.SphereCast(rayMiddle, 0.3f, out hit, 1f, CalendarLayerMask))
        {
            OnCalendar = true;
        }
        else
        {
            OnCalendar = false;
        }

        Debug.DrawRay(originMiddle, Vector3.forward, Color.blue);


    }

    private void OnMouseUp()
    {
        if (OnCalendar)
        {
            if (!Calendar.instance.StillRotating)
            {
                transform.DOMove(new Vector3(-3f, transform.position.y, transform.position.z), 0.1f);
                numberChecker();
                gState = GlassesState.DeterminatingMove;
            }
            else
            {
                CanBackToInitialPosition = true;
            }
        }

        if (CanBackToInitialPosition)
        {
            transform.DOMove(initialPlace.transform.position, 0.5f);
            CanBackToInitialPosition = false;
            glassesRigidbody.isKinematic = false;
        }
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (gState == GlassesState.FreeMove)
        {
            transform.position = GetMouseWorldPos() + mOffset;

        }
        else if (gState == GlassesState.DeterminatingMove)
        {
            float targetY = GetMouseWorldPos().y + mOffset.y;

            targetY = Mathf.Clamp(targetY, -0.12f, 6.8f);

            transform.position =
                new Vector3(transform.position.x, targetY, transform.position.z);

            if (transform.position.y >= 6.75)
            {
                gState = GlassesState.FreeMove;
                CanBackToInitialPosition = true;
            }

        }


    }

    void RigidBodyOnOff()
    {
        glassesRigidbody.isKinematic = true;
    }

    void BackToInitial()
    {
        if (OnCalendar)
        {
            transform.DOMove(initialPlace.transform.position, 0.5f);
            glassesRigidbody.isKinematic = false;
        }
    }

    void numberChecker()
    {
        if (Vector3.Distance(this.transform.position, numberPositions[0]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 6.3f, -3f), 0.3f);
            onNumber = 1;
        }

        else if (Vector3.Distance(this.transform.position, numberPositions[1]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 5.9f, -3f), 0.2f);
            onNumber = 2;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[2]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 5.46f, -3f), 0.2f);
            onNumber = 3;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[3]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 5.04f, -3f), 0.2f);
            onNumber = 4;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[4]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 4.62f, -3f), 0.2f);
            onNumber = 5;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[5]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 4.20f, -3f), 0.2f);
            onNumber = 6;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[6]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 3.78f, -3f), 0.2f);
            onNumber = 7;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[7]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 3.36f, -3f), 0.2f);
            onNumber = 8;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[8]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 2.94f, -3f), 0.2f);
            onNumber = 9;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[9]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 2.44f, -3f), 0.2f);
            onNumber = 10;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[10]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 1.97f, -3f), 0.2f);
            onNumber = 11;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[11]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 1.60f, -3f), 0.2f);
            onNumber = 12;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[12]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 1.18f, -3f), 0.2f);
            onNumber = 13;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[13]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 0.76f, -3f), 0.2f);
            onNumber = 14;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[14]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, 0.34f, -3f), 0.2f);
            onNumber = 15;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[15]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-3, -0.11f, -3f), 0.2f);
            onNumber = 16;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[16]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 5.97f, -3f), 0.2f);
            onNumber = 17;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[17]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 5.55f, -3f), 0.2f);
            onNumber = 18;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[18]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 5.13f, -3f), 0.2f);
            onNumber = 19;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[19]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 4.71f, -3f), 0.2f);
            onNumber = 20;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[20]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 4.29f, -3f), 0.2f);
            onNumber = 21;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[21]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 3.87f, -3f), 0.2f);
            onNumber = 22;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[22]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 3.45f, -3f), 0.2f);
            onNumber = 23;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[23]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 2.98f, -3f), 0.2f);
            onNumber = 24;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[24]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 2.56f, -3f), 0.2f);
            onNumber = 25;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[25]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 2.14f, -3f), 0.2f);
            onNumber = 26;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[26]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 1.72f, -3f), 0.2f);
            onNumber = 27;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[27]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 1.3f, -3f), 0.2f);
            onNumber = 28;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[28]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 0.88f, -3f), 0.2f);
            onNumber = 29;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[29]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 0.46f, -3f), 0.2f);
            onNumber = 30;
        }
        else if (Vector3.Distance(this.transform.position, numberPositions[30]) <= distancebetweentwovector)
        {
            transform.DOMove(new Vector3(-2.9f, 0, -3f), 0.2f);
            onNumber = 31;
        }
        else
        {
            onNumber = 0;
        }
    }

    public bool WinCalendar()
    {
        if (onNumber == Calendar.instance.randomNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

public enum GlassesState
{
    FreeMove,
    DeterminatingMove
}

