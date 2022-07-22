using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject model;
    [SerializeField] private Animator loadinganim;
    [SerializeField] private Sprite lastSpriteOfAnim;
    public PlayerHiding bools;
    public PlayerController speedOfPlayer;

    private void Start()
    {
        speedOfPlayer.speed = 5f;
    }
    private void Update()
    {
        InteractionButton();
    }
    private void InteractionButton()
    {
        if (Input.GetKeyDown(KeyCode.E) && (bools.canHide || bools.canShow))
        {
            
            loadinganim.SetBool("ButtonPressed", true);
            HidingCD();
        }
        else if(Input.GetKeyUp(KeyCode.E) && (bools.canHide || bools.canShow))
        {
            loadinganim.SetBool("ButtonPressed", false);
            HidingCD();
        }    
    }
    private void HidingCD()
    {

        if (bools.canHide && !bools.canShow)
        {
            //When Player out of Closet
            if (loading.GetComponent<SpriteRenderer>().sprite == lastSpriteOfAnim)
            {
                //when load is finished
                bools.canHide = false;
                bools.canShow = true;

                model.SetActive(false);
                speedOfPlayer.speed = 0f;
            }
        }
        else if (bools.canShow && !bools.canHide)
        {
            //When Player in Closet
            if (loading.GetComponent<SpriteRenderer>().sprite == lastSpriteOfAnim)
            {
                //when load is finished
                bools.canHide = true;
                bools.canShow = false;

                model.SetActive(true);
                speedOfPlayer.speed = 5f;
            }
        }
    }
}
