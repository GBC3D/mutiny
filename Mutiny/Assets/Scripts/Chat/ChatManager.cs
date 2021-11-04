using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    ChatClient chatClient;
    public InputField InputFieldChat;
    public Text CurrentChannelText;

    [SerializeField]
    string userId = Username.getUsername();

    private string selectedChannelName;

    private string mutinyChat;

    private readonly Dictionary<string, Toggle> channelToggles = new Dictionary<string, Toggle>();

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        if (channelName.Equals(this.selectedChannelName))
        {
            // update text
            this.ShowChannel(this.selectedChannelName);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnApplicationQuit()
    {
        if (this.chatClient != null)
        {
            this.chatClient.Disconnect();
        }
    }

	private void SendChatMessage(string inputLine)
	{
        string[] tokens = inputLine.Split(new char[] { ' ' }, 2);

        string[] subtokens = tokens[1].Split(new char[] { ' ', ',' }, 2);

        // If we are already subscribed to the channel we directly switch to it, otherwise we subscribe to it first and then switch to it implicitly
        if (this.channelToggles.ContainsKey(subtokens[0]))
        {
            this.ShowChannel(subtokens[0]);
        }
        else
        {
            this.chatClient.Subscribe(new string[] { subtokens[0] });
        }

        if (string.IsNullOrEmpty(inputLine))
		{
			return;
		}
		    this.chatClient.PublishMessage(mutinyChat, inputLine);
	}

    public void OnEnterSend()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            this.SendChatMessage(this.InputFieldChat.text);
            this.InputFieldChat.text = "";
        } //SEE ABOUT MAKING USER SUBSCRIBE WHEN THEY CHOOSE THEIR USERNAME BC I BET THAT'S HOW YOU DO IT CHECK THE DEMO
    }

    public void ShowChannel(string channelName)
    {
        if (string.IsNullOrEmpty(channelName))
        {
            return;
        }

        ChatChannel channel = null;
        bool found = this.chatClient.TryGetChannel(channelName, out channel);
        if (!found)
        {
            Debug.Log("ShowChannel failed to find channel: " + channelName);
            return;
        }

        this.selectedChannelName = channelName;
        this.CurrentChannelText.text = channel.ToStringMessages();
        Debug.Log("ShowChannel: " + this.selectedChannelName);
    }

    // Start is called before the first frame update
    void Start()
    {
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(userId));
    }

    // Update is called once per frame
    void Update()
    {
        if (this.chatClient != null)
        {
            this.chatClient.Service();
        }
    }

}
