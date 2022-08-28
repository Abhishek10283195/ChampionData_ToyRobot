using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ChampionData
{
	class Robot
	{
        private static String position;
        private static int x;
        private static int y;
        private static String face;

        /// <summary>
        /// Constructor for objects of class Robot
        /// </summary>
        public Robot()
        {
            x = 0;
            y = 0;
            position = x.ToString() + "," + y.ToString() + "," + face;
        }

        /// <summary>
        /// Method to get the direction the robot is facing
        /// </summary>
        /// <returns> A string with the direction the robot is facing (N, E, W or S)</returns>
        public static String getFace()
        {
            return face;
        }
 
        /// <summary>
        /// Method to get the position of the robot
        /// </summary>
        /// <returns> The co-ordinates of the robot with the face direction </returns>
        public static String getPosition()
        {
            return position;
        }

        /// <summary>
        /// Method to get the X coordinate of the robot
        /// </summary>
        /// <returns> The  X coordinate of the robot</returns>
        public int getX()
        {
            return x;
        }

        /// <summary>
        /// Method to get the Y coordinate of the robot
        /// </summary>
        /// <returns> The  Y coordinate of the robot</returns>
        public int getY()
        {
            return y;
        }

        /// <summary>
        /// Method to set the direction of the robot to face North or South or East or West
        /// </summary>
        /// <param name="newFace"> The direction of the robot as specified by the user </param>
        public static void setFace(String newFace)
        {
            face = newFace;
        }

        /// <summary>
        /// Method to set the position of the robot
        /// </summary>
        /// <param name="face">The current direction the robot is facing</param>
        public static void setPosition(String face)
        {
            position = x.ToString() + "," + y.ToString() + "," + face;
        }


        /// <summary>
        /// A method to set the X coordinate of the robot
        /// </summary>
        /// <param name="newX">The X coordinate specified by the user input for the robot</param>
        public static void setX(int newX)
        {
            if (x < 4 && x > 0)
            {
                // Prevents the robot from falling off the table
                x += newX;
            }
            else
            {
                Console.WriteLine("Oops! I will fall off the table if I move there \n");
            }
        }

        /// <summary>
        /// Method to set the Y coordinate of the robot
        /// </summary>
        /// <param name="newY">The Y coordinate specified by the user input for the robot</param>
        public static void setY(int newY)
        {
            if (y < 4 && y > 0)
            {
                // Prevents the robot from falling off the table
                y += newY;
            }
            else
            {
                Console.WriteLine("Oops! I will fall off the table if I move there \n");
            }
        }

        /// <summary>
        /// Method to PLACE the robot on the table based on user inputs
        /// </summary>
        /// <param name="X">The X coordinate specified by the user input for the robot</param>
        /// <param name="Y">The Y coordinate specified by the user input for the robot</param>
        public static void placeRobot(int X, int Y)
        {
            if ((X <= 4 && X >= 0) && (Y <= 4 && Y >= 0))
            {
                // Prevents the user from making the robot fall off the table
                x = X;
                y = Y;
            }
            else
            {
                Console.WriteLine("Oops! I will fall off the table if I move there \n");
            }
        }

        /// <summary>
        /// Method to rotate the robot 90 degrees to the left without changing its position
        /// </summary>
        /// <param name="face">The current direction the robot is facing</param>
        public static void turnLeft(String face)
        {
            // Turns the robot 90 degrees to the left based on the current direction it is facing
            if (String.Equals("NORTH", face))
            {
                setPosition("WEST");
            }
            else if (String.Equals("EAST", face))
            {
                setPosition("NORTH");
            }
            else if (String.Equals("SOUTH", face))
            {
                setPosition("EAST");
            }
            else if (String.Equals("WEST", face))
            {
                setPosition("SOUTH");
            }
        }

        /// <summary>
        /// Method to rotate the robot 90 degrees to the right without changing its position
        /// </summary>
        /// <param name="face">The current direction the robot is facing</param>
        public static void turnRight(String face)
        {
            // Turns the robot 90 degrees to the left based on the current direction it is facing
            if (String.Equals("NORTH", face))
            {
                setPosition("EAST");
            }
            else if (String.Equals("EAST", face))
            {
                setPosition("SOUTH");
            }
            else if (String.Equals("SOUTH", face))
            {
                setPosition("WEST");
            }
            else if (String.Equals("WEST", face))
            {
                setPosition("NORTH");
            }
        }

        /// <summary>
        /// Method to PLACE the robot with x y coordinates and face direction as specified by the user
        /// </summary>
        /// <param name="position">An array consisting of x and y coordinates and face direction</param>
        /// <returns>True if the position specified by user is valid, false otherwise</returns>
        public static bool placeRobot(String[] position)
        {
            String[] directions = { "NORTH", "EAST", "WEST", "SOUTH" };
            var found = false;
            // Check if the direction specified by the user is in the directions[] array
            foreach (String s in directions)
            {
                if (String.Equals(position[2], s))
                {
                    // place robot on the x and y coordinates
                    placeRobot(int.Parse(position[0]), int.Parse(position[1]));
                    // set the position with x and y coordinates and the face directions
                    setPosition(position[2]);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Invalid direction \n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// A method to report the position of the robot to the user
        /// </summary>
        public static void reportPosition()
        {
            Console.WriteLine(getPosition());
        }

        /// <summary>
        /// Method to validate user commands and execute PLACE, MOVE, LEFT, RIGHT, REPORT
        /// </summary>
        /// <param name="userInput">The arrayList consisting the user input</param>
        /// <returns>True in case of valid command, false otherwise</returns>
        public static bool validateInput(List<String> userInput)
        {
            var input = "";
            var pos = "";
            // Converting array list to String
            foreach (String i in userInput)
            {
                input += i;
            }
            // Splitting the string to separate the commands based on space delimiter
            String[] command = input.Split(' ');
            switch (command[0])
            {
                // Case when the command is PLACE
                case "PLACE":
                    try
                    {
                        pos = command[1].ToString();
                        // Converting array to String
                        String[] temp2 = pos.Split(',');
                        // Splitting the string by comma delimiter
                        // Check if the command is valid with correct coordinates and direction
                        if (!placeRobot(temp2))
                        {
                            return false;
                        }
                    }
                    // Catch exception if the PLACE command is invalid
                    catch (Exception e)
                    {
                        Console.WriteLine("PLACE command invalid \n");
                        return false;
                    }
                    break;
                // Case when the command is MOVE
                case "MOVE":
                    var dir = getPosition();
                    String[] facing = dir.Split(',');
                    // Get the current direction from the position
                    // Move the robot one place in the direction it is facing
                    if (String.Equals(facing[2], "NORTH"))
                    {
                        setY(1);
                    }
                    else if (String.Equals(facing[2], "EAST"))
                    {
                        setX(1);
                    }
                    else if (String.Equals(facing[2], "SOUTH"))
                    {
                        setY(-1);
                    }
                    else if (String.Equals(facing[2], "WEST"))
                    {
                        setX(-1);
                    }
                    setPosition(facing[2]);
                    // Set the position based on the new x and y coordinates
                    break;
                // Case when the command is LEFT			
                case "LEFT":
                    var dir1 = getPosition();
                    // Get the current direction from the position
                    String[] facing1 = dir1.Split(',');
                    // Turn the robot left by sending its current face as a parameter
                    turnLeft(facing1[2]);
                    break;
                // Case when the command is RIGHT
                case "RIGHT":
                    var dir11 = getPosition();
                    // Get the current direction from the position
                    String[] facing11 = dir11.Split(',');
                    // Turn the robot right by sending its current face as a parameter
                    turnRight(facing11[2]);
                    break;
                // Case when the command is REPORT
                case "REPORT":
                    reportPosition();
                    break;
                // Case when the command is INVALID
                default:
                    Console.Write("Invalid Command \n");
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
		{

            // Scanner variable to record user inputs	
            var terminate = false;
            // Variable to terminate the console
            var placeFound = false;
            Console.WriteLine("Welcome! I am a toy Robot! Command me to move around the table \n");
            Console.WriteLine("I only obey the following commands\n1. PLACE X,Y,F (where X & Y are positions ranging from 0-4, Face being the direction I face which is either N, E, W or S)");
            Console.WriteLine("2. MOVE (One step forward in the direction I am facing)");
            Console.WriteLine("3. LEFT (Turn 90 degrees to my left)");
            Console.WriteLine("4. RIGHT (Turn 90 degrees to my right)");
            Console.WriteLine("5. REPORT (Report my current direction)");
            Console.WriteLine("6. END (Stop the simulation) \n");
            Console.WriteLine("Note: The commands are case sensitive and please start with a valid PLACE command only \n");
            // Keep recording user inputs until condition fails
            while (!terminate)
            {
                var userInput = new List<String>();
                var buffer = new List<String>();
                // Buffer arrayList
                // A loop to keep recording multiple lines of user inputs
                while (true)
                {
                    var read = Console.ReadLine();
                    // Condition to terminate the console when user enters "END"
                    if (String.Equals("END", read))
                    {
                        terminate = true;
                        break;
                    }
                    String[] command = read.Split(' ');
                    // Split the user command
                    // Condition to check if the first command is PLACE when userInput array is 0
                    if ((!(command[0].Contains("PLACE")) && userInput.Count == 0))
                    {
                        Console.WriteLine("Please start with a PLACE command");
                    }
                    else
                    {
                        placeFound = true;
                        userInput.Add(read);
                        // Add command to userInput array
                        buffer.Add(read);
                        if (validateInput(buffer))
                        {
                            // Validate userInput										
                            buffer.Clear();
                        }
                        else
                        {
                            if (!placeFound)
                            {
                                userInput.Clear();
                            }
                            buffer.Clear();
                        }
                    }
                }
            }
        }
	}
}


