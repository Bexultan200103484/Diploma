using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField] private Collider currentCollider;
    private Collider currentCollider2;
    private Camera mainCamera;
    private Plane dragPlane;
    private bool inputStart;
    private Vector3 offset;
    private Vector3 newPosition;
    private bool coroutineCalled = false;

    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SelectPart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }
        if (Input.GetButtonDown("Jump") && currentCollider2 != null && mainCamera.transform.position.y < 2f)
        {
            if (currentCollider2.CompareTag("Card"))
            {
                StartCoroutine(WaitForFiveSeconds());
            }
        }
        // if (currentCollider2 != null && mainCamera.transform.position.y > 2f && !coroutineCalled)
        // {
        //     newPosition = mainCamera.transform.position + mainCamera.transform.forward * 5f;

        //     currentCollider2.transform.position = newPosition;
        // }


        DragAndDropObject();
    }
    private void SelectPart()
    {
        RaycastHit hit;
        Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out hit, 2000f, LayerMask.GetMask("Robot")))
        {
            currentCollider = hit.collider;
            currentCollider2 = currentCollider;
            dragPlane = new Plane(mainCamera.transform.forward, currentCollider.transform.position);
            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = currentCollider.transform.position - camRay.GetPoint(planeDist);
        }
    }

    private void DragAndDropObject()
    {
        if (currentCollider == null)
        {
            return;
        }
        Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        currentCollider.transform.position = camRay.GetPoint(planeDist) + offset;

        // if (currentCollider.transform.position.y < 0.5f)
        // {
        //     currentCollider.transform.position =
        //         new Vector3(currentCollider.transform.position.x,
        //             0.5f,
        //             currentCollider.transform.position.z);
        // }

    }

    private void Drop()
    {
        if (currentCollider == null)
        {
            return;
        }
        // currentCollider.transform.position =
        //     new Vector3(currentCollider.transform.position.x,
        //         0.5f,
        //         currentCollider.transform.position.z);
        currentCollider = null;
    }

    private IEnumerator WaitForFiveSeconds()
    {
        yield return new WaitForSeconds(2.3f);

        newPosition = mainCamera.transform.position +
                                 mainCamera.transform.forward * 0.35f;

        //currentCollider2.transform.rotation = mainCamera.transform.rotation;
        currentCollider2.transform.position = newPosition;
        currentCollider2.transform.LookAt(mainCamera.transform);
        currentCollider2.transform.Rotate(20, 180, 0);

        coroutineCalled = true;
    }

}
