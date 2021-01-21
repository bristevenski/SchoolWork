; Brianna Muleski - Program 4
%include "asm_io.inc"
%include "string.asm"

max_string_size	equ 10
queue_size		equ 4

struc movie
	.title:		resb max_string_size
	.price:		resd 1
	.size:
endstruc

segment .data

menu_msg		db "PLEASE SELECT AN OPTION FROM THE MENU:", 0xA
				db "--------------------------------------", 0xA 
				db "1. Add a movie to the queue", 0xA
				db "2. Remove a movie from the queue", 0xA
				db "3. Check if the queue is empty", 0xA
				db "4. Check if the queue is full", 0xA
				db "5. Clear the queue", 0xA
				db "6. Display the queue", 0xA
				db "7. Export the queue", 0xA
				db "8. Exit", 0

invalid_msg	    db "Please enter a valid option", 0
exit_msg		db "Goodbye", 0
full_msg		db "The queue is full", 0
empty_msg		db "The queue is empty", 0
not_full_msg	db "The queue is not full", 0
not_empty_msg	db "The queue is not empty", 0
choice_msg		db "Choice #: ", 0

size_msg		db "current size: ", 0
front_msg		db "front: ", 0
rear_msg		db "rear: ", 0

current_size	dd 0

segment .bss

movie_queue		resb movie.size * queue_size
rear			resd 1
front			resd 1
movie_size1		resd 1

segment .text
        global  _asm_main
_asm_main:
	enter   0,0     ; setup routine
	pusha
	
	mov		dword[movie_size1], movie.size
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
	je  	add_sub
	cmp 	eax, dword 2
	je  	remove_sub
	cmp 	eax, dword 3
	je		empty_sub
	cmp 	eax, dword 4
	je 		full_sub
	cmp 	eax, dword 5
	je 		clear_sub
	cmp 	eax, dword 6
	je 		display_sub
	cmp		eax, dword 7
	je		export_sub
	cmp		eax, dword 8
	je		exit_prog
	mov 	eax, invalid_msg
	call 	print_string
	call 	print_nl
	jmp 	menu
	
;call the subprogram to add a movie to the queue
add_sub:
	push	movie_queue
	call	enqueue
	add		esp, 4
	jmp		menu
	
;call the subprogram to remove a movie from the queue
remove_sub:
	push	movie_queue
	call	dequeue
	add		esp, 4
	jmp		menu
	
;call the subprogram to check if the queue is empty
empty_sub:
	push	movie_queue
	call	is_empty
	add		esp, 4
	cmp		ah, 't'
	je		queue_empty
	mov		eax, not_empty_msg
	call	print_string
	call	print_nl
	jmp		menu
queue_empty:
	mov		eax, empty_msg
	call	print_string
	call	print_nl	
	jmp		menu
	
;call the subprogram to check if the queue is full
full_sub:
	push	movie_queue
	call	is_full
	add		esp, 4
	cmp		ah, 't'
	je		queue_full
	mov		eax, not_full_msg
	call	print_string
	call	print_nl
	jmp		menu
queue_full:
	mov		eax, full_msg
	call	print_string
	call	print_nl	
	jmp		menu
	
;call the subprogram to clear the queue
clear_sub:
	push	movie_queue
	call	clear
	add		esp, 4
	jmp		menu
	
;call the subprogram to display the queue
display_sub:
	push	movie_queue
	call	display
	add		esp, 4
	jmp		menu
	
;call the subprogram to export the queue into an external file
export_sub:
	push	movie_queue
	call	export_queue
	add		esp, 4
	jmp		menu
	
;exit the program
exit_prog:
	mov		eax, exit_msg
	call	print_string
	call	print_nl
	call	print_nl
	
	popa
	mov     eax, 0	; return back to C
	leave                     
	ret
	
;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram enqueue - takes the movie_queue, reads movie title
; and price, creates the movie object and adds the movie to the
; end of the queue. If the queue is full then it prints an error
; message and returns to main.
segment .data

enter_title_msg	db "Enter the title of the movie: ", 0
enter_price_msg	db "Enter the price of the movie: ", 0

segment .bss

