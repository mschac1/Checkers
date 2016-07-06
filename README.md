# Checkers
Project from 2005
This was a project I wrote in 2004 to practice with C#. It uses some form of MVC since I seperated the Game logic from the GUI, but it definitly could have been deisgned better. For example, in this design, each piece is responsible for it's own location and movement, which isn't good design
The game uses the rule that any time a jump can be made, it must be made. I didn't add any kind of GUI response which does lead to some confusing situations, like when the game isn't responsding to your move and you don't realize it's because you haev a jump move and you're trying to make a different move.
The exe is bin/Debug/Checkers
