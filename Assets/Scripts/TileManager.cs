using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];
    public Text swordScoreText;
    public Text shieldScoreText;
    public GameObject resetButton;
    public GameObject quitButton;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        swordScoreText = GameObject.Find("ScoreTextSword").GetComponent<Text>();
        shieldScoreText = GameObject.Find("ScoreTextShield").GetComponent<Text>();
        resetButton = GameObject.Find("Button-Reset");
        quitButton = GameObject.Find("Button-Quit");
        resetButton.SetActive(false); //When game starts, the reset and quit buttons are set to be invisible
        quitButton.SetActive(false);
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner()
    {
        //Check if current player owns three squares horizontally 
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        //Check if current player owns three squares vertically
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        //Check if current player owns three squares diagonally 
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            if (CurrentPlayer == Owner.Sword)
            {
                swordScoreText.GetComponent<score_controller>().swordScore += 1; //Increase Sword's score by 1
                swordScoreText.GetComponent<score_controller>().UpdateSwordScore(); //Update the sword text on the top of the screen
            }

            else
            {
                shieldScoreText.GetComponent<score_controller>().shieldScore += 1; //Increase Shield's score by 1
                shieldScoreText.GetComponent<score_controller>().UpdateShieldScore(); //Update the shield text on the top of the screen
            }

            resetButton.SetActive(true); //Make the reset and quit buttons visible now that someone has won
            quitButton.SetActive(true);
            Debug.Log("Winner: " + CurrentPlayer);
            return true;
        }

        return false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting...");
    }

    public void Reset()
    {
        CurrentPlayer = Owner.None;
        if (CurrentPlayer == Owner.None)
        {
            Tiles[0].ResetTile(); //Reset all the tiles to have no owner
            Tiles[1].ResetTile();
            Tiles[2].ResetTile();
            Tiles[3].ResetTile();
            Tiles[4].ResetTile();
            Tiles[5].ResetTile();
            Tiles[6].ResetTile();
            Tiles[7].ResetTile();
            Tiles[8].ResetTile();
            Start(); //Resart the game board
        }

    }
    
}
