using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> Images;
    public List<GameObject> SpawnPoints;

    private GameObject firstSelectBag;
    private string firstSelectFlower;
    private GameObject secSelectBag;
    private string secSelectFlower;

    public float MaxTime;
    float timer;
    bool startTimer;
    bool canHide;

    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            int flowerNum = Random.Range(0, Images.Count - i);
            Instantiate(Images[flowerNum], SpawnPoints[i].transform);
            SpawnPoints.RemoveAt(i);
            int secPoint = Random.Range(0, SpawnPoints.Count);
            Instantiate(Images[flowerNum], SpawnPoints[secPoint].transform);
            SpawnPoints.RemoveAt(secPoint);
            Images.RemoveAt(flowerNum);
            i = 0;
            timer = MaxTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startTimer)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                if (canHide)
                {
                    firstSelectBag.GetComponent<SpriteRenderer>().enabled = true;
                    firstSelectBag.GetComponent<Collider2D>().enabled = true;
                    secSelectBag.GetComponent<SpriteRenderer>().enabled = true;
                    secSelectBag.GetComponent<Collider2D>().enabled = true;
                }
                else
                {
                    Destroy(firstSelectBag);
                    Destroy(secSelectBag);
                }

                resetValues();
            }
        }
    }

    public bool AnableToClick()
    {
        return startTimer;
    }

    public void SelectedBags(GameObject Bag, string flowerName)
    {

        Debug.LogError(gameObject.transform.childCount);

        if (gameObject.transform.childCount <= 1)
        {
            gameObject.SetActive(false);
            WinScreen.SetActive(true);
        }

        if (!firstSelectBag)
        {
            firstSelectBag = Bag;
            firstSelectFlower = flowerName;
        }
        else
        {
            secSelectBag = Bag;
            secSelectFlower = flowerName;

            if (firstSelectFlower == secSelectFlower)
            {
                canHide = false;
                startTimer = true;
            }
            else
            {
                canHide = true;
                startTimer = true;
            }
        }
    }

    private void resetValues()
    {
        firstSelectBag = null;
        firstSelectFlower = null;
        firstSelectBag = null;
        firstSelectFlower = null;

        canHide = false;
        startTimer = false;
        timer = MaxTime;
    }
}