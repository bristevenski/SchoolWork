//-------------------------------------------------------------------
//
//-------------------------------------------------------------------
#pragma once

namespace Prog3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for mainForm
	/// </summary>
	public ref class mainForm : public System::Windows::Forms::Form
	{
	public:
		mainForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~mainForm()
		{
			if (components)
			{
				delete components;
			}
		}
   private: System::Windows::Forms::Button^  addBot;
   private: System::Windows::Forms::NumericUpDown^  startX;
   private: System::Windows::Forms::NumericUpDown^  startY;
   private: System::Windows::Forms::ProgressBar^  enrgLvl;

   protected:



   private: System::Windows::Forms::Panel^  botPnl;
   private: System::Windows::Forms::ComboBox^  botBox;


   private: System::Windows::Forms::TrackBar^  speedBar;
   private: System::Windows::Forms::Label^  botLbl;
   private: System::Windows::Forms::Label^  xLbl;
   private: System::Windows::Forms::Label^  yLbl;
   private: System::Windows::Forms::Label^  speedLbl;
   private: System::Windows::Forms::Label^  energyLbl;
   private: System::Windows::Forms::Label^  coordLbl;
   private: System::Windows::Forms::TextBox^  botType;






	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
         this->addBot = (gcnew System::Windows::Forms::Button());
         this->startX = (gcnew System::Windows::Forms::NumericUpDown());
         this->startY = (gcnew System::Windows::Forms::NumericUpDown());
         this->enrgLvl = (gcnew System::Windows::Forms::ProgressBar());
         this->botPnl = (gcnew System::Windows::Forms::Panel());
         this->botBox = (gcnew System::Windows::Forms::ComboBox());
         this->speedBar = (gcnew System::Windows::Forms::TrackBar());
         this->botLbl = (gcnew System::Windows::Forms::Label());
         this->xLbl = (gcnew System::Windows::Forms::Label());
         this->yLbl = (gcnew System::Windows::Forms::Label());
         this->speedLbl = (gcnew System::Windows::Forms::Label());
         this->energyLbl = (gcnew System::Windows::Forms::Label());
         this->coordLbl = (gcnew System::Windows::Forms::Label());
         this->botType = (gcnew System::Windows::Forms::TextBox());
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->startX))->BeginInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->startY))->BeginInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->speedBar))->BeginInit();
         this->SuspendLayout();
         // 
         // addBot
         // 
         this->addBot->Location = System::Drawing::Point(342, 34);
         this->addBot->Name = L"addBot";
         this->addBot->Size = System::Drawing::Size(75, 20);
         this->addBot->TabIndex = 0;
         this->addBot->Text = L"Add Bot";
         this->addBot->UseVisualStyleBackColor = true;
         this->addBot->Click += gcnew System::EventHandler(this, &mainForm::addBot_Click);
         // 
         // startX
         // 
         this->startX->Location = System::Drawing::Point(174, 33);
         this->startX->Name = L"startX";
         this->startX->Size = System::Drawing::Size(54, 20);
         this->startX->TabIndex = 1;
         // 
         // startY
         // 
         this->startY->Location = System::Drawing::Point(259, 33);
         this->startY->Name = L"startY";
         this->startY->Size = System::Drawing::Size(53, 20);
         this->startY->TabIndex = 2;
         // 
         // enrgLvl
         // 
         this->enrgLvl->Location = System::Drawing::Point(827, 31);
         this->enrgLvl->Name = L"enrgLvl";
         this->enrgLvl->Size = System::Drawing::Size(145, 20);
         this->enrgLvl->TabIndex = 4;
         // 
         // botPnl
         // 
         this->botPnl->Location = System::Drawing::Point(0, 73);
         this->botPnl->Name = L"botPnl";
         this->botPnl->Size = System::Drawing::Size(984, 639);
         this->botPnl->TabIndex = 5;
         this->botPnl->MouseHover += gcnew System::EventHandler(this, &mainForm::botPnl_MouseHover);
         // 
         // botBox
         // 
         this->botBox->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
         this->botBox->FormattingEnabled = true;
         this->botBox->Items->AddRange(gcnew cli::array< System::Object^  >(4) { L"Select Bot", L"Zombie", L"Vampire", L"Hunter" });
         this->botBox->Location = System::Drawing::Point(13, 32);
         this->botBox->Name = L"botBox";
         this->botBox->Size = System::Drawing::Size(121, 21);
         this->botBox->TabIndex = 6;
         this->botBox->SelectedIndexChanged += gcnew System::EventHandler(this, &mainForm::botBox_SelectedIndexChanged);
         // 
         // speedBar
         // 
         this->speedBar->Location = System::Drawing::Point(474, 22);
         this->speedBar->Name = L"speedBar";
         this->speedBar->Size = System::Drawing::Size(228, 45);
         this->speedBar->TabIndex = 7;
         // 
         // botLbl
         // 
         this->botLbl->AutoSize = true;
         this->botLbl->Location = System::Drawing::Point(61, 9);
         this->botLbl->Name = L"botLbl";
         this->botLbl->Size = System::Drawing::Size(23, 13);
         this->botLbl->TabIndex = 8;
         this->botLbl->Text = L"Bot";
         // 
         // xLbl
         // 
         this->xLbl->AutoSize = true;
         this->xLbl->Location = System::Drawing::Point(154, 34);
         this->xLbl->Name = L"xLbl";
         this->xLbl->Size = System::Drawing::Size(14, 13);
         this->xLbl->TabIndex = 9;
         this->xLbl->Text = L"X";
         // 
         // yLbl
         // 
         this->yLbl->AutoSize = true;
         this->yLbl->Location = System::Drawing::Point(239, 35);
         this->yLbl->Name = L"yLbl";
         this->yLbl->Size = System::Drawing::Size(14, 13);
         this->yLbl->TabIndex = 10;
         this->yLbl->Text = L"Y";
         // 
         // speedLbl
         // 
         this->speedLbl->AutoSize = true;
         this->speedLbl->Location = System::Drawing::Point(559, 9);
         this->speedLbl->Name = L"speedLbl";
         this->speedLbl->Size = System::Drawing::Size(57, 13);
         this->speedLbl->TabIndex = 11;
         this->speedLbl->Text = L"Bot Speed";
         // 
         // energyLbl
         // 
         this->energyLbl->AutoSize = true;
         this->energyLbl->Location = System::Drawing::Point(866, 9);
         this->energyLbl->Name = L"energyLbl";
         this->energyLbl->Size = System::Drawing::Size(59, 13);
         this->energyLbl->TabIndex = 12;
         this->energyLbl->Text = L"Bot Energy";
         this->energyLbl->TextAlign = System::Drawing::ContentAlignment::TopCenter;
         // 
         // coordLbl
         // 
         this->coordLbl->AutoSize = true;
         this->coordLbl->Location = System::Drawing::Point(192, 9);
         this->coordLbl->Name = L"coordLbl";
         this->coordLbl->Size = System::Drawing::Size(102, 13);
         this->coordLbl->TabIndex = 13;
         this->coordLbl->Text = L"Starting Coordinates";
         // 
         // botType
         // 
         this->botType->Location = System::Drawing::Point(776, 31);
         this->botType->Name = L"botType";
         this->botType->Size = System::Drawing::Size(45, 20);
         this->botType->TabIndex = 14;
         // 
         // mainForm
         // 
         this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
         this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
         this->ClientSize = System::Drawing::Size(984, 711);
         this->Controls->Add(this->botType);
         this->Controls->Add(this->coordLbl);
         this->Controls->Add(this->energyLbl);
         this->Controls->Add(this->speedLbl);
         this->Controls->Add(this->yLbl);
         this->Controls->Add(this->xLbl);
         this->Controls->Add(this->botLbl);
         this->Controls->Add(this->speedBar);
         this->Controls->Add(this->botBox);
         this->Controls->Add(this->botPnl);
         this->Controls->Add(this->enrgLvl);
         this->Controls->Add(this->startY);
         this->Controls->Add(this->startX);
         this->Controls->Add(this->addBot);
         this->MaximumSize = System::Drawing::Size(1000, 750);
         this->MinimumSize = System::Drawing::Size(1000, 750);
         this->Name = L"mainForm";
         this->Text = L"Bot Battles";
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->startX))->EndInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->startY))->EndInit();
         (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->speedBar))->EndInit();
         this->ResumeLayout(false);
         this->PerformLayout();

      }
#pragma endregion


   private: System::Void addBot_Click(System::Object^  sender, System::EventArgs^  e) {
               //code to add a bot to the panel
   }

private: System::Void botBox_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
            //code to set bot what will be added
}

private: System::Void botPnl_MouseHover(System::Object^  sender, System::EventArgs^  e) {
            //code to show energy level of bot that is hovered over
}


};
}
