; Brianna Muleski - Program 3
%include "asm_io.inc"

segment .data

menu_msg		db "PLEASE SELECT AN OPTION FROM THE MENU:", 0xA
				db "--------------------------------------", 0xA 
				db "1. Enter a new string", 0xA
				db "2. Count the number of words in your string", 0xA
				db "3. Remove leading and duplicate blank characters in your string", 0xA
				db "4. Reverse the words in your string", 0xA
				db "5. Test if your string is a palindrome", 0xA
				db "6. Exit", 0
				   
enter_msg		db "Enter a new string: ", 0
choice_msg		db "Choice #: ", 0
exit_msg		db "Goodbye", 0
invalid_msg	    db "Please enter a valid option", 0
string_msg		db "Your string is: ", 0
blanks_msg	  	db "After removing leading and duplicate blank characters: ", 0
reverse_msg		db "After reversing the words: ", 0
palindrome_msg	db "The string: ", 0
pal_yes_msg		db " is a palindrome", 0
pal_no_msg		db " is not a palindrome", 0

words_msg	 	db "The number of words in: ", 0
word2_msg		db " is ", 0

max_string_size equ 100

array_rows		equ 50
array_columns	equ 100

segment .bss

string			resb max_string_size

string_length	resd 1
word_ct			resd 1
palindrome		resd 1

segment .text
        global  _asm_main
_asm_main:
	enter   0,0     ; setup routine
	pusha
	
; Print out the menu options
menu:
	mov 	eax, menu_msg
	call 	print_string
	call 	print_nl
	call	print_nl
	mov		eax, choice_msg
	call	print_string
	call 	read_int
	call	print_nl
	
	cmp 	eax, dword 1
	je  	print_newstring
	cmp 	eax, dword 2
	je  	print_wordcount
	cmp 	eax, dword 3
	je		print_removeblanks
	cmp 	eax, dword 4
	je 		print_reverse
	cmp 	eax, dword 5
	je 		test_palindrome
	cmp 	eax, dword 6
	je 		exit_option
	mov 	eax, invalid_msg
	call 	print_string
	call 	print_nl
	jmp 	menu
	
print_newstring:
;clear the old string value
	mov		ecx, max_string_size
	mov		ebx, string
	mov		esi, 0
clear_loop:
	mov		byte[ebx + esi], ' '
	add		esi, 1
	loop	clear_loop
	
; read string from user by calling read_string subprogram
	mov 	eax, enter_msg
	call 	print_string
	push 	string
	call 	read_string
	add 	esp,4
	push 	string
	call 	read_string
	add 	esp,4
	
; print the string
	mov 	eax, string_msg
	call 	print_string
	mov 	eax, string
	call 	print_string
	call 	print_nl
	
;find the length of the string
	push 	string
	call 	find_length
	add 	esp, 4
	mov 	dword[string_length], eax
	
;return to menu
	jmp		menu
	
print_wordcount:
;call subprogram word_count
	push	dword[string_length]
	push	string
	call	word_count
	add		esp, 8
	mov		dword[word_ct], eax
	
;print message with word count
	mov		eax, words_msg
	call	print_string
	mov		eax, string
	call	print_string
	mov		eax, word2_msg
	call	print_string
	mov		eax, dword[word_ct]
	call	print_int
	call	print_nl

;return to menu
	jmp		menu
	
print_removeblanks:
;call subprogram remove_blank
	mov		eax, string_msg
	call	print_string
	mov		eax, string
	call	print_string
	call	print_nl
	mov		eax, blanks_msg
	call	print_string
	
	push	dword[string_length]
	push 	string
	call 	remove_blank
	add 	esp, 8
	
;return to menu
	jmp 	menu
	
print_reverse:
;print initial output
	mov		eax, string_msg
	call	print_string
	mov		eax, string
	call	print_string
	call	print_nl
	mov		eax, reverse_msg
	call	print_string
	
;call subprogram reverse_word
	push	array_columns
	push	dword[string_length]
	push	string
	call	reverse_word
	add		esp, 12
	
;return to menu
	jmp		menu
	
test_palindrome:
;call subprogram is_palindrome
	mov		eax, dword[string_length]
	mov		ebx, dword 2
	cdq
	div		ebx
	push	eax
	push	string
	call	is_palindrome
	add		esp, 8
	mov		dword[palindrome], eax
	
;print the results
	mov		eax, palindrome_msg
	call	print_string
	mov		eax, string
	call	print_string
	cmp		dword[palindrome], 'y'
	jne		no_msg
	mov		eax, pal_yes_msg
	call	print_string
	jmp		return
	no_msg:
	mov		eax, pal_no_msg
	call	print_string
	
		
;return to menu
	return:
		call	print_nl
		jmp		menu

exit_option:
	
	mov 	eax, exit_msg
	call 	print_string
	call 	print_nl
	
	popa
	mov     eax, 0            ; return back to C
	leave                     
	ret

;.........................................................
;.........................................................
; A subprogram to return the length of a given string

segment .text
find_length:
	push 	ebp
	mov 	ebp, esp
	
	mov 	eax, 0
	mov 	ebx, [ebp + 8]
	mov 	esi, 0
	mov 	ecx, max_string_size
length_loop:
	cmp 	[ebx + esi], dword 0
	je 		length_exit
	inc 	eax
	add 	esi, 1
	loop 	length_loop