temp_ebx	resd 1
temp_movie	resb movie.size
empty_str	resb max_string_size
str_length	resd 1

segment .text
enqueue:
	push	ebp
	mov		ebp, esp
	
	mov		ebx, [ebp + 8]
	mov		dword[temp_ebx], ebx
	
	cmp		dword[current_size], queue_size
	je		full
	
; read the movie information
	push	empty_str
	call	read_string
	add		esp, 4
	
	mov		eax, enter_title_msg
	call	print_string
	call	print_nl
	mov		ebx, temp_movie
	add		ebx, movie.title
	push	ebx
	call	read_string
	add		esp, 4
	call	print_nl
	
	mov		eax, enter_price_msg
	call	print_string
	call	print_nl
	call	read_int
	mov		[temp_movie + movie.price], eax
	
; insert the created movie object into the queue (currently where rear is pointing)
insert:
	mov		eax, dword[rear]
	mul		dword[movie_size1]
	mov		ebx, [temp_ebx]
	add		ebx, eax
	
	mov		ebx, temp_movie
	add		ebx, movie.title
	push	ebx
	call	LengthIs
	add		esp, 4
	mov		dword[str_length], eax
	
	mov		ebx, temp_movie
	add		ebx, movie.title
	push	ebx
	mov		eax, dword[rear]
	mul		dword[movie_size1]
	mov		ebx, [temp_ebx]
	add		ebx, eax
	
	add		ebx, movie.title
	push	ebx
	push	dword[str_length]
	call	strcpy
	add		esp, 12
	
	mov		eax, dword[rear]
	mul		dword[movie_size1]
	mov		ebx, [temp_ebx]
	add		ebx, eax
	mov		eax, [temp_movie + movie.price]
	mov		[ebx + movie.price], eax
	
; increment current_size, front, and rear
	mov		eax, dword[current_size]	
	add		eax, 1
	mov		dword[current_size], eax
	mov		eax, dword[rear]
	cmp		eax, queue_size
	je		reset
	add		eax, 1
	mov		dword[rear], eax
	jmp		exit1
reset:
	mov		dword[rear], 1
	jmp		exit1
	
; print full message
full:
	mov		eax, full_msg
	call	print_string
	call	print_nl
	call	print_nl
	
exit1:
	pop		ebp
	ret
	
;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram dequeue - takes the movie_queue and deletes the
; first movie in the queue. If the queue is empty then it prints 
; an error message and returns to main.
segment .data

remove_msg	db " was removed from the queue", 0

segment .text
dequeue:
	push	ebp
	mov		ebp, esp
	
	mov		ebx, [ebp + 8]
	
	cmp		[current_size], dword 0
	je		empty
	
;find front of queue
	mov		eax, dword[front]
	dec		eax
	mul		dword[movie_size1]
	add		ebx, eax

	add		ebx, movie.title
	mov		eax, ebx
	call	print_string
	mov		eax, remove_msg
	call	print_string
	call	print_nl
	call	print_nl
	
	mov		[ebx + movie.title], dword "removed"
	mov		[ebx + movie.price], dword 0
	
;update front and current_size
	dec		dword[current_size]
	cmp		dword[current_size], 0
	jne		not_empty
	mov		dword[front], 0
	mov		dword[rear], 0
	jmp		exit2
not_empty:
	cmp		dword[front], movie.size
	jng		increment
	mov		dword[front], 1
	jmp		exit2
increment:
	mov		eax, dword[front]
	add		eax, 1
	mov		dword[front], eax
	jmp		exit2
	
	
	
; print empty message
empty:
	mov		eax, empty_msg
	call	print_string
	call	print_nl
	call	print_nl
	
exit2:
	pop		ebp
	ret
	
;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram is_empty - takes the movie_queue and checks if the
; queue is empty or not and returns the result.
segment .text
is_empty:
	push	ebp
	mov		ebp, esp
	
	cmp		dword[current_size], 0
	jne		false
	mov		ah, 't'
	jmp		exit3
false:
	mov		ah, 'f'
	
exit3:
	pop		ebp
	ret

