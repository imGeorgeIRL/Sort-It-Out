using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Doorbell : MonoBehaviour
{
    [SerializeField] TextMeshPro interactionText;
    [SerializeField] GameObject door;
    [SerializeField] PackageLocation packageDelivery;
    [SerializeField] GameObject mrsFlower;
    [SerializeField] Vector3 mrsFlowerNewPosition = new Vector3(39.0f, 0.0f, 50.5f);


    private void OnTriggerEnter(Collider other)
    {
        interactionText.gameObject.SetActive(true);
        if (packageDelivery.isCorrectPackage)
        {
            WaitCoroutine(5f);
            door.SetActive(true);

        }

        MoveMrsFlower();
    }

    private void OnTriggerStay(Collider other)
    {
        if (packageDelivery.isCorrectPackage)
        {
            WaitCoroutine(5f);
            door.SetActive(true);

        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            MoveMrsFlower();
        }

        MoveMrsFlower();


    }

    private void OnTriggerExit(Collider other)
    {
        interactionText.gameObject.SetActive(false);
        MoveMrsFlower();
    }

    public void RingDoorbell ()
    {
        WaitCoroutine(2f);
        door.SetActive(false);
    }

    private void MoveMrsFlower()
    {
        mrsFlower.transform.position = mrsFlowerNewPosition;
    }
    IEnumerator WaitCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
