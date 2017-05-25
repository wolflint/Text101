using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, freedom};
    private States myState;
    
    // Use this for initialization
	void Start () {
        myState = States.cell;
    }
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if (myState == States.cell) {cell();} 
        else if (myState == States.sheets_0) {sheets_0();}
        else if (myState == States.mirror) {mirror();}
        else if (myState == States.lock_0)
        {
            lock_0();
        }
        else if (myState == States.cell_mirror)
        {
            cell_mirror();
        }
        else if (myState == States.sheets_1)
        {
            sheets_1();
        }
        else if (myState == States.lock_1)
        {
            lock_1();
        }
        else if (myState == States.corridor_0)
        {
            freedom();
        }
	}

    void cell ()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n\n" +
                    "Press S to view Sheets.\n M to view Mirror or\n L to view the Lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.mirror;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_0;
        }
    }

    void sheets_0 ()
    {
        text.text = "These sheets are stained and smell really bad. " +
                    "You can't believe that you have to sleep in these sheets. \n\n" +
                    "Press R to Return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }
    void mirror()
    {
        text.text = "The old mirror on the wall is loose. It might be usefull. \n\n" +
                    "Press T to Take.\n" +
                    "Press R to Return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.cell_mirror;
        }
    }
    void lock_0()
    {
        text.text = "It's a button combination lock. You have no idea which buttons to press." +
                    "If only you could find a way to see the dirty fingerprints on the buttons. \n\n" +
                    "Press R to Return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    void cell_mirror()
    {
        text.text = "You're still in your cell, and you still want to escape. " +
                    "You're holding a mirror, it might be useful. \n\n" +
                    "Press S to view Sheets.\n Press L to view the Lock.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_1;
        }
    }
    void lock_1()
    {
        text.text = "You can probably use the mirror to help you see the buttons.\n\n " +
                    "Press O to try to Open the lock.\n Press R to Return.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.corridor_0;
        }
    }
    void sheets_1()
    {
        text.text = "The sheets look mirrored when you look at them through the mirror.\n\n Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
    }

    void freedom()
    {
        text.text = "You're out of the cell. There is a set of stairs on the left and a closet on the right";
    }
}
