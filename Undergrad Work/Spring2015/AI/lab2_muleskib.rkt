;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-intermediate-lambda-reader.ss" "lang")((modname lab2_muleskib) (read-case-sensitive #t) (teachpacks ()) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ())))
;;Lab 2 - Brianna Muleski

;;Problem 1: function roots
;;roots: number X number X number -> list(number)
;;  Calculates the roots using the quadratic formula given a, b, and c.
;;  The result is a list of two if the roots are different; one if the same.
(define (roots a b c)
  (let ([inside (- (* b b) (* 4 a c))])
  (let ([pos (/ (+ (* b -1) (sqrt inside)) (* 2 a))])
  (let ([neg (/ (- (* b -1) (sqrt inside)) (* 2 a))])
  (if (equal? pos neg)
      (list pos)
      (list pos neg))))))

;;Problem 2: function future-date
;;future-date: number X number X number X number -> list(number)
;;  Calculates the future date from the given year, month, day by the number of days given.
;;  The result is a list of the future date's year, month, and day.
(define (future-date year month day num-days)
  (let ([month-days (total-days month year)])
  (cond ( (< (+ day num-days) month-days) (list year month (+ day num-days)))
        ( (and (> (+ day num-days) month-days) (equal? month 12)) (future-date (add1 year) 1 0 (- num-days (- month-days day))))
        ( (and (> (+ day num-days) month-days) (< month 12)) (future-date year (add1 month) 0 (- num-days (- month-days day)))))))
  
;;Problem 2: helper function
;;total-days: number X number -> number
;;  Determines the total number of days in the given month.
;;  The result is a number representing the total number of days in the given month.
(define (total-days month year)
  (cond ( (or (equal? month 4) (equal? month 6) (equal? month 9) (equal? month 11))  30 )
        ( (and (equal? month 2) (leap-year? year)) 29)
        ( (and (equal? month 2) (not (leap-year? year))) 28)
        ( else 31 )))

;;Problem 2: helper function
;;leap-year?: number -> boolean
;;  Determines whether the given year is a leap year.
;;  The result is true if the given year is a leap year, false otherwise.
(define (leap-year? year)
  (cond ( (and (equal? (remainder year 4) 0) (not (equal? (remainder year 100) 0))) true)
        ( (equal? (remainder year 400) 0) true)
        ( else false )))

;;Problem 3: function flat
;;flat: list -> list
;;  Recreates the given list into one list with all its amotic items in original order.
;;  The result is the recreated list.
(define (flat list)
  (if (not (empty? list))
      (let ([cur (first list)])
        (if (atomic? cur)
            (cons cur (flat (rest list)))
            (append (flat cur) (flat (rest list)))))
      empty))

;;Problem 3: helper function
;;atomic?: element -> boolean
;;  Determines whether the given element is atomic or not
;;  The result is true if the given element is atomic, false otherwise.
(define (atomic? x)
  (if (not (or (empty? x) (cons? x)))
      true
      false))