length_exit:
	pop 	ebp
	ret

;.........................................................
;.........................................................
; A subprogram to read a string from keyboard	

segment .text
read_string:
	push 	ebp
	mov 	ebp, esp
	
	mov 	ebx, [ebp + 8]
	mov 	esi, 0
	call 	print_nl
	mov 	ecx, max_string_size

get_string:
	call 	read_char
	cmp  	al, 0xA
	je 		exit
	inc		dword[string_length]
	mov 	[ebx + esi], al
	add 	esi, 1
	loop 	get_string
	
exit:
	mov 	byte[ebx + esi], 0
	pop 	ebp
	ret
	
;.........................................................
;.........................................................
; A subprogram to return the word count of the string

segment .text
word_count:
	push 	ebp
	mov 	ebp, esp
	
	mov		edx, -1			;space count
	mov 	eax, 0			;word count
	mov 	ebx, [ebp + 8]	;string
	mov 	esi, 0
	mov 	ecx, [ebp + 12]	;string_length
count_loop:
	cmp 	byte[ebx + esi], ' '
	jne		next_char
	cmp		edx, -1
	je		cont_loop
	inc		edx
	cmp		edx, 1
	jne		cont_loop
	inc 	eax
	jmp		cont_loop
	next_char:	
	mov		edx, 0
	cont_loop:
	add 	esi, 1
	loop 	count_loop

	pop 	ebp
	ret

;.........................................................
;.........................................................
; A subprogram to print the words in reverse order
segment .bss
tempeax			resd 1
word_array		resd array_rows * array_columns
num_col			resd 1
segment .text	
reverse_word:
	push 	ebp
	mov 	ebp, esp

	; mov		eax, [ebp + 16] ;number of columns
	; mov		dword[num_col], eax
	; mov		eax, 0			; row index
	; mov		edx, 0			; column index
	; mov		ebx, [ebp + 8]	;string
	; mov		ecx, [ebp + 12] ;string_length
	; mov		esi, 0
	; mov		ah, 'n'			;in word flag
; rev_loop:
	; mov		al, [ebx + esi]
	; cmp		al, ' '
	; je		next_row
	; mov		ah, 'y'
	; mov		dword[tempeax], eax
	; ;mul		eax, dword[num_col]
	; add		eax, edx
	; ;mov		word_array[eax], al	
	; add		edx, 1
	; jmp		end1
	; next_row:
	; cmp		ah, 'n'
	; jmp		end1
	; mov		ah, 'n'
	; add		eax, 1
	; ;mov		word_array[eax], 0	
	; mov		eax, dword[tempeax]
	; add		eax, 1
	; mov		edx, 0
	; end1:
	; add		esi, 1
	; loop	rev_loop
	
	; mov		ecx, eax
; print_outer_loop:
	; mov		ebx, 0
	; mul		eax, dword[num_col]
	; print_inner_loop:
		; add		eax, edx
		; ;mov		al, word_array[eax]
		; cmp		al, 0
		; je		end_outer
		; call	print_char
		; add		edx, 1
		; jmp		print_inner_loop
	; end_outer:
	; mov		al, ' '
	; call	print_char
	; dec		eax
	; loop	print_outer_loop	

	call	print_nl
	pop 	ebp
	ret
	
;.........................................................
;.........................................................
; A subprogram to remove extra spaces in the string

segment .text	
remove_blank:

	push 	ebp
	mov 	ebp, esp

	mov		ebx, [ebp + 8]	;string
	mov		ecx, [ebp + 12]	;string_length
	mov		esi, 0
	mov		edx, 0			;spaces count
	mov		ah, 'y'			;beginning of string flag
print_loop:
	cmp		byte[ebx + esi], ' '
	je		check_sp
	mov		al, [ebx + esi]
	call	print_char
	mov		ah, 'n'
	mov		edx, 0
	jmp		next
	check_sp:
	inc		edx
	cmp		ah, 'y'
	je		next
	cmp		edx, 1
	jg		next
	mov		al, [ebx + esi]
	call	print_char
	next:
	add		esi, 1
	loop	print_loop
	
	call	print_nl
	
	pop 	ebp
	ret
	
	
;.........................................................
; A subprogram to check if the string is a palindrome

segment .text	
is_palindrome:

	push 	ebp
	mov 	ebp, esp	
	
	mov		eax, 'y'
	mov		ebx, [ebp + 8]	;string
	mov		ecx, [ebp + 12]	;string_length / 2
	mov		edi, [ebp + 12]	;points to last char in string
	mov		esi, 0			;points to first char in string

pal_loop:
	mov		al, [ebx + esi]
	mov		ah, [ebx + edi]
	cmp		al, ' '
	je		move_esi
	cmp		al, 'z'
	jg		move_esi
	cmp		al, 'A'
	jl		move_esi
	cmp		ah, ' '
	je		move_edi
	cmp		ah, 'z'
	jg		move_edi
	cmp		ah, 'A'
	jl		move_edi
	cmp		ah, al
	je		move_both
	mov		eax, 'n'
	jmp		exit_sub
	move_esi:
	add		esi, 1
	jmp		end_loop
	move_edi:
	sub		edi, 1
	jmp		end_loop
	move_both:
	add		esi, 1
	sub		edi, 1
	end_loop:
	loop	pal_loop
	
exit_sub:
	pop 	ebp
	ret  