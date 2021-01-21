//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Controls the GUI of the program. Reacts to user intput
//          and outputs battle information of the bots.
//-------------------------------------------------------------------

#pragma once
#include "BotList.h"
#include "Zombie.h"
#include "Vampire.h"
#include "Hunter.h"
#include <cstdlib>

const int TYPES = 3;
const int X_MAX = 900;
const int Y_MAX = 650;
const int ZOMBIE = 2;
const int VAMPIRE = 1;
const int HUNTER = 0;

namespace Prog3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
         list = new BotList();
         x = y = battles = deaths = 0;
         random = muted = false;
		}

	protected:
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

	private: System::Windows::Forms::Panel^  botPanel;
	private: System::Windows::Forms::Label^  botTypeLbl;
	private: System::Windows::Forms::Label^  strtPosLbl;
	private: System::Windows::Forms::Label^  yLbl;
	private: System::Windows::Forms::Label^  spdLbl;
	private: System::Windows::Forms::Label^  xLbl;
   private: System::Windows::Forms::ComboBox^  botCBox;

   private: System::Windows::Forms::NumericUpDown^  yCoord;
	private: System::Windows::Forms::NumericUpDown^  xCoord;
	private: System::Windows::Forms::Button^  addBotBtn;
	private: System::Windows::Forms::Timer^  botTimer;
	private: System::Windows::Forms::Label^  bttleLbl;
	private: System::Windows::Forms::RichTextBox^  bttlTxtBox;
   private: System::Windows::Forms::Button^  rndBtn;
	private: System::ComponentModel::IContainer^  components;

	private:
      BotList *list;
      int x, y, battles, deaths;
      bool random, muted;

   private: System::Windows::Forms::TrackBar^  speedBar;
   private: System::Windows::Forms::Button^  muteBtn;





   private: System::Windows::Forms::TextBox^  rndCoords;




