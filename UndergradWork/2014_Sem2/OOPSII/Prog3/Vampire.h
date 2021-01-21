//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the Vampire bots, derived from the VBot Class.
//          The methods include a constructor and destructor, a
//          Move method, and the energy of the Vampire.
//-------------------------------------------------------------------
#pragma once

#include "Vbot.h"
#include <cstdlib>

const int XY_VEL = 20;

class Vampire : public VBot
{
public:
   //----------------------------------------------------------------
   // Constructor: Uses the base class constructor, and intializes
   // the sound, image, xVel, and yVel.
   //----------------------------------------------------------------
   Vampire(int x, int y, Panel ^ drawPanel);

   //----------------------------------------------------------------
   // Moves the Vampire diagonally across the panel. If the Vampire
   // reaches a side, it bounces of the side in the opposite 
   // direction.
   //----------------------------------------------------------------
   void Move();

   //----------------------------------------------------------------
   // Returns a random amount of the Vampire's energy level.
   //----------------------------------------------------------------
   int EnergyToFightWith() { return rand() % energy + 1; }

private:
   int xVel;                   //The velocity in the x direction
   int yVel;                   //The velocity in the y direction
};
#pragma endregion