using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;


public class PawnsScript : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;

    public SpriteRenderer[] sprites;
    public TextMesh[] coordTexts;
    public GameObject[] leds;
    public GameObject[] arrowLeds;
    public Sprite[] pieceIcons;
    public Material[] ledColors;

    public KMSelectable leftButton, rightButton, captureButton, passButton;


    public int[,] chessboard = new int[8, 8] { { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1 } };
    
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    private List<int> allNumbers, numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63 };
    //This above list is taken from wikipedia, an untrustworthy source. There may be non-numbers within this list. Please refer to ktane.timwi.de/HTML/Number%20Checker.html for further information

    void Awake ()
    {
        moduleId = moduleIdCounter++;
        leftButton.OnInteract += delegate () { ArrowPress(-1); return false; };
        rightButton.OnInteract += delegate () { ArrowPress(1); return false; };
        captureButton.OnInteract += delegate () { SubmitPress(true); return false; };
        
    }

    void Start ()
    {
        int[] snletters = Bomb.GetSerialNumberLetters().Select(x => (x - 'A') % 8).ToArray();
        int[] snnumbers = Bomb.GetSerialNumberNumbers().Select(x => (x + 7) % 8).ToArray();
        Debug.Log(snletters.Join());
        Debug.Log(snnumbers.Join());
        for (int i = 0; i < Math.Min(snletters.Count(), snnumbers.Count()); i++)
        {
            chessboard[snnumbers[i], snletters[i]] = (int)PieceNames.Blocker;
            Debug.LogFormat("[Pawns #{0}] Blocker placed at {1}{2}.", moduleId, "ABCDEFGH"[snletters[i]], snnumbers[i] + 1);
        }
    }

    void ArrowPress(int offset)
    {

    }

    void SubmitPress(bool input)
    {

    }

    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} to do something.";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand (string Command) {
      yield return null;
    }

    IEnumerator TwitchHandleForcedSolve () {
      yield return null;
    }
}
