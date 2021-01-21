//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the methods of the VBots. Checks for collisions,
//          if a bot is dead. Also handles battles between bots, and 
//          has a couple virtual methods: destructor, Move, Show,
//          EnergyToFightWith, and PlaySound.
//-------------------------------------------------------------------

#pragma once 
#include <vcclr.h>   
using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Media;
class VBot
{
public:
   //----------------------------------------------------------------
   // Constructor: Creates the bot with the given coordinates (x, y)
   // on the given panel, and intitates the energy level and image.
   //----------------------------------------------------------------
   VBot(int startX, int startY, Panel ^ drawingPanel) :
      x(startX), y(startY), panel(drawingPanel), energy(100), image(NULL) { }

   //----------------------------------------------------------------
   // Destructor: default destructor of bots.
   //----------------------------------------------------------------
   virtual ~VBot() { }

   //----------------------------------------------------------------
   // Moves the bot by changing the x and y coordinates of the image.
   //----------------------------------------------------------------
   virtual void Move() = 0;

   //----------------------------------------------------------------
   // Returns the amount of energy used in a battle as an integer.
   //----------------------------------------------------------------
   virtual int EnergyToFightWith() = 0;

   //----------------------------------------------------------------
   // Returns true if the Bot has no energy or negative energy, false
   // otherwise.
   //----------------------------------------------------------------
   bool IsDead() const { return energy <= 0; }

   //----------------------------------------------------------------
   // Shows the bot image at its current coordinates.
   //----------------------------------------------------------------
   virtual void Show();

   //----------------------------------------------------------------
   // Checks whether or not a bot has "collided" with another bot.
   // Returns true if there is a collision, false otherwise.
   //----------------------------------------------------------------
   bool CollidedWith(VBot * b) const;

   //----------------------------------------------------------------
   // The calling bot battles against the bot being passed. Each bots
   // energy is effected during the battle.
   //----------------------------------------------------------------
   void DoBattleWith(VBot * b);

   //----------------------------------------------------------------
   // Plays the .wav sound file associated with the bot.
   //----------------------------------------------------------------
   virtual void PlaySound() { sound->Play(); }

protected:
   int x, y;                           // Current position of the VBot
   gcroot<Drawing::Bitmap ^> image;    // Image displayed for the VBot
   gcroot<Panel ^> panel;              // Panel on which to show the VBot.
   int energy;                         // Current energy of the VBot
   gcroot <SoundPlayer ^> sound;
};

#pragma endregion