;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram is_full - takes the movie_queue and checks if the
; queue is full or not and returns the result.
segment .text
is_full:
	push	ebp
	mov		ebp, esp
	
	mov		eax, dword[movie_size1]
	cmp		dword[current_size], eax
	jne		not_full
	mov		ah, 't'
	jmp		exit4
not_full:
	mov		ah, 'f'
	
exit4:
	pop		ebp
	ret

;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram clear - takes the movie_queue and resets the
; current_size, front, and rear.
segment .data

clear_msg	db "The queue has been cleared.", 0

segment .text
clear:
	push	ebp
	mov		ebp, esp
	
	cmp		dword[current_size], 0
	je		empty2
	
	mov		ecx, dword[current_size]
	cmp		ecx, dword 0
	je		empty1
	mov		esi, [ebp + 8]
clear_loop:
	mov		[esi + movie.title], dword "0"
	mov		[esi + movie.price], dword 0
	add		esi, movie.size
	loop	clear_loop
	
	mov		dword[current_size], 0
	mov		dword[rear], 0
	mov		dword[front], 0
	jmp		print_result
	
empty2:
	mov		eax, empty_msg
	call	print_string
	call	print_nl
	jmp		exit5
	
print_result:
	mov		eax, clear_msg
	call	print_string
	call	print_nl
	
exit5:
	pop		ebp
	ret

;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram display - takes the movie_queue and prints the 
; information of each movie in the queue, one movie per line
segment .data

movie_list_msg	db "******* Movie List *******",0xA
				db "Movie Title", 0x9, "Movie Price", 0xA
				db "--------------------------", 0
				
price_format	db ".00", 0
spacing			db "         ", 0
segment .text
display:
	push	ebp
	mov		ebp, esp
	
	mov		ecx, dword[current_size]
	cmp		ecx, dword 0
	je		empty1
	call	print_nl
	mov		eax, movie_list_msg
	call	print_string
	call	print_nl
	mov		ebx, [ebp + 8]
	mov		eax, dword[front]
	dec		eax
	mul		dword[movie_size1]
	add		ebx, eax
	mov		esi, ebx
print_loop:
	mov		ebx, esi
	add		ebx, movie.title
	mov		eax, ebx
	call	print_string
	mov		eax, spacing
	call	print_string
	mov		al, '$'
	call	print_char
	mov		eax, [esi + movie.price]
	call	print_int
	mov		eax, price_format
	call	print_string
	call	print_nl
	jmp		end_loop
next:
	inc		ecx
end_loop:
	add		esi, movie.size
	loop	print_loop
	
	call	print_nl
	call	print_nl
	jmp		exit6
	
empty1:
	mov		eax, empty_msg
	call	print_string
	call	print_nl
	
exit6:
	pop		ebp
	ret
	
;--------------------------------------------------------------
;--------------------------------------------------------------
; subprogram export_queue - takes the movie_queue and prints the 
; information of each movie in the queue in an external file.
segment .data

file_name	db "out.txt", 0

segment .bss

buff		resb movie.size * queue_size
lenlist		equ movie.size * queue_size + queue_size
temp_ebx1	resd 1

segment .text
export_queue:
	push	ebp
	mov		ebp, esp
	
	mov		ebx, [ebp + 8]
	mov		dword[temp_ebx1], ebx
	
	mov 	ecx, dword[current_size]
	mov 	esi, 0
start1:
	mov 	edi, ecx
	mov 	ecx, movie.size
	sub 	ecx, 4
	mov 	al, [ebx + esi]
	add 	al, '0' 
	mov 	[buff + esi], al
	add 	esi, 3
start2:
	mov 	al, [ebx + esi]
	mov 	[buff + esi], al
	inc 	esi
	loop 	start2
	mov 	ecx, edi
	mov 	[buff + esi], byte 0xA
	inc 	esi
loop start1
	mov 	[buff + esi], byte 0
	
	mov 	ebx, file_name
	mov 	ecx, 2
	mov 	eax, 5
	int 	0x80
	
	mov 	ebx, eax
	mov 	ecx, buff
	mov 	edx, lenlist
	mov 	eax, 4           
	int 	0x80 

	mov 	ebx, file_name
	mov 	eax, 6
	int 	0x80 

	pop		ebp
	ret
	