; Name: Brianna Muleski
; File: firsthw.asm
; This program prompts user for two integers and prints their sum, difference, product, and quotient

%include "asm_io.inc"

segment .data

prompt1 db "Enter first integer: ", 0
prompt2 db "Enter second integer: ", 0

summsg 	db 	"The sum is: ", 0
difmsg 	db 	"The difference is: ", 0
prodmsg db 	"The product is: ", 0
quomsg 	db 	"The quotient is: ", 0

segment .bss

input1 resd 1
input2 resd 1

segment .text
        global  _asm_main
_asm_main:
        enter   0,0               ; setup routine
        pusha

		;get numbers from user
        mov     eax, prompt1      
        call    print_string

        call    read_int          
        mov     [input1], eax     

        mov     eax, prompt2      
        call    print_string

        call    read_int          
        mov     [input2], eax     

		;addition
        mov     eax, [input1]     
        add     eax, [input2]     
        mov     ebx, eax    

        mov		eax, summsg
		call	print_string
		
		mov		eax, ebx
		call	print_int
		call	print_nl

		;subtraction
		mov		eax, [input1]
		sub		eax, [input2]
		mov		ebx, eax
		
		mov		eax, difmsg
		call	print_string
		
		mov		eax, ebx
		call	print_int
		call	print_nl
		
		;multiplication
		mov		eax, [input1]
		imul	eax, [input2]
		mov		ebx, eax
		
		mov		eax, prodmsg
		call	print_string
		
		mov		eax, ebx
		call	print_int
		call	print_nl
		
		;division
		mov		eax, [input1]
		cdq		
		mov		ebx, [input2]
		idiv	ebx
		mov		ebx, eax
		
		mov		eax, quomsg
		call	print_string
		
		mov		eax, ebx
		call	print_int
		call	print_nl
		
		;registry and memory dump
		dump_regs 1
		dump_mem 2, summsg, 1
		
        popa
        mov     eax, 0            ; return back to C
        leave                     
        ret

