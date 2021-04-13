using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonopolyNamespace{
    public class Monopoly : MonoBehaviour
    {

        static BoardSpace[] boardSpaces = new BoardSpace[40];

        static ModifierCard[] chanceCards = new ModifierCard[16];

        static ModifierCard[] communityChestCards = new ModifierCard[16];

        static List<Player> playerList = new List<Player>();

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

        static void setChance()
        {
            chanceCards[0] = new ModifierCard("chance", "Advance to GO", "moveTo00");
            chanceCards[1] = new ModifierCard("chance", "Advance to Illinois Avenue. If you pass GO collect $200", "moveTo24");
            chanceCards[2] = new ModifierCard("chance", "Advance to St. Charles Place If you pass GO collect $200", "moveTo16");
            chanceCards[3] = new ModifierCard("chance", "Advance token to the nearest Utility. If unowned, you may buy it from the Bank.\n If owned, throw dice and pay owner a total of 10 times the amount thrown.", "moveToUT");
            chanceCards[4] = new ModifierCard("chance", "Advance to the nearest Railroad. If unowned, you may buy it from the Bank.\n If owned, pay owner twice the rental to which they are otherwise entitled.", "moveToRR");
            chanceCards[5] = new ModifierCard("chance", "Bank pays you a dividend of $50", "add+050");
            chanceCards[6] = new ModifierCard("chance", "Get out of Jail free", "gooj");
            chanceCards[7] = new ModifierCard("chance", "Go Back 3 Spaces", "index-3");
            chanceCards[8] = new ModifierCard("chance", "Go To Jail-Go directly to Jail-Do not pass GO, do not collect $200", "jail");
            chanceCards[9] = new ModifierCard("chance", "Make general repairs on all your property: For each house pay $25, For each hotel pay $100", "generalRepair");
            chanceCards[10] = new ModifierCard("chance", "Pay poor tax of $15", "add-015");
            chanceCards[11] = new ModifierCard("chance", "Take a trip to Reading Railroad. If you pass GO, collect $200", "moveTo05");
            chanceCards[12] = new ModifierCard("chance", "Take a walk on the Boardwalk. Advance token to Boardwalk", "moveTo39");
            chanceCards[13] = new ModifierCard("chance", "You have been elected Chairman of the Board. Pay each player $50", "payPlayers");
            chanceCards[14] = new ModifierCard("chance", "Your building and loan matures. Collect $150", "add+150");
            chanceCards[15] = new ModifierCard("chance", "You have won a crossword competition. Collect $100", "add+100");
            shuffleCards(chanceCards);
        }

        static void setCommunityChest()
        {
            communityChestCards[0] = new ModifierCard("communityChest", "Advance to GO", "moveTo00");
            communityChestCards[1] = new ModifierCard("communityChest", "Bank error in your favor. Collect $200", "add+200");
            communityChestCards[2] = new ModifierCard("communityChest", "Doctor's Fees. Pay $50", "add-050");
            communityChestCards[3] = new ModifierCard("communityChest", "From sale of stock you get $50", "add+050");
            communityChestCards[4] = new ModifierCard("communityChest", "Get out of jail free", "gooj");
            communityChestCards[5] = new ModifierCard("communityChest", "Go To Jail-Go directly to Jail-Do not pass GO, do not collect $200", "jail");
            communityChestCards[6] = new ModifierCard("communityChest", "Grand Opera Night. Collect $50 from every player for opening night seats", "playersPay50");
            communityChestCards[7] = new ModifierCard("communityChest", "Holiday Fund Matures. Receive $100", "add+100");
            communityChestCards[8] = new ModifierCard("communityChest", "Income tax refund. Collect $20", "jail");
            communityChestCards[9] = new ModifierCard("communityChest", "You inherit $100", "add+100");
            communityChestCards[10] = new ModifierCard("communityChest", "Life insurances matures - Collect $100", "add+100");
            communityChestCards[11] = new ModifierCard("communityChest", "Hospital Fees - Pay $50", "add-050");
            communityChestCards[12] = new ModifierCard("communityChest", "School fees. Pay $50", "add-050");
            communityChestCards[13] = new ModifierCard("communityChest", "Receive $25 consultancy fee", "add+25");
            communityChestCards[14] = new ModifierCard("communityChest", "You are assessed for street repairs: For each house pay $40, For each hotel pay $115", "streetRepair");
            communityChestCards[15] = new ModifierCard("communityChest", "You have won second prize in a beauty contest. Collect $10", "add+010");
            shuffleCards(communityChestCards);
        }

        //Standard shuffle algorithm
        static void shuffleCards(ModifierCard[] deck)
        {
            System.Random r = new System.Random();

            for(int i = 0; i < deck.Length; i++)
            {

                int j = r.Next(i, deck.Length);
                ModifierCard tmp = deck[i];
                deck[i] = deck[j];
                deck[j] = tmp;

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

        //Roll a single 6-sided die
        static int roll()
        {
            System.Random r = new System.Random();

            int die = r.Next(1, 6);

            return die;
        }

        static void playerRoll(Player currentPlayer)
        {
            bool rolledDouble = true;
            int doubleCount = 0;
            //turn
            while (rolledDouble)
            {
                //Rolls
                int die1 = roll();
                int die2 = roll();
                int total = die1 + die2;
                if(die1 != die2)
                {
                    rolledDouble = false;
                }
                else
                {
                    doubleCount++;
                    //Go to jail on third double in a row
                    if (doubleCount == 3)
                    {
                        currentPlayer.setCurrentSpace(10);
                        currentPlayer.setJailStatus(true);
                        break;
                    }
                }

                //Move Player
                int spacesMoved = 0;
                while(spacesMoved < total)
                {
                    spacesMoved++;//Move forward one space

                    //Reset from 40 to 0 (player gets to 'GO')
                    if(currentPlayer.getSpace() == 40)
                    {
                        currentPlayer.setCurrentSpace(0);
                        currentPlayer.setMoney(currentPlayer.getMoney() + 200);
                    }
                }

                //Player lands on space
                BoardSpace space = boardSpaces[currentPlayer.getSpace()];

                //Space is a property
                if (space.getCost() > 0)
                {
                    //If space is unowned
                    if(space.getOwner() == null)
                    {
                        if(space.getCost() > currentPlayer.getMoney())
                        {
                            //Player does not have enough money to buy the property
                            //TODO - Player mortgages, sells houses to afford property (unlikely - but possible)
                            continue;
                        }
                        else
                        {
                            //TODO - Method to Prompt Player to Buy y/n + add player to property owner + remove cash from player
                        }

                    }
                    //If space is owned (not by current player)
                    else if(space.getOwner() != currentPlayer)
                    {
                        int rent = getRent(space.getSpaceNumber(), total);

                        //Pay owner if enough money is owned by current player
                        if((currentPlayer.getMoney() - rent) >= 0)
                        {
                            currentPlayer.setMoney(currentPlayer.getMoney() - rent);
                            space.getOwner().setMoney(space.getOwner().getMoney() + rent);
                        }
                        else
                        {
                            //TODO - Player mortgages, sells houses, or forfeit all to owner
                        }
                        
                    }
                }
                //Space is Chance, Community Chest, Tax Spot, or Corner
                else
                {
                    //Chance
                    if(space.getSpaceNumber() == 7 || space.getSpaceNumber() == 22 || space.getSpaceNumber() == 36)
                    {
                        //TODO - Modifier check on chance cards
                    }
                    //Community Chest
                    else if(space.getSpaceNumber() == 2 || space.getSpaceNumber() == 17 || space.getSpaceNumber() == 33)
                    {
                        //TODO - modifier check on community chest cards
                    }
                    //Income Tax
                    else if(space.getSpaceNumber() == 4)
                    {
                        //10% or 200
                        int percent = System.Convert.ToInt32(currentPlayer.getMoney() * 0.1);
                        int tax = 200;
                        if(percent < 200)
                        {
                            tax = percent;
                        }
                        currentPlayer.setMoney(currentPlayer.getMoney() - tax);
                    }
                    //Luxury Tax
                    else if(space.getSpaceNumber() == 38)
                    {
                        currentPlayer.setMoney(currentPlayer.getMoney() - 75);
                    }
                    //Else if Go To Jail
                    else if (space.getSpaceNumber() == 30)
                    {
                        currentPlayer.setCurrentSpace(10);
                        currentPlayer.setJailStatus(true);
                        break;
                    }
                }
                
            }
            

            
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

