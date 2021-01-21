//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the Hunter bots, derived from the VBot Class.
//          The methods include a constructor and destructor, a
//          Move method, and the energy of the Hunter.
//-------------------------------------------------------------------
#pragma once

#include "Vbot.h"
#include <cstdlib>

const int X_RANDOM = 25;
const int Y_RANDOM = 50;
const int X_RND_STRT = 10;

class Hunter : public VBot
{
public:
   //----------------------------------------------------------------
   // Constructor: Uses the base class constructor, and intializes
   // the sound and image.
   //----------------------------------------------------------------
   Hunter(int x, int y, Panel ^ drawPanel);

   //----------------------------------------------------------------
   // Moves the Hunter across the panel in random intervals. If the
   // Hunter reaches the side of the panel, it moves down and travels
   // in the opposite direction. If the Hunter reaches the bottom it
   // moves up and travels in the opposite direction.
   //----------------------------------------------------------------
   void Move();

   //----------------------------------------------------------------
   // Returns a random amount of the Hunter's energy level.
   //----------------------------------------------------------------
   int EnergyToFightWith() { return rand() % energy + 1; }

private:
   int xVel;                   //The velocity in the x direction
   int yVel;                   //The velocity in the y direction
};
#pragma endregion