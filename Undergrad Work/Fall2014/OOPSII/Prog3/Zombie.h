//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the Zombie bots, derived from the VBot Class.
//          The methods include a constructor and destructor, a
//          Move method, and the energy of the Zombie.
//-------------------------------------------------------------------
#pragma once

#include "Vbot.h"
#include <cstdlib>

const int RANDOM = 40;
const int START_VEL = 10;

class Zombie : public VBot
{
public:
   //----------------------------------------------------------------
   // Constructor: Uses the base class constructor, and intializes
   // the sound, image, xVel, and yVel.
   //----------------------------------------------------------------
   Zombie(int x, int y, Panel ^ drawPanel);

   //----------------------------------------------------------------
   // Moves the Zombie randomly in a diagonal fashion. If the Zombie
   // reaches the side of the panel, it bounces off and moves in the
   // opposite direction.
   //----------------------------------------------------------------
   void Move();

   //----------------------------------------------------------------
   // Returns a random amount of the Zombie's energy level.
   //----------------------------------------------------------------
   int EnergyToFightWith() { return rand() % energy + 1; }

private:
   int xVel;                   //The velocity in the x direction
   int yVel;                   //The velocity in the y direction
};
#pragma endregion