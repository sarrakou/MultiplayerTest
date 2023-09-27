using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class NetworkManager : MonoBehaviourPunCallbacks , IInRoomCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster() was called by PUN.");

        RoomOptions options = new RoomOptions();
        TypedLobby lobby = new TypedLobby("MainLobby", LobbyType.Default);

        options.IsOpen = true;
        options.MaxPlayers = 4;
        options.IsVisible = true;

        PhotonNetwork.JoinOrCreateRoom("MainRoom", options, lobby);
    }

    public override void OnJoinedRoom()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity).GetPhotonView();
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("Player entered room");
    }

    public override void OnPlayerLeftRoom(Player oldPlayer)
    {
        print("Player left room");
    }
}
