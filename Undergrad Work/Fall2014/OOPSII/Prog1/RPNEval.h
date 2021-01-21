//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class represents an RPN evaluator. This class can
//          create a new RPN evaluator, process a single expression,
//          check the validity of the expression, return the value of
//          the expression and print the intermediate results of a 
//          single expression.
//-------------------------------------------------------------------
#ifndef __RPNEVAL_H
#define __RPNEVAL_H

#include "stack.h"
#include "queue.h"

typedef float OperandType;

class RPNEval
{
public:

	//------------------------------------------------------------------
	// Constructor: Sets valid to false.
	//------------------------------------------------------------------
	RPNEval() { valid = false; }

	//------------------------------------------------------------------
	// Reads and processes the next RPN expression from the standard 
   // input.
	//------------------------------------------------------------------
	void ProcessExpression();

	//------------------------------------------------------------------
	// Returns true if RPN expression is valid, false otherwise.
	//------------------------------------------------------------------
	bool IsValid() const { return valid; }

	//------------------------------------------------------------------
	// Returns the value of the RPN expression if it is valid.
	// Returns garbage if RPN expression is not valid.
	//------------------------------------------------------------------
	OperandType Value() const { return answer; }

	//------------------------------------------------------------------
	// Print out the intermediate results to the standard
	// output, with one space after each result.
	// Does NOT print any header or any newlines.
	//------------------------------------------------------------------
	void PrintIntermediateResults();

private:
	bool valid;                   
	OperandType answer;           
	Stack stack;                  
	Queue queue;                  

   //----------------------------------------------------------------
   // Processes the character and performs the mathematical function
   // that it represents.
   //----------------------------------------------------------------
   bool ProcessOperator(char ch);

   //----------------------------------------------------------------
   // Reads the number in, outputs it for the expression, and pushes
   // it onto the stack.
   //----------------------------------------------------------------
   void ProcessOperand();

   //----------------------------------------------------------------
   // Processes the character input and determines if it is an
   // operand, operator, end of expression (#), or invalid input. It 
   // also keeps track of the expressions validity.
   //----------------------------------------------------------------
   bool ProcessChar();

   //----------------------------------------------------------------
   // Finds the sum of the two parameters and adds the answer
   // to the stack and queue.
   //----------------------------------------------------------------
   void Add(float x, float y);

   //----------------------------------------------------------------
   // Finds the difference of the two parameters and adds the answer
   // to the stack and queue.
   //----------------------------------------------------------------
   void Subtract(float x, float y);

   //----------------------------------------------------------------
   // Finds the product of the two parameters and adds the answer
   // to the stack and queue.
   //----------------------------------------------------------------
   void Multiply(float x, float y);

   //----------------------------------------------------------------
   // Finds the quotient of the two parameters and adds the answer
   // to the stack and queue. Returns false if x is zero, true
   // otherwise.
   //----------------------------------------------------------------
   bool Divide(float x, float y);
};

#endif