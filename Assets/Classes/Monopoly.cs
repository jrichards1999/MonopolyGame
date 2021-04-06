using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonopolyNamespace{
    public class Monopoly : MonoBehaviour
    {

        static BoardSpace[] boardSpaces = new BoardSpace[40];
        //TODO - List of Chance + Community Chest Cards

        //Initialize each property/space of game board boardSpaces[]
        static void populateBoard()
        {
            boardSpaces[0] = new BoardSpace("Go", 0);
            boardSpaces[1] = new BoardSpace("Mediterranean Avenue", 60);
            boardSpaces[2] = new BoardSpace("Community Chest", 0);
            boardSpaces[3] = new BoardSpace("Baltic Avenue", 60);
            boardSpaces[4] = new BoardSpace("Income Tax", 0);
            boardSpaces[5] = new BoardSpace("Reading Railroad", 200);
            boardSpaces[6] = new BoardSpace("Oriental Avenue", 100);
            boardSpaces[7] = new BoardSpace("Chance", 0);
            boardSpaces[8] = new BoardSpace("Vermont Avenue", 100);
            boardSpaces[9] = new BoardSpace("Connecticut Avenue", 120);
            boardSpaces[10] = new BoardSpace("Jail", 0);
            boardSpaces[11] = new BoardSpace("St. Charles Place", 140);
            boardSpaces[12] = new BoardSpace("Electric Company", 150);
            boardSpaces[13] = new BoardSpace("States Avenue", 140);
            boardSpaces[14] = new BoardSpace("Virginia Avenue", 160);
            boardSpaces[15] = new BoardSpace("Pennsylvania Railroad", 200);
            boardSpaces[16] = new BoardSpace("St. James Place", 180);
            boardSpaces[17] = new BoardSpace("Community Chest", 0);
            boardSpaces[18] = new BoardSpace("Tennessee Avenue", 180);
            boardSpaces[19] = new BoardSpace("New York Avenue", 200);
            boardSpaces[20] = new BoardSpace("Free Parking", 0);
            boardSpaces[21] = new BoardSpace("Kentucky Avenue", 220);
            boardSpaces[22] = new BoardSpace("Chance", 0);
            boardSpaces[23] = new BoardSpace("Indiana Avenue", 220);
            boardSpaces[24] = new BoardSpace("Illinois Avenue", 240);
            boardSpaces[25] = new BoardSpace("B. & O. Railroad", 200);
            boardSpaces[26] = new BoardSpace("Atlantic Avenue", 260);
            boardSpaces[27] = new BoardSpace("Ventnor Avenue", 260);
            boardSpaces[28] = new BoardSpace("Water Works", 150);
            boardSpaces[29] = new BoardSpace("Marvin Gardens", 280);
            boardSpaces[30] = new BoardSpace("Go To Jail", 0);
            boardSpaces[31] = new BoardSpace("Pacific Avenue", 300);
            boardSpaces[32] = new BoardSpace("North Carolina Avenue", 300);
            boardSpaces[33] = new BoardSpace("Community Chest", 0);
            boardSpaces[34] = new BoardSpace("Pennsylvania Avenue", 320);
            boardSpaces[35] = new BoardSpace("Short Line", 200);
            boardSpaces[36] = new BoardSpace("Chance", 0);
            boardSpaces[37] = new BoardSpace("Park Place", 350);
            boardSpaces[38] = new BoardSpace("Luxury Tax", 0);
            boardSpaces[39] = new BoardSpace("Boardwalk", 400);
        }

        //Assign index parameter of each space on board
        static void setIndexes()
        {
            for(int i = 0; i < 40; i++)
            {
                boardSpaces[i].setSpaceNumber(i);
            }
        }

        //Calculate how much a player owes the owner of a property by the index (space) they land on and the roll that got them there (for utilities)
        static int getRent(int index, int roll)
        {
            BoardSpace current = boardSpaces[index];
            int rent = 0;

            //If space landed on is a railroad
            if(index == 5 || index == 15 || index == 25 || index == 35)
            {
                rent = railsFee(index);
            }
            //If space landed on is utility
            else if(index == 12 || index == 28)
            {
                if (hasMonopoly(index))
                {
                    rent = 10 * roll;
                }
                else
                {
                    rent = 4 * roll;
                }
            }
            //If space landed on is standard property
            else
            {
                if (hasMonopoly(index) && !current.hasHouses())
                {
                    rent = 2 * current.getRent();
                }
                else
                {
                    rent = current.getRent();
                }
            }

            return rent;
        }

        //Check ownership status of each property required for monopoly by index
        static bool hasMonopoly(int index)
        {
            BoardSpace current = boardSpaces[index];
            //Brown Properties
            if (current.getSpaceNumber() == 1 || current.getSpaceNumber() == 3)
            {
                if(boardSpaces[1].getOwner() == boardSpaces[3].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Light Blue Properties
            else if (current.getSpaceNumber() == 6 || current.getSpaceNumber() == 8 || current.getSpaceNumber() == 9)
            {
                if (boardSpaces[6].getOwner() == boardSpaces[8].getOwner() && boardSpaces[8].getOwner() == boardSpaces[9].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Purple Properties
            else if (current.getSpaceNumber() == 11 || current.getSpaceNumber() == 13 || current.getSpaceNumber() == 14)
            {
                if (boardSpaces[11].getOwner() == boardSpaces[13].getOwner() && boardSpaces[13].getOwner() == boardSpaces[14].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Utilities
            else if(current.getSpaceNumber() == 12 || current.getSpaceNumber() == 28)
            {
                if (boardSpaces[12].getOwner() == boardSpaces[28].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Orange Properties
            else if (current.getSpaceNumber() == 16 || current.getSpaceNumber() == 18 || current.getSpaceNumber() == 19)
            {
                if (boardSpaces[16].getOwner() == boardSpaces[18].getOwner() && boardSpaces[18].getOwner() == boardSpaces[19].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Red Properties
            else if (current.getSpaceNumber() == 21 || current.getSpaceNumber() == 23 || current.getSpaceNumber() == 24)
            {
                if (boardSpaces[21].getOwner() == boardSpaces[23].getOwner() && boardSpaces[23].getOwner() == boardSpaces[24].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Yellow Properties
            else if (current.getSpaceNumber() == 26 || current.getSpaceNumber() == 27 || current.getSpaceNumber() == 29)
            {
                if (boardSpaces[26].getOwner() == boardSpaces[27].getOwner() && boardSpaces[27].getOwner() == boardSpaces[29].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Green Properties
            else if (current.getSpaceNumber() == 31 || current.getSpaceNumber() == 32 || current.getSpaceNumber() == 34)
            {
                if (boardSpaces[31].getOwner() == boardSpaces[32].getOwner() && boardSpaces[32].getOwner() == boardSpaces[34].getOwner())
                {
                    return true;
                }
                return false;
            }
            //Dark Blue Properties
            else if (current.getSpaceNumber() == 37 || current.getSpaceNumber() == 39)
            {
                if (boardSpaces[37].getOwner() == boardSpaces[39].getOwner())
                {
                    return true;
                }
                return false;
            }


            return false;
        }

        //Check which rails are owned by the owner of the rail at index to get total cost
        static int railsFee(int index)
        {
            int fee = 0;
            int railCount = 0;
            List<BoardSpace> railroads = new List<BoardSpace>();
            railroads.Add(boardSpaces[5]);
            railroads.Add(boardSpaces[15]);
            railroads.Add(boardSpaces[25]);
            railroads.Add(boardSpaces[35]);

            foreach(BoardSpace property in railroads)
            {
                if(boardSpaces[index].getOwner() == property.getOwner())
                {
                    railCount++;
                }
            }

            switch (railCount)
            {
                case 1:
                    fee = 25;
                    break;
                case 2:
                    fee = 50;
                    break;
                case 3:
                    fee = 100;
                    break;
                case 4:
                    fee = 200;
                    break;
            }

            return fee;
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

