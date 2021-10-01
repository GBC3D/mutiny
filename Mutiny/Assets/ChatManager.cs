using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChatManager : MonoBehaviourPunCallbacks
{
    //public Text typedText;
    public Text fullChatText;

    [SerializeField]
    private InputField chatInputField;

    private void Update()
    {
        if (chatInputField.gameObject.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                //photonView.RPC("SendMessage", RpcTarget.Others);
                SendMessage();
            }
        }
    }

    public void SendMessage()
    {
        string message = "\n" + chatInputField.text;
        
        photonView.RPC("ReceiveMessage", RpcTarget.All, message);
        
        ResetMessage();
    }

    [PunRPC]
    public void ReceiveMessage(string receivedMessage)
    {
        var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
        foreach (var view in photonViews)
        {
            var player = view.Owner;
            if (player != null)
            {
                var playerPrefabObject = view.gameObject;
             //   playerPrefabObject.GetComponent<>;
            }
        }
        //Debug.Log("message received loud and clear");
        fullChatText.text += receivedMessage;
    }

    private void ResetMessage()
    {
        chatInputField.text = "";
        chatInputField.ActivateInputField();
    }


}
