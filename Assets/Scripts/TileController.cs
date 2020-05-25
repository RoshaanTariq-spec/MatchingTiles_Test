using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Button))]
public class TileController : MonoBehaviour
{
    private Sprite iconImg;

    //[HideInInspector]
    [SerializeField] private bool isShown = false;

    private Image img;
    private Animator anim;

    public Sprite IconImg { get => iconImg; set => iconImg = value; }

    private void Start()
    {
        img = this.GetComponent<Image>();
        anim = this.GetComponent<Animator>();

        this.GetComponent<Button>().onClick.AddListener(() => OnPress_Tile());

        img.sprite = Toolbox.GameplayController.tileBackSideImg;
    }

    public void OnPress_Tile() {
        
        if (isShown)
            return;

        ShowTile();

        StartCoroutine(CR_CheckTiles());
    }

    public void ShowTile() {

        isShown = true;
        anim.SetTrigger("Toggle");

    }

    public void HideTile() {

        isShown = false;
        anim.SetTrigger("Toggle");
    }

    public void Toggle_Image() {

        if (img.sprite == iconImg)
        {
            img.sprite = Toolbox.GameplayController.tileBackSideImg;
        }
        else {

            img.sprite = iconImg;
        }
    }

    IEnumerator CR_CheckTiles() {

        yield return new WaitForSeconds(0.7f);

        Toolbox.GameplayController.Check_ShowTile(this.iconImg, this);
    }
}