#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
         this->components = (gcnew System::ComponentModel::Container());
         this->botPanel = (gcnew System::Windows::Forms::Panel());
         this->botTypeLbl = (gcnew System::Windows::Forms::Label());
         this->strtPosLbl = (gcnew System::Windows::Forms::Label());
         this->yLbl = (gcnew System::Windows::Forms::Label());
         this->spdLbl = (gcnew System::Windows::Forms::Label());
         this->xLbl = (gcnew System::Windows::Forms::Label());
         this->botCBox = (gcnew System::Windows::Forms::ComboBox());
         this->yCoord = (gcnew System::Windows::Forms::NumericUpDown());
         this->xCoord = (gcnew System::Windows::Forms::NumericUpDown());
         this->addBotBtn = (gcnew System::Windows::Forms::Button());
         this->botTimer = (gcnew System::Windows::Forms::Timer(this->components));
         this->bttleLbl = (gcnew System::Windows::Forms::Label());
         this->bttlTxtBox = (gcnew System::Windows::Forms::RichTextBox());
         this->rndBtn = (gcnew System::Windows::Forms::Button());
         this->rndCoords = (gcnew System::Windows::Forms::TextBox());
         this->speedBar = (gcnew System::Windows::Forms::TrackBar());
         this->muteBtn = (gcnew System::Windows::Forms::Button());
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->yCoord))->BeginInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->xCoord))->BeginInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->speedBar))->BeginInit();
         this->SuspendLayout();
         // 
         // botPanel
         // 
         this->botPanel->Location = System::Drawing::Point(12, 100);
         this->botPanel->Name = L"botPanel";
         this->botPanel->Size = System::Drawing::Size(910, 549);
         this->botPanel->TabIndex = 0;
         this->botPanel->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::botPanel_Paint);
         // 
         // botTypeLbl
         // 
         this->botTypeLbl->AutoSize = true;
         this->botTypeLbl->Location = System::Drawing::Point(48, 9);
         this->botTypeLbl->Name = L"botTypeLbl";
         this->botTypeLbl->Size = System::Drawing::Size(46, 13);
         this->botTypeLbl->TabIndex = 1;
         this->botTypeLbl->Text = L"Bot type";
         // 
         // strtPosLbl
         // 
         this->strtPosLbl->AutoSize = true;
         this->strtPosLbl->Location = System::Drawing::Point(206, 9);
         this->strtPosLbl->Name = L"strtPosLbl";
         this->strtPosLbl->Size = System::Drawing::Size(83, 13);
         this->strtPosLbl->TabIndex = 2;
         this->strtPosLbl->Text = L"Starting Position";
         // 
         // yLbl
         // 
         this->yLbl->AutoSize = true;
         this->yLbl->Location = System::Drawing::Point(241, 32);
         this->yLbl->Name = L"yLbl";
         this->yLbl->Size = System::Drawing::Size(17, 13);
         this->yLbl->TabIndex = 3;
         this->yLbl->Text = L"Y:";
         // 
         // spdLbl
         // 
         this->spdLbl->AutoSize = true;
         this->spdLbl->Location = System::Drawing::Point(507, 9);
         this->spdLbl->Name = L"spdLbl";
         this->spdLbl->Size = System::Drawing::Size(38, 13);
         this->spdLbl->TabIndex = 4;
         this->spdLbl->Text = L"Speed";
         // 
         // xLbl
         // 
         this->xLbl->AutoSize = true;
         this->xLbl->Location = System::Drawing::Point(150, 32);
         this->xLbl->Name = L"xLbl";
         this->xLbl->Size = System::Drawing::Size(17, 13);
         this->xLbl->TabIndex = 5;
         this->xLbl->Text = L"X:";
         // 
         // botCBox
         // 
         this->botCBox->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(128)),
            static_cast<System::Int32>(static_cast<System::Byte>(0)));
         this->botCBox->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
         this->botCBox->ForeColor = System::Drawing::Color::Black;
         this->botCBox->FormattingEnabled = true;
         this->botCBox->Items->AddRange(gcnew cli::array< System::Object^  >(3) { L"Hunter", L"Vampire", L"Zombie" });
         this->botCBox->Location = System::Drawing::Point(12, 29);
         this->botCBox->Name = L"botCBox";
         this->botCBox->Size = System::Drawing::Size(121, 21);
         this->botCBox->TabIndex = 9;
         // 
         // yCoord
         // 
         this->yCoord->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 5, 0, 0, 0 });
         this->yCoord->Location = System::Drawing::Point(264, 30);
         this->yCoord->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 400, 0, 0, 0 });
         this->yCoord->Name = L"yCoord";
         this->yCoord->Size = System::Drawing::Size(53, 20);
         this->yCoord->TabIndex = 13;
         // 
         // xCoord
         // 
         this->xCoord->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) { 5, 0, 0, 0 });
         this->xCoord->Location = System::Drawing::Point(173, 30);
         this->xCoord->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 750, 0, 0, 0 });
         this->xCoord->Name = L"xCoord";
         this->xCoord->Size = System::Drawing::Size(53, 20);
         this->xCoord->TabIndex = 14;
         // 
         // addBotBtn
         // 
         this->addBotBtn->Location = System::Drawing::Point(332, 27);
         this->addBotBtn->Name = L"addBotBtn";
         this->addBotBtn->Size = System::Drawing::Size(75, 23);
         this->addBotBtn->TabIndex = 16;
         this->addBotBtn->Text = L"Add Bot";
         this->addBotBtn->UseVisualStyleBackColor = true;
         this->addBotBtn->Click += gcnew System::EventHandler(this, &Form1::addBotBtn_Click);
         // 
         // botTimer
         // 
         this->botTimer->Enabled = true;
         this->botTimer->Interval = 450;
         this->botTimer->Tick += gcnew System::EventHandler(this, &Form1::botTimer_Tick);
         // 
         // bttleLbl
         // 
         this->bttleLbl->AutoSize = true;
         this->bttleLbl->Location = System::Drawing::Point(706, 9);
         this->bttleLbl->Name = L"bttleLbl";
         this->bttleLbl->Size = System::Drawing::Size(55, 13);
         this->bttleLbl->TabIndex = 17;
         this->bttleLbl->Text = L"Battle Info";
         // 
         // bttlTxtBox
         // 
         this->bttlTxtBox->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(128)),
            static_cast<System::Int32>(static_cast<System::Byte>(0)));
         this->bttlTxtBox->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
            static_cast<System::Byte>(0)));
         this->bttlTxtBox->ForeColor = System::Drawing::Color::Black;
         this->bttlTxtBox->Location = System::Drawing::Point(647, 27);
         this->bttlTxtBox->Name = L"bttlTxtBox";
         this->bttlTxtBox->ReadOnly = true;
         this->bttlTxtBox->Size = System::Drawing::Size(175, 43);
         this->bttlTxtBox->TabIndex = 19;
         this->bttlTxtBox->Text = L"";
         // 
         // rndBtn
         // 
         this->rndBtn->Location = System::Drawing::Point(209, 56);
         this->rndBtn->Name = L"rndBtn";
         this->rndBtn->Size = System::Drawing::Size(75, 23);
         this->rndBtn->TabIndex = 20;
         this->rndBtn->Text = L"Random";
         this->rndBtn->UseVisualStyleBackColor = true;
         this->rndBtn->Click += gcnew System::EventHandler(this, &Form1::rndBtn_Click);
         // 
         // rndCoords
         // 
         this->rndCoords->Location = System::Drawing::Point(290, 56);
         this->rndCoords->Name = L"rndCoords";
         this->rndCoords->ReadOnly = true;
         this->rndCoords->Size = System::Drawing::Size(117, 20);
         this->rndCoords->TabIndex = 21;
         // 
         // speedBar
         // 
         this->speedBar->LargeChange = 200;
         this->speedBar->Location = System::Drawing::Point(435, 23);
         this->speedBar->Maximum = 800;
         this->speedBar->Minimum = 50;
         this->speedBar->Name = L"speedBar";
         this->speedBar->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
         this->speedBar->RightToLeftLayout = true;
         this->speedBar->Size = System::Drawing::Size(193, 45);
         this->speedBar->SmallChange = 50;
         this->speedBar->TabIndex = 1;
         this->speedBar->TickFrequency = 100;
         this->speedBar->Value = 450;
         this->speedBar->ValueChanged += gcnew System::EventHandler(this, &Form1::speedBar_ValueChanged);
         // 
         // muteBtn
         // 
         this->muteBtn->BackColor = System::Drawing::Color::Blue;
         this->muteBtn->ForeColor = System::Drawing::Color::White;
         this->muteBtn->Location = System::Drawing::Point(837, 12);
         this->muteBtn->Name = L"muteBtn";
         this->muteBtn->Size = System::Drawing::Size(75, 23);
         this->muteBtn->TabIndex = 22;
         this->muteBtn->Text = L"MUTE";
         this->muteBtn->UseVisualStyleBackColor = false;
         this->muteBtn->Click += gcnew System::EventHandler(this, &Form1::muteBtn_Click);
         // 
         // Form1
         // 
         this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
         this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
         this->BackColor = System::Drawing::Color::White;
         this->ClientSize = System::Drawing::Size(934, 661);
         this->Controls->Add(this->muteBtn);
         this->Controls->Add(this->speedBar);
         this->Controls->Add(this->rndCoords);
         this->Controls->Add(this->rndBtn);
         this->Controls->Add(this->bttlTxtBox);
         this->Controls->Add(this->bttleLbl);
         this->Controls->Add(this->addBotBtn);
         this->Controls->Add(this->xCoord);
         this->Controls->Add(this->yCoord);
         this->Controls->Add(this->botCBox);
         this->Controls->Add(this->xLbl);
         this->Controls->Add(this->spdLbl);
         this->Controls->Add(this->yLbl);
         this->Controls->Add(this->strtPosLbl);
         this->Controls->Add(this->botTypeLbl);
         this->Controls->Add(this->botPanel);
         this->MaximumSize = System::Drawing::Size(1024, 768);
         this->MinimumSize = System::Drawing::Size(950, 700);
         this->Name = L"Form1";
         this->Text = L"Supernatural Battles";
         this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &Form1::Form1_FormClosed);
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->yCoord))->EndInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->xCoord))->EndInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->speedBar))->EndInit();
         this->ResumeLayout(false);
         this->PerformLayout();

      }
