% Brianna Muleski - Lab 5

% Facts:
positive_mammal:- [has_hair, produces_milk].

classify(L1, L2, mammal) :- L1 is positive_mammal, L2 = [].
