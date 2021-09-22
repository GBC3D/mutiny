using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private SkinCollection skinCollection;
    public PlayerSpriteSetter playerSpriteSetter;

    public Transform contentHolder;

    public GameObject skinSelectionPrefab; // should be the button selecting a skin

    public GameObject skinScrollView;

    public void SetPlayer(PlayerSpriteSetter _playerSpriteSetter)
    {
        if (_playerSpriteSetter.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Local bobby found");
            if (playerSpriteSetter != null)
                return;

            playerSpriteSetter = _playerSpriteSetter;
            skinCollection = playerSpriteSetter.skinCollection;

            SkinSelectionCreator newSkinSelect; // create instance of SkinSelectionCreator

            for (int i = 0; i < skinCollection.skins.Count; i++)
            {
                newSkinSelect = Instantiate(skinSelectionPrefab, contentHolder).GetComponent<SkinSelectionCreator>();
                newSkinSelect.Setup(skinCollection.skins[i], playerSpriteSetter, i);
            }
        }
        
    }

    public void ToggleSkinView()
    {
        if (skinScrollView.activeInHierarchy)
            skinScrollView.SetActive(false);
        else
            skinScrollView.SetActive(true);
    }
}
