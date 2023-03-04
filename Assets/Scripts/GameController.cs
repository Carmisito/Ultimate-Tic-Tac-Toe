using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace tic_tac_toe
{
    public static class Globals
    {
        //GLOBALS
        public static CheckState cs = new CheckState();

        public static int turn_Indicator;  //0 = O, 1 = X
        public static int turn_Counter;    //counts the number of turns played
        public static short mask;
        public static short tied_grids;
        public static GameObject[] turn_Icons; //displays who's turn it is
        public static GameObject[] grids; //all the 9 grids on the board (the 9 smaller boards inside the big one
        public static GameObject[] canvases;
        public static Sprite[] icons;   //0 = O icon, 1 = X icon
        public static Button[] spaces;     //playable space
        public static Button end_Button;
        public static Text[] texts;
        public static Button music;
        public static bool[] deactivated_Buttons; // keeps track of which buttons were deactivated
        public static bool[] deactivated_Grids;
        public static short[] bitBoardX;
        public static short[] bitBoardO;
        public static short[] answer_Board;
        public static int ai_Button; //the button the ai pressed
        public static int next_Board; //the next board we're playing in
        public static int ai_Depth;
        public static bool ai_activated;
        public static float volume = 0.6f;
        public static int min_Depth_For_Transposition = 4; //what's the minimum depth in a searched position in order to be entered to the transposition table
        public static int starting_Depth_For_AI = 9; //the starting depth for the ai that will change according to certain parameters
        public static long temp_Counter = 0;
        public static bool is_Transposition;
        public static int Last_AI_Button = -1;

        public static Dictionary<Int64, Map_Value> transposition = new Dictionary<Int64, Map_Value>();

        //Pre-Generated Random values for:
        //2*81 for each square
        public static Int64[] square_Zobrist_Keys =
        {
        9040802992367411000, -4299625015241416700,
        -2679412360962101000, 1463894427821969400,
        1131153973409116200, -848543936278335500,
        -2913790743177060400, -6962416265436488000,
        8786834877366485000, -2397038678002000000,
        -8362500324339470000, 5060766643654631000,
        -5996735628547174000, -4494117617428107300,
        5460572492468638000, -2047851756290781200,
        -2536389438928396300, -7876860571026285000,
        1438116806269878300, -4578221096567197700,
        -5360891332419584, 7378871749064856000,
        -9176625041175515000, 5030673877646660000,
        5910045935749087000, -1309408104323555300,
        3542135805489975300, 1064468994637135900,
        -7209951715432382000, 3181847068334661600,
        -7637373459728122000, 7633089635313730000,
        8820574100385112000, 1858684378803224600,
        -1308180633262817300, -119796380918411260,
        3899769332148326400, 4294861620184150000,
        1802928519510102000, -7675119684045476000,
        8880273049554174000, -6731628438874333000,
        -8556778471533490000, 7513124236946645000,
        -8350500216674697000, -8211041075981894000,
        4455371723598074000, 3528248970409656300,
        8624703894824374000, 5861701973102809000,
        5790630055988064000, 5431760416029544000,
        2011772983611097000, 2043343493545238500,
        6753117669643227000, -4439958771577155600,
        4814277349821592000, -173438643683123200,
        1611722073731010600, 791069621109809200,
        -567699607832883600, -544777038538283400,
        -6446941740651545000, -6902750583994368000,
        7692267836540281000, 3654747790856421400,
        5039776491194122000, -6244597984324276000,
        -8479331006871257000, 2079223124968902700,
        -3418051145387610000, -6357849966321279000,
        -5067556944619483000, -8557270448234488000,
        -3629302391727939600, -4080855391092199400,
        2824913413382258700, 1131713107300896800,
        2530921555417567000, -844144503048495100,
        -4323452300069368000, 5931088949480313000,
        4742375987747197000, 6004772017894629000,
        -5691555458602615000, -9183717379908284000,
        -8015172614315180000, -4372654745134391300,
        3739750925300912000, -4922564896904983000,
        -8376442795896513000, -7526464326265319000,
        -59083411788935170, -4811047063905939000,
        2529725581810876400, -1104413687425380400,
        7407319243857441000, 8819196176877335000,
        -5713103185890988000, 2973497608505921500,
        -8151475980742545000, -8654150214954693000,
        -2165407835636646000, -7072892563114402000,
        -5958338906395062000, -4512979462739050500,
        -4132705744757498000, 2455994156379992000,
        1423070201546948600, 4677408376650707000,
        -584551209696890900, -6994483578878603000,
        3415762310906310700, 8150798231103680000,
        -6816829856462848000, -9086072536287785000,
        -676985284476682200, -7416544987549434000,
        9021792274355442000, -3659467402741014500,
        1110915448843685900, 1912307531429302300,
        4978454747953156000, 2627363021331079000,
        -3173681178459308000, -1505618109589811200,
        2938996953334526000, -2477268260530098000,
        6186349049160516000, 8356451771176669000,
        7637724324376449000, -6845094116768899000,
        6772872997059166000, -1620524071294546000,
        8028987494547730000, 4238201942834901000,
        3174902515214692400, 671672038088433700,
        -708790490580602900, 944222672249921500,
        1070320597396660200, -1798299205721751600,
        4853526378711327000, 7434219514122756000,
        930200134369112000, -2249982179884191700,
        -4168483801952821000, -572737852534456300,
        2085037981056348200, 7551235840018899000,
        5212226576922223000, 6388316574767174000,
        -565518509575491600, -6625194555716837000,
        -4899303680148664000, 8865397159641588000,
        8269431041474298000, 2812437838133551000,
        -650515679085826000, 1211099421295530000,
        8666488552389333000, 8303478066874343000,
        4364356
    };

        //3*9 for X, O, and draw on the big board
        public static Int64[] grids_Zobrist_Keys =
        {
        -878553528732033000, -3912500624197374000, 3664542645771530000,
        8438997113101877000, 7410852106968441000, 8621006748005663000,
        -7927281689704137000, -359003305715429400, -6171194602844553000,
        7704236080639005000, 4001712496364695600, 1467934605376958500,
        1709996372957347800, 5072253949321155000, -2373503510773317600,
        1873096918892753000, 1659427219121553400, 889983392963903500,
        -5576898968670224000, -3053978476594962400, 5265259213452296000,
        6387480040720204000, -3330532999698968600, 2872446967737303000,
        -5880458901744226000, 1314770192097357800, 5757476128560067000
    };

        //10 numbers to represent the current board we're in (number 10 is all of them)
        public static Int64[] current_Board_Zobrist_Keys =
        {
        925364094464602100,
        2573000150945308700,
        -5161908512923501000,
        -8071391437362172000,
        2460856791243997000,
        1106130414907658200,
        629487423907713000,
        -5669849931081482000,
        6052400486536958000,
        1343606772696760300
    };

        //two random numbers to represent who's playing
        public static Int64[] playing =
        {
        1864167446884241400, -5622288180494594000
        };


        //Name: GameSetup
        //General: this function sets up a new game
        //Parameters: None
        //returns: nothing
        //complexity: O(1) - The number of places to reset is always 81
        public static void GameSetup()
        {
            //initialize vars
            int i = 0;
            bitBoardX = new short[10]; //initializes the bit boards
            bitBoardO = new short[10]; //initializes the bit boards
            answer_Board = new short[9]; //the heuristic value for each square
            deactivated_Buttons = new bool[81];
            deactivated_Grids = new bool[9];
            mask = 1; //initializes the mask
            ai_Depth = 7;
            next_Board = -1; //-1 means that all boards are active
            turn_Indicator = 1; // X gets the first turn
            turn_Counter = 0; //resets the turn counter
            turn_Icons[1].SetActive(true); //set the X indicator as active
            turn_Icons[0].SetActive(false); //set the O indicator as false
            ai_Button = -1;
            min_Depth_For_Transposition = 7;
            starting_Depth_For_AI = 8;
            is_Transposition = false;
            Last_AI_Button = -1;
            //--------------------------------------------------------------------------------------------------------------------------------
            //resets all of the buttons
            for (i = 0; i < spaces.Length; i++)
            {
                spaces[i].interactable = true;
                spaces[i].GetComponent<Image>().sprite = null;
            }

            //--------------------------------------------------------------------------------------------------------------------------------
            //reset the bit boards
            for (i = 0; i < bitBoardX.Length; i++) //initializes the bit boards
            {
                bitBoardX[i] = 0;
                bitBoardO[i] = 0;
            }

            //reset the images for the grids
            for (i = 0; i < grids.Length; i++)
            {
                grids[i].GetComponent<Image>().sprite = icons[2];
            }

            for (i = 0; i < spaces.Length; i++)
            {
                spaces[i].GetComponent<Image>().sprite = icons[3];
            }

            //--------------------------------------------------------------------------------------------------------------------------------
            //turns the first screen on and disables the rest

            canvases[0].SetActive(true);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);

            texts[1].gameObject.SetActive(false);

        }

        
        
    }
    


    public class Map_Value
    {
        private int eval;
        private int depth;

        public Map_Value(int eval, int depth)
        {
            this.eval = eval;
            this.depth = depth;
        }

        //Name: get_Eval
        //General: Returns eval
        //Parameters: None
        //Returns: The Saved eval
        //Complexity: O(1)
        public int get_Eval()
        {
            return this.eval;
        }

        //Name: set_Eval
        //General: Sets the eval
        //Parameters: int eval - The new value for the eval
        //Returns: Nothing
        //Complexity O(1)
        public void set_Eval(int eval)
        {
            this.eval = eval;
        }

        //Name: get_Depth
        //General: Returns depth
        //Parameters: None
        //Returns: The Saved depth
        //Complexity: O(1)
        public int get_Depth()
        {
            return this.depth;
        }
        //Name: set_Depth
        //General: Sets the depth
        //Parameters: int depth - The new value for the depth
        //Returns: Nothing
        //Complexity O(1)
        public void set_Depth(int depth)
        {
            this.depth = depth;
        }
    }




    public class UI
    {
        protected AI ai;
        protected Board board;
        public UI(AI ai, Board board)
        {
            this.ai = ai;
            this.board = board;
        }


        //Name: start_Button_Pressed
        //General: This function is called whenever one of the menu buttons gets pressed and moves us to the correct screen
        //Parameters: int number_Of_Button - the number represents the button that was pressed
        //Returns: Nothing
        //complexity: O(1)
        public void start_Button_Pressed(int number_Of_Button)
        {
            //starts the correct screen
            if (number_Of_Button == 0 || number_Of_Button == 5 || number_Of_Button == 6)
            {
                Globals.canvases[1].SetActive(true);
                Globals.canvases[0].SetActive(false);
            }


            if (number_Of_Button == 2)
                Globals.GameSetup();
            if (number_Of_Button == 3)
            {
                Globals.canvases[1].SetActive(true);
                Globals.canvases[2].SetActive(false);
                Globals.end_Button.gameObject.SetActive(true);
                board.deactivate_Boards(-2);
            }

            if (number_Of_Button == 4)
            {
                Globals.canvases[2].SetActive(true);
                Globals.canvases[1].SetActive(false);
                Globals.end_Button.gameObject.SetActive(false);
            }

            if (number_Of_Button == 5)
                Globals.ai_activated = true;
            else if (number_Of_Button == 6)
            {
                Globals.ai_activated = true;
                //turn the pressed button to an image of an X or an O and deactivate it
                Globals.spaces[37].image.sprite = Globals.icons[Globals.turn_Indicator];
                Globals.deactivated_Buttons[37] = true; //keep track of which buttons were deactivated
                board.button_Played(37);
                board.deactivate_Boards(1); //deactivate all the boards we're not playing at
                Globals.turn_Icons[Math.Abs(Globals.turn_Indicator - 1)].SetActive(true); //set the other indicator as active
                Globals.turn_Icons[Globals.turn_Indicator].SetActive(false); //set the current indicator as false
                Globals.turn_Indicator = Math.Abs(Globals.turn_Indicator - 1); //flip the turn indicator
            }
            else
                Globals.ai_activated = false;
        }


        //Name: Sound_Pressed
        //General: when the sound button is pressed we need to activate or deactivate the sound
        //Parameters: None
        //Returns: Nothing
        //Complexity: O(1)
        public void Sound_Pressed()
        {
            if (AudioListener.volume == 0)
            {
                AudioListener.volume = Globals.volume;
                Globals.music.image.sprite = Globals.icons[7];
                return;
            }
            AudioListener.volume = 0;
            Globals.music.image.sprite = Globals.icons[8];
        }

        //Name: Button_Pressed
        //General: This function is called every time we press a button on the board and is given the number of the button that was pressed (0 - 80).
        //The function then updates the data structures and the depth for the ai
        //Parameters: int number_Of_Button - the number represents the button that was pressed
        //Returns: Nothing
        //Complexity: O(n^t) when n represents the number of moves and t represents the depth (might call minmax)
        public void Button_Pressed(int number_Of_Button)
        {
            
            //--------------------------------------------------------------------------------------------------------------------------------

            Globals.next_Board = number_Of_Button % 9; //set the next board
            if (Globals.deactivated_Grids[Globals.next_Board] == true) //if the board we are sent to is already solved, then we can play anywhere
                Globals.next_Board = -1;

            //--------------------------------------------------------------------------------------------------------------------------------
            //turn the pressed button to an image of an X or an O and deactivate it
            Globals.spaces[number_Of_Button].image.sprite = Globals.icons[Globals.turn_Indicator];
            Globals.deactivated_Buttons[number_Of_Button] = true; //keep track of which buttons were deactivated

            //--------------------------------------------------------------------------------------------------------------------------------

                
            board.button_Played(number_Of_Button);
            board.deactivate_Boards(Globals.next_Board); //deactivate all the boards we're not playing at

            //--------------------------------------------------------------------------------------------------------------------------------
            //handle the indicator to tell the player who is playing
            Globals.turn_Icons[Math.Abs(Globals.turn_Indicator - 1)].SetActive(true); //set the other indicator as active
            Globals.turn_Icons[Globals.turn_Indicator].SetActive(false); //set the current indicator as false
            Globals.turn_Indicator = Math.Abs(Globals.turn_Indicator - 1); //flip the turn indicator
            //--------------------------------------------------------------------------------------------------------------------------------


            if (Globals.ai_activated)
            {
                ai.update_Depth();
                ai.play_AI();
            }

        }




        
    }




    public class Board
    {
        //Name: finish_Game
        //General: Finishes the game
        //Parameters: None
        //Returns: Nothing
        //Complexity: O(1)
        public void finish_Game()
        {

            //set the winning screen
            Globals.canvases[1].SetActive(false);
            Globals.canvases[2].SetActive(true);

            if (!Globals.cs.Check_Win(Globals.bitBoardX[9]) && !Globals.cs.Check_Win(Globals.bitBoardO[9])) //if neither won
                Globals.texts[0].text = "No one won! It's a tie!";
            else
            {
                Globals.texts[0].text = (Globals.turn_Indicator == 1 ? "X " : "O ") + "IS THE WINNER";
            }
            Debug.Log("Game Over!");
        }



        //Name: win_Grid
        //General: Wins a grid and deactivates it and its buttons
        //Parameters: int grid_Num - represents the number of the grid we want to win
        //Returns: Nothing
        //Complexity: O(1)
        public void win_Grid(int grid_Num)
        {
            int i = 0;
            Globals.deactivated_Grids[grid_Num] = true;
            for (i = grid_Num * 9; i < grid_Num * 9 + 9; i++) //deactivate all of the buttons in the winning board
            {

                Globals.spaces[i].interactable = false;
                if (Globals.deactivated_Buttons[i] == false)
                {
                    Globals.spaces[i].image.sprite = Globals.icons[6]; //set them to be transparent
                    Globals.deactivated_Buttons[i] = true; //keep track of which buttons were deactivated
                    Globals.turn_Counter++;
                }

            }

            Globals.grids[grid_Num].GetComponent<Image>().sprite = Globals.icons[Globals.turn_Indicator]; //change the winning board to a win symbol
        }


        //Name: deactivate_Boards
        //General: deactivates board so the players can only play in their designated areas
        //Parameters: int next_Board - represents the next board we can play in
        //Returns: Nothing
        //Complexity: O(1)
        public void deactivate_Boards(int next_Board)
        {
            int i = 0;

            if (next_Board == -1) //-1 means we can play anywhere
            {
                for (i = 0; i < Globals.deactivated_Buttons.Length; i++)
                {
                    if (Globals.deactivated_Buttons[i] == true)
                        Globals.spaces[i].interactable = false;
                    else
                        Globals.spaces[i].interactable = true;
                }
                return;
            }

            if (next_Board == -2) //if the ai is active then this is the code to disable everything while the ai is thinking
            {
                for (i = 0; i < Globals.deactivated_Buttons.Length; i++)
                {
                    Globals.spaces[i].interactable = false;
                }
                return;
            }


            if (Globals.deactivated_Grids[next_Board]) //if the next board is already deactivated we want to let you play everywhere else
            {
                for (i = 0; i < Globals.deactivated_Buttons.Length; i++)
                {
                    Globals.spaces[i].interactable = false;
                    if (!Globals.deactivated_Buttons[i])
                    {
                        Globals.spaces[i].interactable = true;
                    }
                }
                return;
            }

            for (i = 0; i < Globals.deactivated_Buttons.Length; i++) //if the button isn't in the next board or he is deactivated - then disable it (the regular and most abundant result)
            {
                if (i / 9 != next_Board || Globals.deactivated_Buttons[i])
                    Globals.spaces[i].interactable = false;
                else
                    Globals.spaces[i].interactable = true;
            }
        }


        //Name: button_Played
        //General: when a button is played this function updates the bitboards and finishes the game if need be
        //Parameters: int number_Of_Button - the number represents the button that was pressed
        //returns: Nothing
        //Complexity: O(1)
        public void button_Played(int number_Of_Button)
        {
            int i;
            //the mask turns on the bit in the bit board
            Globals.mask = 1; //resets the mask
            Globals.mask <<= number_Of_Button % 9; //moves the bit to the correct place. 0 means it wont move and stay
            Globals.turn_Counter++; //increases the turn counter

            //--------------------------------------------------------------------------------------------------------------------------------

            if (Globals.turn_Indicator == 0)
                Globals.bitBoardO[number_Of_Button / 9] |= Globals.mask; //light the bit in the bit board using the mask
            else
                Globals.bitBoardX[number_Of_Button / 9] |= Globals.mask; //light the bit in the bit board using the mask

            //--------------------------------------------------------------------------------------------------------------------------------
            Globals.mask = 1;
            Globals.mask <<= number_Of_Button / 9; //moves the bit to the correct place (finds the board that was just played)

            if (Globals.turn_Indicator == 1)
            {
                if (Globals.cs.Check_Win(Globals.bitBoardX[number_Of_Button / 9]))
                {
                    win_Grid(number_Of_Button / 9);
                    Globals.bitBoardX[9] |= Globals.mask;


                    if (Globals.cs.Check_Win(Globals.bitBoardX[9])) //if they won the entire game
                    {
                        finish_Game();
                    }
                }


            }

            else
            {
                if (Globals.cs.Check_Win(Globals.bitBoardO[number_Of_Button / 9]))
                {
                    win_Grid(number_Of_Button / 9);
                    Globals.bitBoardO[9] |= Globals.mask;


                    if (Globals.cs.Check_Win(Globals.bitBoardO[9])) //if they won the entire game
                    {
                        finish_Game();
                    }

                }

            }

            if (Globals.cs.is_Tie(number_Of_Button / 9)) //if the bit board is a tie
            {
                Globals.deactivated_Grids[number_Of_Button / 9] = true;
                Globals.mask = 1;
                Globals.mask <<= number_Of_Button / 9;
                Globals.tied_grids |= Globals.mask;
            }

            for (i = 0; i < Globals.deactivated_Grids.Length; i++) //check if the game ended
            {
                if (!Globals.cs.is_Tie(i) && !Globals.cs.Check_Win(Globals.bitBoardX[i]) && !Globals.cs.Check_Win(Globals.bitBoardO[i]))
                    return;
            }
            finish_Game();
        }
    }




    public class AI
    {
        protected Board board;
        public AI(Board board)
        {
            this.board = board;
        }


        //Name: update_Depth
        //General: As the game progresses, the computational power we allocated to the ai may be underused (or overused).
        //So we update the depth so we optimize our ai to the fullest
        //Parameters: None
        //Returns: Nothing
        //Complexity: O(1)
        public void update_Depth()
        {
            int counter = 0, i = 0;
            Globals.ai_Depth = Globals.starting_Depth_For_AI;
            if (Globals.turn_Counter > 30)
                Globals.ai_Depth++;
            for (i = 0; i < 9; i++)
                if (Globals.deactivated_Grids[i])
                    counter++;
            if(counter == 0 && Globals.turn_Counter > 25)
            {
                Globals.ai_Depth += 2;
                if (Globals.turn_Counter > 35)
                    Globals.turn_Counter += 2;
            }
            if (counter > 0)
                counter--;
            if (counter > 1)
                Globals.ai_Depth--;
            if (counter > 3)
                Globals.ai_Depth += 2;
            if (counter > 4)
                Globals.ai_Depth += 2;
            if (counter > 5)
                Globals.ai_Depth += 4;
        }

        //Name: play_AI
        //General: This function plays a button for the AI
        //Parameters: None
        //Returns: Nothing
        //Complexity: O(n^t) when n represents the number of moves and t represents the depth (calls minmax)
        public void play_AI()
        {
            int i = 0;
            if (Globals.ai_Button != -1)
                Globals.spaces[Globals.ai_Button].image.sprite = Globals.icons[Globals.turn_Indicator]; //remove the highlight

            Globals.Last_AI_Button = Globals.ai_Button;
            board.deactivate_Boards(-2);
            Globals.texts[1].gameObject.SetActive(true);

            Globals.temp_Counter = 0;

            Debug.Log("heuristic: " + heuristic());
            if(Globals.is_Transposition)
                for(i = 0; i < Globals.ai_Depth; i++)
                    Debug.Log("minMax: " + minmax(Globals.next_Board, Globals.ai_Depth, int.MinValue, int.MaxValue, Globals.turn_Indicator == 1 ? true : false));
            else
                Debug.Log("minMax: " + minmax(Globals.next_Board, Globals.ai_Depth, int.MinValue, int.MaxValue, Globals.turn_Indicator == 1 ? true : false));
            Debug.Log($"number of runs: {Globals.temp_Counter}");
            Globals.spaces[Globals.ai_Button].image.sprite = Globals.icons[Globals.turn_Indicator + 4]; //turn the button to a highlighted version
            Globals.deactivated_Buttons[Globals.ai_Button] = true;
            Globals.spaces[Globals.ai_Button].interactable = false;
            board.button_Played(Globals.ai_Button);
            if (Globals.Last_AI_Button == Globals.ai_Button)
                Debug.Log("I didn't play");
            board.deactivate_Boards(Globals.ai_Button % 9); //deactivate all the boards we're not playing at
            Globals.turn_Icons[Math.Abs(Globals.turn_Indicator - 1)].SetActive(true); //set the other indicator as active
            Globals.turn_Icons[Globals.turn_Indicator].SetActive(false); //set the current indicator as false
            Globals.turn_Indicator = Math.Abs(Globals.turn_Indicator - 1); //flip the turn indicator
            Globals.texts[1].gameObject.SetActive(false);
        }


        //Name: number_of_side_squares
        //General: Returns the number of side squares placed for a certain bitBoard
        //Parameters: short board
        //Returns: the the number of side squares placed (int)
        //Complexity: O(1)
        public int number_of_side_squares(short board)
        {
            int amount = 0, i = 0;
            for (i = 2; i <= 128; i *= 4) 
            {
                if ((board & i) == i)
                    amount++;
            }
            return amount;
        }


        //Name: number_of_corner_squares
        //General: Returns the number of corner squares placed for a certain bitBoard
        //Parameters: short board
        //Returns: the the number of corner squares placed (int)
        //Complexity: O(1)
        public int number_of_corner_squares(short board)
        {
            int amount = 0, i = 0;
            for (i = 1; i <= 256; i *= 4)//This loop checks the center since there is no way of reaching all corner sqaures without also checking the middle square
                                         // while it might be more efficient to use 4 IF checks instead of checking the center every time, I refuse to do so out of spite.
            {
                if (i != 16 && (board & i) == i)
                    amount++;
            }
            return amount;
        }


        //Name: heuristic
        //General: Gives an evaluation for a position from int.MaxValue for X to int.MinValue for O
        //Parameters: None
        //Returns: the evaluation (int)
        //Complexity: O(1)
        public int heuristic()
        {
            int answer = 0, i = 0, j = 0;

            if (Globals.cs.Check_Win(Globals.bitBoardX[9]))
                return int.MaxValue; //change to max int
            if (Globals.cs.Check_Win(Globals.bitBoardO[9]))
                return int.MinValue; //min int
            if (Globals.cs.is_Tie(9))
                return 0;

            for (i = 0; i < 9; i++) //go over the 9 small grids
            {
                Globals.mask = 1;
                Globals.mask <<= i;
                if (!Globals.deactivated_Grids[i]) //grids that are no longer active should not have their inner soldiers counted
                {

                    //--------------------------------------------------------------------------------------------------------------------------------
                    //Add 5 for every 2 in a row:
                    //A 2-in-a-row should be more valuable than any one square.

                    answer += number_Of_2_In_A_Row(Globals.bitBoardX[i], Globals.bitBoardO[i]) * 5;
                    answer -= number_Of_2_In_A_Row(Globals.bitBoardO[i], Globals.bitBoardX[i]) * 5;


                    //--------------------------------------------------------------------------------------------------------------------------------
                    //The amount of points alloted to each square is decided by the amount of possible wins that square can offer
                    //add 2 points if you got the center because you're sending your opponent to a valuable grid

                    if ((Globals.bitBoardX[i] & 16) == 16)
                        answer += 2;
                    else if ((Globals.bitBoardO[i] & 16) == 16)
                        answer -= 2;

                    //--------------------------------------------------------------------------------------------------------------------------------
                    //add 3 points if you got the corner squares because you sent the opponent to a neutral value grid

                    answer += number_of_corner_squares(Globals.bitBoardX[i]) * 3;
                    answer -= number_of_corner_squares(Globals.bitBoardO[i]) * 3;

                    //--------------------------------------------------------------------------------------------------------------------------------
                    //add 4 points if you got the side squares because you sent the opponent to a less valuable grid

                    answer += number_of_side_squares(Globals.bitBoardX[i]) * 4;
                    answer -= number_of_side_squares(Globals.bitBoardO[i]) * 4;

                    //--------------------------------------------------------------------------------------------------------------------------------

                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------
            //add 22 points if a grid is won:
            //the maximum number of possible 2-in-a-rows (7) multiplied by the number of points awarded to a 2-in-a-row (3), plus one. Its ALWAYS more valuable to win than create 2-in-a-rows

            answer += number_of_side_squares(Globals.bitBoardX[9]) * 22;
            answer -= number_of_side_squares(Globals.bitBoardO[9]) * 22;

            //--------------------------------------------------------------------------------------------------------------------------------
            //Corner squares have 1.5 times the possible wins a side square has.

            answer += number_of_corner_squares(Globals.bitBoardX[9]) * 33;
            answer -= number_of_corner_squares(Globals.bitBoardO[9]) * 33;

            //--------------------------------------------------------------------------------------------------------------------------------
            //if the center grid is won, double the points (center square is twice as valuable as side squares)
            if ((Globals.bitBoardX[9] & 16) == 16)
                answer += 44;
            else if ((Globals.bitBoardO[9] & 16) == 16)
                answer -= 44;

            //--------------------------------------------------------------------------------------------------------------------------------

            // A 2-in-a-row on the main grid must be worth more than the most valuable grid, so that an unblocked 2-in-a-row is more preferential than a blocked path but with a center square
            answer += number_Of_2_In_A_Row(Globals.bitBoardX[9], (short)(Globals.bitBoardO[9] | Globals.tied_grids)) * 45;
            answer -= number_Of_2_In_A_Row(Globals.bitBoardO[9], (short)(Globals.bitBoardX[9] | Globals.tied_grids)) * 45;

            return answer;
        }



        //Name: number_Of_2_In_A_Row
        //General: counts the amount of active (unblocked) 2 pieces in a rows for a certain board
        //Parameters: short board - the board we are checking
        //short enemy_Board - the enemy board that might block the given board
        //Returns: The number of 2 unblocked pieces in a row
        //Complexity: O(1)
        public int number_Of_2_In_A_Row(short board, short enemy_Board) //if there is a 2 in a row (that isnt blocked) then add to the counter and return
        {
            int i = 0, j = 0, answer = 0, counter = 0;


            for (i = 1; i <= 64; i *= 8) //counts rows
            {
                counter = 0;
                for (j = 1; j <= 4; j *= 2)
                    counter += ((board & (i * j)) != 0 ? 1 : 0) - ((enemy_Board & (i * j)) > 0 ? 1 : 0);
                if (counter == 2)
                    answer++;
            }

            //--------------------------------------------------------------------------------------------------------------------------------

            for (i = 1; i <= 4; i *= 2) //counts collumns
            {
                counter = 0;
                for (j = 1; j <= 64; j *= 8)
                    counter += ((board & (i * j)) != 0 ? 1 : 0) - ((enemy_Board & (i * j)) > 0 ? 1 : 0);
                if (counter == 2)
                    answer++;
            }

            //--------------------------------------------------------------------------------------------------------------------------------

            counter = 0;
            for (j = 1; j <= 256; j *= 16) //counts the upper left to bottom right diagonal
                counter += ((board & (j)) != 0 ? 1 : 0) - ((enemy_Board & (j)) > 0 ? 1 : 0);
            if (counter == 2)
                answer++;

            //--------------------------------------------------------------------------------------------------------------------------------

            counter = 0;
            for (j = 4; j <= 64; j *= 4) //counts the upper right to bottom left diagonal
                counter += ((board & (j)) != 0 ? 1 : 0) - ((enemy_Board & (j)) > 0 ? 1 : 0);
            if (counter == 2)
                answer++;

            //--------------------------------------------------------------------------------------------------------------------------------
            return answer;

        }


        //Name: create_Zobrist_Key
        //General: Creates a unique zobrist key for a position
        //Parameters: int current_Board_Number - Where the next player has to play
        //Returns: The zobrist key (Int64)
        //Complexity: O(1)
        public Int64 create_Zobrist_Key(int current_Board_Number)
        {

            int i = 0;
            short mask = 1;
            Int64 zobrist_Key = 0;
            for (i = 0; i < 81; i++)
            {
                mask = 1;
                mask <<= i % 9;
                zobrist_Key ^= (Globals.bitBoardX[i / 9] & mask) != 0 ? Globals.square_Zobrist_Keys[i * 2] : 0;
                zobrist_Key ^= (Globals.bitBoardO[i / 9] & mask) != 0 ? Globals.square_Zobrist_Keys[i * 2 + 1] : 0;
            }
            for (i = 0; i < 27; i += 3)
            {
                mask = 1;
                mask <<= i / 3;
                zobrist_Key ^= (Globals.bitBoardX[9] & mask) != 0 ? Globals.grids_Zobrist_Keys[i] : 0;
                zobrist_Key ^= (Globals.bitBoardO[9] & mask) != 0 ? Globals.grids_Zobrist_Keys[i + 1] : 0;
                zobrist_Key ^= (Globals.tied_grids & mask) != 0 ? Globals.grids_Zobrist_Keys[i + 2] : 0;
            }

            zobrist_Key ^= current_Board_Number == -1 ? Globals.current_Board_Zobrist_Keys[9] : Globals.current_Board_Zobrist_Keys[current_Board_Number];
            zobrist_Key ^= Globals.turn_Indicator == 1 ? Globals.playing[0] : Globals.playing[1];
            return zobrist_Key;
        }



        //Name: possible_Moves
        //General: This function returns all possible moves
        //Parameters: int current_Board_Number - The board we are checking moves for
        //bool is_Max - is the current player maximizing
        //Returns: LinkedList<int> With all the possible moves (or -1 if there are none)
        //Complexity: O(n) (n = 9 || n = 81)
        public LinkedList<int> possible_Moves(int current_Board_Number, bool is_Max)
        {
            int i = 0, j = 0, number_Of_Positions = 9, eval;
            short mask;
            Int64 zobrist;
            LinkedList<int> moves = new LinkedList<int>();
            LinkedList<int> evals = new LinkedList<int>();
            LinkedListNode<int> currentMove = new LinkedListNode<int>(-1);
            LinkedListNode<int> currentEval = new LinkedListNode<int>(0);
            if (current_Board_Number == -1 || Globals.deactivated_Grids[current_Board_Number])
            {
                number_Of_Positions = 81;
                current_Board_Number = -1;
            }

            for (i = 0; i < number_Of_Positions; i++)
            {
                //if its a possible move
                if (!Globals.deactivated_Buttons[(current_Board_Number == -1 ? i : current_Board_Number * 9 + i)] && !Globals.deactivated_Grids[current_Board_Number == -1 ? i / 9 : current_Board_Number])
                {
                    mask = 1;
                    mask <<= i % 9;
                    if (Globals.turn_Indicator == 1) //do move
                        Globals.bitBoardX[current_Board_Number == -1 ? i / 9 : current_Board_Number] |= mask;
                    else
                        Globals.bitBoardO[current_Board_Number == -1 ? i / 9 : current_Board_Number] |= mask;


                    if (Globals.is_Transposition) //We're organizing the moves based on the values in the transposition table
                    {
                        
                        zobrist = create_Zobrist_Key(current_Board_Number);

                        mask = (short)~mask; //flip bits

                        if (Globals.turn_Indicator == 1) //undo move
                            Globals.bitBoardX[current_Board_Number == -1 ? i / 9 : current_Board_Number] &= mask;
                        else
                            Globals.bitBoardO[current_Board_Number == -1 ? i / 9 : current_Board_Number] &= mask;



                        if (Globals.transposition.ContainsKey(zobrist))  //we will use to linked lists that represent the eval of the
                        {                                               //position (evals) and button number itself (moves)
                            eval = Globals.transposition[zobrist].get_Eval();
                            if (evals.Count != 0) //if we haven't entered any moves with known values yet
                            {

                                currentMove = moves.First;
                                currentEval = evals.First;

                                for (j = 0; j < evals.Count; j++)
                                {
                                    if (is_Max ? eval > currentEval.Value : eval < currentEval.Value)
                                    {
                                        moves.AddBefore(currentMove, current_Board_Number == -1 ? i : current_Board_Number * 9 + i);
                                        evals.AddBefore(currentEval, eval);
                                        break;

                                    }
                                    else if (j + 1 == evals.Count) //if there are no more nodes after this
                                    {
                                        moves.AddAfter(currentMove, current_Board_Number == -1 ? i : current_Board_Number * 9 + i);
                                        evals.AddAfter(currentEval, eval);
                                        break;
                                    }
                                    else
                                    {
                                        currentMove = currentMove.Next;
                                        currentEval = currentEval.Next;
                                    }
                                }
                            }
                            else
                            {
                                moves.AddFirst(current_Board_Number == -1 ? i : current_Board_Number * 9 + i);
                                evals.AddFirst(eval);
                            }
                        }
                        else
                        {
                            moves.AddLast(current_Board_Number == -1 ? i : current_Board_Number * 9 + i); //we add it to the last position
                        }                                                                           //because our 2 lists need to match

                    }

                    else //basic move ordering
                    {
                        //if we won or tied a grid we want to check that first
                        if (current_Board_Number == -1 ? (Globals.bitBoardX[i / 9] | Globals.bitBoardO[i / 9] | mask) == 0x01FF : (Globals.bitBoardX[current_Board_Number] | Globals.bitBoardO[current_Board_Number] | mask) == 0x01FF)
                            moves.AddFirst(current_Board_Number == -1 ? i : current_Board_Number * 9 + i);
                        else
                            moves.AddLast(current_Board_Number == -1 ? i : current_Board_Number * 9 + i);


                        mask = (short)~mask; //flip bits

                        if (Globals.turn_Indicator == 1) //undo move
                            Globals.bitBoardX[current_Board_Number == -1 ? i / 9 : current_Board_Number] &= mask;
                        else
                            Globals.bitBoardO[current_Board_Number == -1 ? i / 9 : current_Board_Number] &= mask;
                    }

                }
            }
            if (moves.Count == 0)
                moves.AddLast(-1);
            return moves;
        }


        //Name: minmax
        //General: The minmax function checks the possible moves to a certain depth and finds the optimal move
        //Parameters: int current_Board_Number - The current board we are playing at
        //int depth - the depth the minmax algorithm should search to
        //int alpha - the best eval for X
        //int beta - the best eval for O
        //bool isMax - Should the function try to maximize the position or minimize it
        //Returns: the eval for the position
        //Complexity: O(n^t) when n represents the number of moves and t represents the depth

        public int minmax(int current_Board_Number, int depth, int alpha, int beta, bool isMax)
        {
            int minEval = int.MaxValue, maxEval = int.MinValue, eval = 0;
            short tempBoard, mask = 1, tie_mask = 1;
            bool grid_Won = false, tied_Board = false, is_First = true;
            LinkedList<int> moves;
            int button;
            Int64 zobrist_Key;
            Map_Value zobrist_Val;

            if (Globals.cs.Check_Win(Globals.bitBoardX[9])) //if X won then return infinity
                return minEval;
            if (Globals.cs.Check_Win(Globals.bitBoardO[9])) //if O won then return -infinity
                return maxEval;

            if (Globals.turn_Counter == 81)
                return 0;
            if (depth == 0) //if we reached the end of our depth, then stop and return the current eval
                return heuristic();

            if (Globals.is_Transposition && Globals.ai_Depth != depth)
            {
                zobrist_Key = create_Zobrist_Key(current_Board_Number);
                if (Globals.transposition.ContainsKey(zobrist_Key) && Globals.transposition[zobrist_Key].get_Depth() >= depth) //if we saved the position and only if
                    return Globals.transposition[zobrist_Key].get_Eval();//we cant improve the depth then return the saved eval
            }

            moves = possible_Moves(current_Board_Number, isMax);
            button = moves.First.Value;
            if (button == -1)
                return heuristic();

            if (isMax) //if the player is trying to maximize the position
            {

                while (moves.Count != 0) //if we can play here*************************
                {
                    button = moves.First.Value;
                    grid_Won = false;
                    tied_Board = false;

                    tempBoard = 1;
                    tempBoard <<= (button % 9);
                    Globals.bitBoardX[button / 9] |= tempBoard; //turn on bit
                    Globals.deactivated_Buttons[button] = true;

                    if (Globals.cs.Check_Win(Globals.bitBoardX[button / 9]))
                    {
                        mask = 1;
                        mask <<= button / 9;
                        Globals.bitBoardX[9] |= mask;
                        Globals.deactivated_Grids[button / 9] = true;
                        grid_Won = true;
                    }

                    if (Globals.cs.is_Tie(button / 9))
                    {
                        tie_mask = 1;
                        tie_mask <<= button / 9;
                        Globals.tied_grids |= tie_mask;
                        Globals.deactivated_Grids[button / 9] = true;
                        tied_Board = true;
                    }


                    Globals.turn_Counter++;
                    if (Globals.is_Transposition)
                    {
                        zobrist_Key = create_Zobrist_Key(current_Board_Number);
                        eval = minmax(Globals.deactivated_Grids[button % 9] == true ? -1 : button % 9, depth - 1, alpha, beta, false);
                        //recursing the function so that the next board is compliant with the square we chose, and since our current player is trying to maximize the position, the next one will try to minimize it

                        Globals.temp_Counter++;

                        if (!Globals.transposition.ContainsKey(zobrist_Key))
                        { //if we haven't saved this position yet
                            zobrist_Val = new Map_Value(eval, depth);
                            Globals.transposition.Add(zobrist_Key, zobrist_Val);
                        }
                        else
                        {
                            Globals.transposition[zobrist_Key].set_Eval(eval);
                            Globals.transposition[zobrist_Key].set_Depth(depth);
                        }
                    }
                    else
                    {
                        eval = minmax(Globals.deactivated_Grids[button % 9] == true ? -1 : button % 9, depth - 1, alpha, beta, false);
                        //recursing the function so that the next board is compliant with the square we chose, and since our current player is trying to maximize the position, the next one will try to minimize it
                        Globals.temp_Counter++;
                    }

                    //eval = minmax(deactivated_Grids[button % 9] == true ? -1 : button % 9, depth - 1, alpha, beta, true);
                    if (eval > maxEval)
                    {
                        maxEval = eval;
                        if (depth == Globals.ai_Depth) //if we're at the top of the tree (yeah i know its technically a recursion)
                            Globals.ai_Button = button; //then change the button the ai presses accordinally
                    }

                    is_First = false;

                    tempBoard = (short)~tempBoard; //reverse tempBoard's bits
                    Globals.bitBoardX[button / 9] &= tempBoard; //remove the changes we added before
                    Globals.deactivated_Buttons[button] = false;

                    if (grid_Won)
                    {
                        mask = (short)~mask; //flip mask //instead save last board and replace just to see if its the problem
                        Globals.bitBoardX[9] &= mask; //remove win
                        Globals.deactivated_Grids[button / 9] = false; //remove deactivation
                    }

                    if (tied_Board)
                    {
                        tie_mask = (short)~tie_mask;
                        Globals.tied_grids &= tie_mask;
                        Globals.deactivated_Grids[button / 9] = false;
                    }

                    Globals.turn_Counter--;

                    moves.RemoveFirst();

                        alpha = Math.Max(alpha, maxEval);
                        if (beta <= alpha)
                        break;

                }
                if (depth == Globals.ai_Depth && Globals.ai_Button == Globals.Last_AI_Button)
                    Globals.ai_Button = button;
                return maxEval;
            }

            
            //if the player is trying to minimize the position
            while (moves.Count != 0) //if we can play here*************************
            {
                button = moves.First.Value;
                grid_Won = false;
                tied_Board = false;

                tempBoard = 1;
                tempBoard <<= (button % 9);
                Globals.bitBoardO[button / 9] |= tempBoard; //turn on bit
                Globals.deactivated_Buttons[button] = true;

                if (Globals.cs.Check_Win(Globals.bitBoardO[button / 9]))
                {
                    mask = 1;
                    mask <<= button / 9;
                    Globals.bitBoardO[9] |= mask;
                    Globals.deactivated_Grids[button / 9] = true;
                    grid_Won = true;
                }

                if (Globals.cs.is_Tie(button / 9))
                {
                    tie_mask = 1;
                    tie_mask <<= button / 9;
                    Globals.tied_grids |= tie_mask;
                    Globals.deactivated_Grids[button / 9] = true;
                    tied_Board = true;
                }


                Globals.turn_Counter++;
                if (Globals.is_Transposition)
                {
                    zobrist_Key = create_Zobrist_Key(current_Board_Number);
                    eval = minmax(Globals.deactivated_Grids[button % 9] == true ? -1 : button % 9, depth - 1, alpha, beta, true);
                    //recursing the function so that the next board is compliant with the square we chose, and since our current player is trying to maximize the position, the next one will try to minimize it

                    Globals.temp_Counter++;

                    if (!Globals.transposition.ContainsKey(zobrist_Key))
                    { //if we haven't saved this position yet
                        zobrist_Val = new Map_Value(eval, depth);
                        Globals.transposition.Add(zobrist_Key, zobrist_Val);
                    }
                    else
                    {
                        Globals.transposition[zobrist_Key].set_Eval(eval);
                        Globals.transposition[zobrist_Key].set_Depth(depth);
                    }
                }
                else
                {
                    eval = minmax(Globals.deactivated_Grids[button % 9] == true ? -1 : button % 9, depth - 1, alpha, beta, true);
                    //recursing the function so that the next board is compliant with the square we chose, and since our current player is trying to maximize the position, the next one will try to minimize it
                    Globals.temp_Counter++;
                }

                //eval = minmax(deactivated_Grids[button % 9] == true ? -1 : button % 9, depth - 1, alpha, beta, true);
                if (eval < minEval)
                {
                    minEval = eval;
                    if (depth == Globals.ai_Depth) //if we're at the top of the tree (yeah i know its technically a recursion)
                        Globals.ai_Button = button; //then change the button the ai presses accordinally
                }

                is_First = false;

                tempBoard = (short)~tempBoard; //reverse tempBoard's bits
                Globals.bitBoardO[button / 9] &= tempBoard; //remove the changes we added before
                Globals.deactivated_Buttons[button] = false;

                if (grid_Won)
                {
                    mask = (short)~mask; //flip mask //instead save last board and replace just to see if its the problem
                    Globals.bitBoardO[9] &= mask; //remove win
                    Globals.deactivated_Grids[button / 9] = false; //remove deactivation
                }

                if (tied_Board)
                {
                    tie_mask = (short)~tie_mask;
                    Globals.tied_grids &= tie_mask;
                    Globals.deactivated_Grids[button / 9] = false;
                }

                Globals.turn_Counter--;

                moves.RemoveFirst();

                beta = Math.Min(beta, minEval);
                if (beta <= alpha)
                    break;

            }
            if (depth == Globals.ai_Depth && Globals.ai_Button == Globals.Last_AI_Button)
                Globals.ai_Button = button;
            return minEval;
        }
    }




    public class CheckState
    {
        public CheckState() { }


        //Name: is_Tie
        //General: Checks for ties
        //Parameters: int grid_Num - the number of the grid we check for a tie
        //Returns: boolean - True if there is a tie in the grid
        //Complexity: O(1)

        public bool is_Tie(int grid_Num)
        {

            if ((Globals.bitBoardX[grid_Num] | Globals.bitBoardO[grid_Num]) == 0x01FF) //if the bit board is a tie
                return true;
            return false;

        }


        //Name: Check_Win
        //General: Checks a certain board for a win
        //Parameters: short board - the board we check for a win
        //Returns: Boolean - True if there is a win in the grid
        //Complexity: O(1)
        public bool Check_Win(short board)
        {
            int i = 0;
            short[] win_Conditions = { 0x0007, 0x0038, 0x01c0, 0x0049, 0x0092, 0x0124, 0x0111, 0x0054 };
            for (i = 0; i < win_Conditions.Length; i++)
            {
                if ((board & win_Conditions[i]) == win_Conditions[i])
                    return true;
            }
            return false;
        }

    }




    public class GameController : MonoBehaviour
    {
        //Unity needs to set the value of these assets so they must be at the GameController class and then move to Globals
        public GameObject[] turn_Icons; //displays who's turn it is
        public GameObject[] grids; //all the 9 grids on the board (the 9 smaller boards inside the big one
        public GameObject[] canvases;
        public Sprite[] icons;   //0 = O icon, 1 = X icon
        public Button[] spaces;     //playable space
        public Button end_Button;
        public Text[] texts;
        public Button music;
        public static CheckState cs = new CheckState();
        public static Board board = new Board();
        public static AI ai = new AI(board);
        public static UI ui = new UI(ai, board);
        
        // Start is called before the first frame update
        void Start()
        {
            Globals.turn_Icons = turn_Icons;
            Globals.grids = grids;
            Globals.canvases = canvases;
            Globals.icons = icons;
            Globals.spaces = spaces;
            Globals.end_Button = end_Button;
            Globals.texts = texts;
            Globals.music = music;
            Globals.GameSetup();
        }

        //The game uses this class to choose a function which will then redirect it to one of our classes:
        public void start_Button_Pressed(int number_Of_Button)
        {
            ui.start_Button_Pressed(number_Of_Button);
        }

        public void Sound_Pressed()
        {
            ui.Sound_Pressed();
        }

        public void Button_Pressed(int number_Of_Button)
        {
            ui.Button_Pressed(number_Of_Button);
        }

        public void button_Played(int number_Of_Button)
        {
            board.button_Played(number_Of_Button);
        }

        public void deactivate_Boards(int next_Board)
        {
            board.deactivate_Boards(next_Board);
        }

        public void win_Grid(int grid_Num)
        {
            board.win_Grid(grid_Num);
        }

        public void finish_Game()
        {
            board.finish_Game();
        }


    }
}


//put values that are only for a certain func or class only in that func or class - NOT IN GLOBALS
//make sure one class contains another - see what Yaron sent you! no global classes!
//fix minmax - negaScout can suck my ass; return it to normal
//you gotta explain the numbers in the heuristic in the תיק פרויקט - just say the same shit you told the teachers but write it down all nice and tidy
//
