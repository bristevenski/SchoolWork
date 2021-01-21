//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the Vampire bots, derived from the VBot Class.
//          The methods include a constructor and destructor, a
//          Move method, and the energy of the Vampire.
//-------------------------------------------------------------------
#include "stdafx.h" 
#include "Vampire.h"

Vampire::Vampire(int x, int y, Panel ^ drawPanel) : VBot(x, y, drawPanel)
{
   sound = gcnew System::Media::SoundPlayer("Vampire.wav");
   image = gcnew Drawing::Bitmap("Vampire.bmp");
   xVel = yVel = XY_VEL;
}

void Vampire::Move()
{
   if( xVel < 0 && x <= 0 || xVel > 0 && 
                             x + image->Width >= panel->Width )
      xVel = -xVel;
   if( yVel < 0 && y <= 0 || yVel > 0 &&
                             y + image->Height >= panel->Height )
      yVel = -yVel;
   x = x + xVel;
   y = y + yVel;
}

