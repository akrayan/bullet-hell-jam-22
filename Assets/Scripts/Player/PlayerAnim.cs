using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private GameObject PlayerSprite;
    [SerializeField] private GameObject GunSprite;
    [SerializeField] private GameObject[] Hands = new GameObject[2];
    private PlayerInput pi;
    private Animator anim;

    private bool walk = false;
    private bool back = false;
    private bool go_right = false;
    Vector3 distHand;
    Vector3 posGun;
    SpriteRenderer gunRunderer;
    int gunRunderOrder;
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        anim = PlayerSprite?.GetComponent<Animator>();
        distHand = Hands[1].transform.position - Hands[0].transform.position;
        posGun = GunSprite.transform.localPosition;
        gunRunderer = GunSprite.GetComponent<SpriteRenderer>();
        gunRunderOrder = gunRunderer.sortingOrder;
    }

    void CheckWalking()
    {
        walk = pi.horizontal != 0 || pi.vertical != 0;
    }

    void CheckOrientation()
    {
        Vector3 dir = pi.pointAt - GunSprite.transform.position;
        back = dir.y > 0;
        go_right = dir.x > 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWalking();
        CheckOrientation();
        anim.SetBool("walk", walk);
        anim.SetBool("back", back);
        if (back)
        {
            GunSprite.transform.localPosition = posGun + distHand;
            gunRunderer.sortingOrder = gunRunderOrder - 4;
            Hands[0].SetActive(false);
            Hands[1].SetActive(true);
        }
        else
        {
            GunSprite.transform.localPosition = posGun;
            gunRunderer.sortingOrder = gunRunderOrder;
            Hands[0].SetActive(true);
            Hands[1].SetActive(false);
        }
        //anim.SetFloat("go_right", go_right ? 1 : -1);

        // r !b = 1
        // r b = -1
        // !r !b = -1
        // !r b = 1

        PlayerSprite.transform.localScale = new Vector3(go_right != back ? 1 : -1, 1, 1);
        if (go_right != (GunSprite.transform.localScale.y > 0))
            Utils2D.TransformFilpY(GunSprite.transform);
    }
}
