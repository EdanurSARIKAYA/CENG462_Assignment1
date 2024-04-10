using UnityEngine;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER1WON, PLAYER2WON }

public class BattleSystem : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

     void SetupBattle()
    {
        state = BattleState.PLAYER1TURN;
        player1.GetComponent<launcher>().enabled = true;
        player1.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<launcher>().enabled = false;
        player2.GetComponent<Player2Movement>().enabled = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            switch (state)
            {
                case BattleState.PLAYER1TURN:
                    Player1Turn();
                    break;
                case BattleState.PLAYER2TURN:
                    Player2Turn();
                    break;
                default:
                    break;
            }
    }

    void Player1Turn()
    {
        player1.GetComponent<launcher>().FireProjectile();
        player1.GetComponent<launcher>().ClearTrajectory();
        // Player 1 has finished their turn, switch to player 2
        state = BattleState.PLAYER2TURN;
        player1.GetComponent<launcher>().enabled = false;
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<launcher>().enabled = true;
        player2.GetComponent<Player2Movement>().enabled = true;
    }

    void Player2Turn()
    {
        player2.GetComponent<launcher>().FireProjectile();
        player2.GetComponent<launcher>().ClearTrajectory();
        // Player 2 has finished their turn, switch to player 1
        state = BattleState.PLAYER1TURN;
        player2.GetComponent<launcher>().enabled = false;
        player2.GetComponent<Player2Movement>().enabled = false;
        player1.GetComponent<launcher>().enabled = true;
        player1.GetComponent<PlayerMovement>().enabled = true;
    }

}

// using UnityEngine;
// using UnityEngine.SceneManagement;
//
// public enum BattleState { START, PLAYER1TURN, PLAYER2TURN }
//
// public class BattleSystem : MonoBehaviour
// {
//     public GameObject player1;
//     public GameObject player2;
//
//     public BattleState state;
//
//     private Vector3 player1StartPosition;
//     private Vector3 player2StartPosition;
//
//     private launcher player1Launcher;
//     private PlayerMovement player1Movement;
//     private launcher player2Launcher;
//     private Player2Movement player2Movement;
//
//     void OnSceneLoaded()
//     {
//         Destroy(player1);
//         Destroy(player2);
//     }
//
//     void Start()
//     {
//         state = BattleState.START;
//
//         player1 = GameObject.Find("Player1");
//         player2 = GameObject.Find("Player2");
//
//         // Cache the components
//         player1Launcher = player1.GetComponent<launcher>();
//         player1Movement = player1.GetComponent<PlayerMovement>();
//         player2Launcher = player2.GetComponent<launcher>();
//         player2Movement = player2.GetComponent<Player2Movement>();
//         Debug.Log("Battlesystem " + player2Movement.name + " " + SceneManager.GetActiveScene().name);
//
//
//         // Enable/disable components
//         player1Launcher.enabled = true;
//         player1Movement.enabled = true;
//         player2Launcher.enabled = false;
//         player2Movement.enabled = false;
//
//
//         // Subscribe to collision event
//         ProjectileCollision.OnCollision += HandleCollision;
//         launcher.OnProjectileFired += HandleThrow;
//         GameManager.OnChangeScene += OnSceneLoaded;
//
//         state = BattleState.PLAYER1TURN;
//     }
//
//     void HandleThrow()
//     {
//         if (state == BattleState.PLAYER1TURN)
//         {
//             player1Launcher.enabled = false;
//         }
//         else if (state == BattleState.PLAYER2TURN)
//         {
//             player2Launcher.enabled = false;
//         }
//     }
//
//     void HandleCollision()
//     {
//         if (state == BattleState.PLAYER1TURN)
//         {
//             player1Movement.enabled = false;
//             player2Movement.enabled = true;
//             player2Launcher.enabled = true;
//             state = BattleState.PLAYER2TURN;
//         }
//         else if (state == BattleState.PLAYER2TURN)
//         {
//             player2Movement.enabled = false;
//             player1Movement.enabled = true;
//             player1Launcher.enabled = true;
//             state = BattleState.PLAYER1TURN;
//         }
//     }
// }
