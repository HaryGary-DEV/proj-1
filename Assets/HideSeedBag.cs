using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideSeedBag : MonoBehaviour
{
    public SpriteRenderer SeedBagImage;
    public Collider2D SeedBagCollider;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameManager.AnableToClick())
        {
            SeedBagImage.enabled = false;
            SeedBagCollider.enabled = false;
            if (gameObject.transform.childCount <= 0)
            {
                gameManager.SelectedBags(gameObject, "Empty Seed Bag");
            }
            else
            {
                gameManager.SelectedBags(gameObject, gameObject.transform.GetChild(0).name);
            }
        }
    }
}
