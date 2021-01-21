//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the Zombie bots, derived from the VBot Class.
//          The methods include a constructor and destructor, a
//          Move method, and the energy of the Zombie.
//-------------------------------------------------------------------
#include "stdafx.h" 
#include "Zombie.h"

Zombie::Zombie(int x, int y, Panel ^ drawPanel) : VBot(x, y, drawPanel)
{
   sound = gcnew System::Media::SoundPlayer("Zombie.wav");
   image = gcnew Drawing::Bitmap("Zombie.bmp");
   xVel = yVel = START_VEL;
}

void Zombie::Move()
{
   if (xVel < 0)
      xVel = -(rand() % RANDOM + 1);
   else
      xVel = rand() % RANDOM + 1;

   if (yVel < 0)
      yVel = -(rand() % RANDOM + 1);
   else
      yVel = rand() % RANDOM + 1;

   if (x + image->Width >= panel->Width && xVel > 0 || xVel < 0 && x <= 0)
      xVel = -xVel;
   if (y + image->Height >= panel->Height && yVel > 0 || yVel < 0 && y <= 0)
      yVel = -yVel;

   x = x + xVel;
   y = y + yVel;
}
