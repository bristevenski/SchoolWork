;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-intermediate-lambda-reader.ss" "lang")((modname lab3-muleskib) (read-case-sensitive #t) (teachpacks ()) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ())))
;;Problem 1: function dot-product
;;dot-product: list(num) X list(num) -> number
;;  Takes two lists of numbers (either integers or floats) and returns the sum of the products
;;  The result is a number representing the sum of the products
(define (dot-product list1 list2)
  (apply + ( map * list1 list2)))

;;Problem 2: function home-wins
;;home-wins: results -> number
;;  Takes two numbers, first one is the score of the home team and the second one is the score
;;    of the away team, and determines who won the game.
;;  The result is the number of home team wins.
(define (home-wins games)
  (apply + (map (lambda (x) (if (> (results-home x) (results-away x)) 1 0)) games)))

;;Problem 2: struct results
;;results: number X number
;;  Defines the results of a ball game with the following operations: make-results,
;;    results-home, and results-away
(define-struct results (home away))

;;Problem 3: function above-average
;;above-average: list(num) -> list(num)
;;  Determines the numbers in the list that are above the average of the list
;;  The result is the numbers in the list that are above-average
(define (above-average list)
  (filter (lambda (x) (> x (/ (apply + list) (length list)))) list))

;;Problem 4: function value-by-layers
;;value-by-layers: tree(num) -> list(num)
;;  Traverses a tree and finds the values in each node.
;;  The result is a list of all values in the tree in a top-down and left-right order.
;(define (values-by-layers tree)
;  (if (not (empty? tree))
;  (let ([open (make-node make-tip (node-left tree) (node-right tree))] [next (node-value tree)] [closed (make-tip)])
;    (if (not (empty? open))
;           (let ([next (node-value open)] [kids (union open closed)] [closed (union closed next)]
;            [open (make-node make-tip (make-node make-tip (node-left open) (node-right open)) ((union (open closed))))]) 
;             (values-by-layers open)) empty)) empty))
  
;;Problem 4: union helper function
;;union: list X list -> list
;; Finds the list of values in both lists given            
;(define (union list1 list2)
;  (cond ((empty? list1) list2)
;        ((empty? list2) list1)
;        ((equal? (first list1) (first list2)) (cons (first list1) (union (rest list1) (rest list2))))))

;;Probelm 4: struct node
;;node: number X node X node
;;  Defines a tree node where the value is given, then the left node and the right node.
(define-struct node (value left right))
  
;;Probelm 4: struct tip
;;tip: number X node X node
;;  Defines an empty tree node.
(define-struct tip ())
 

;(check-expect (dot-product '(7 10 -3 2.2) '(3.5 8 0 1)) 106.7)
;(check-expect (home-wins (list (make-results 109 98))) 1)
;(check-expect (home-wins (list (make-results 95 98)
;                               (make-results 89 100)
;                               (make-results 92 81)
;                               (make-results 106 90)
;                               (make-results 83 83))) 2)
;(check-expect (above-average '(3 -6 9 12 0 44)) '(12 44))
;(check-expect (above-average empty) empty)
;(check-expect (above-average '(5)) empty)
;(check-expect (values-by-layers (make-node 'a (make-node 'b (make-tip) (make-tip)) (make-tip))) '(a b))