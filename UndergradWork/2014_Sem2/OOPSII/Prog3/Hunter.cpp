//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the Hunter bots, derived from the VBot Class.
//          The methods include a constructor and destructor, a
//          Move method, and the energy of the Hunter.
//-------------------------------------------------------------------
#include "stdafx.h" 
#include "Hunter.h"

Hunter::Hunter(int x, int y, Panel ^ drawPanel) : VBot(x, y, drawPanel)
{
   sound = gcnew System::Media::SoundPlayer("Hunter.wav");
   image = gcnew Drawing::Bitmap("Hunter.bmp");
}

void Hunter::Move()
{
   if (xVel < 0)
      xVel = -(rand() % X_RANDOM + 1);
   else
      xVel = rand() % X_RANDOM + X_RND_STRT;

   if (x + image->Width >= panel->Width && xVel > 0 || xVel < 0 && x <= 0)
   {
      xVel = -xVel;
      if (yVel < 0)
         yVel = -(rand() % Y_RANDOM + 1);
      else
         yVel = rand() % Y_RANDOM + 1;
      if (y + image->Height >= panel->Height && yVel > 0 || yVel < 0 && y <= 0)
         yVel = -yVel;
      y = y + yVel;
   }
   x = x + xVel;
}