#pragma endregion
private: System::Void addBotBtn_Click(System::Object^  sender, System::EventArgs^  e) {
   
   VBot *bot;
   if (!random)
   {
      x = Decimal::ToInt32(xCoord->Value);
      y = Decimal::ToInt32(yCoord->Value);
   }

   int type = 0;
   if(botCBox->SelectedIndex == -1)
      type = rand() % TYPES;
   else
      type = botCBox->SelectedIndex;

   if (type == HUNTER)
      bot = new Hunter(x, y, botPanel);
   else if (type == VAMPIRE)
      bot = new Vampire(x, y, botPanel);
   else if (type == ZOMBIE)
      bot = new Zombie(x, y, botPanel);

   list->Insert(bot); 
   list->Paint();

   if (!muted)
      bot->PlaySound();

   xCoord->ReadOnly = false;
   yCoord->ReadOnly = false;
   xCoord->Enabled = true;
   yCoord->Enabled = true;
   rndCoords->Clear();
   x = y = 0;
}


private: System::Void botTimer_Tick(System::Object^  sender, System::EventArgs^  e) {
   list->Move();
   battles = battles + list->Battles();
   deaths = deaths + list->CheckDeaths();  
   if (battles != 0)
   {
      bttlTxtBox->Text = "Number of Battles: " + battles + "\n"
                       + "Number of Deaths: " + deaths;
   }
   botPanel->Invalidate();
}

private: System::Void rndBtn_Click(System::Object^  sender, System::EventArgs^  e) {
   random = true;

   x = rand() % X_MAX;
   y = rand() % Y_MAX;

   xCoord->ReadOnly = true;
   yCoord->ReadOnly = true;
   xCoord->Enabled = false;
   yCoord->Enabled = false;

   rndCoords->Text = "X: " + x + " Y: " + y;
}

private: System::Void Form1_FormClosed(System::Object^  sender, System::Windows::Forms::FormClosedEventArgs^  e) {
   botTimer->Enabled = false;
   delete list;
}

private: System::Void botPanel_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {

   list->Paint();
}

private: System::Void speedBar_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
   botTimer->Interval = speedBar->Value;
}
private: System::Void muteBtn_Click(System::Object^  sender, System::EventArgs^  e) {
   if (muted)
   {
      muteBtn->Text = "MUTE";
      muteBtn->BackColor = System::Drawing::Color::Blue;
      muteBtn->ForeColor = System::Drawing::Color::White;
   }
   else
   {
      muteBtn->Text = "UNMUTE";
      muteBtn->BackColor = System::Drawing::Color::White;
      muteBtn->ForeColor = System::Drawing::Color::Blue;
   }

   muted = !muted;
}
};
}
