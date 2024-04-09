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
        player2.GetComponent<launcher>().enabled = false;
        player2.GetComponent<Player2Movement>().enabled = false;
        player1.GetComponent<launcher>().enabled = true;
        player1.GetComponent<PlayerMovement>().enabled = true;
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
