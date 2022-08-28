# ChampionData_ToyRobot
A command line java application to demonstrate the simulation of a toy robot on a 5*5 square table top

## How to run the project
- The robot understands the below commands
1. PLACE X,Y,F (x & y coordinates with face direction)
2. MOVE (One step in the direction I am facing)
3. LEFT (Turn 90 degrees to my left)
4. RIGHT (Turn 90 degrees to my right)
5. REPORT (Report my current direction)
6. END (Stop your commands) 

The commands are case sensitive and the first command SHOULD be PLACE. Once PLACE command is entered, any sequence of the above commands can be entered including another PLACE command.
The robot will alert the user when it reaches the end of the table top and also if the command is invalid
