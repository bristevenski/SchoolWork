% Lab 5 - Brianna Muleski

% Facts:

has_long_incisors :- gnaws_on_wood.
eats_plants :- gnaws_on_wood.



% Partial Classification facts:
fact(mammal, Facts) :- lists_equal(Facts, [has_hair, produces_milk]).
fact(rodent, Facts) :- lists_equal(Facts, [has_hair, produces_milk, has_long_incisors]).
fact(herbivore, Facts) :- lists_equal(Facts, [eats_plants]).
fact(carnivore, Facts) :- lists_equal(Facts, [eats_meat]).
fact(omnivore, Facts) :- lists_equal(Facts, [eats_plants, eats_meat]).
fact(bird, Facts) :- lists_equal(Facts, [has_feathers]).

% Full Classification facts:
fact(raccoon, Facts) :- lists_equal(Facts, [eats_meat, eats_plants, lives_near_water, has_bushy_tail]).
fact(muskrat, Facts) :- lists_equal(Facts, [lives_near_water, has_hair, produces_milk, has_long_incisors]).
fact(squirrel, Facts) :- lists_equal(Facts, [has_hair, produces_milk, has_long_incisors, has_bushy_tail]).
fact(rat, Facts) :- lists_equal(Facts, [has_hair, produces_milk, has_long_incisors]).
fact(chipmunk, Facts) :- lists_equal(Facts, [has_hair, produces_milk, has_long_incisors, striped]).
fact(wolverine, Facts) :- lists_equal(Facts, [has_hair, produces_milk, eats_meat, has_bushy_tail]).
fact(eagle, Facts) :- lists_equal(Facts, [has_feathers, eats_meat, can_fly, has_hooked_beak]).
fact(ostrich, Facts) :- lists_equal(Facts, [has_feathers, eats_plants]).
fact(penguin, Facts) :- lists_equal(Facts, [has_feathers, eats_meat, can_swim]).



% Partial Classification falsehoods:
falsehood(mammal, []).
falsehood(rodent, []).
falsehood(omnivore, []).
falsehood(bird, []).

falsehood(herbivore, Falsehoods) :- lists_equal(Falsehoods, [eats_meat]).
falsehood(carnivore, Falsehoods) :- lists_equal(Falsehoods, [eats_plants]).

% Full Classification falsehoods:
falsehood(squirrel, []).
falsehood(raccoon, []).

falsehood(muskrat, Falsehoods) :- lists_equal(Falsehoods, [has_bushy_tail]).
falsehood(rat, Falsehoods) :- lists_equal(Falsehoods, [has_bushy_tail, striped]).
falsehood(chipmunk, Falsehoods) :- lists_equal(Falsehoods, [has_bushy_tail]).
falsehood(wolverine, Falsehoods) :- lists_equal(Falsehoods, [eats_plants]).
falsehood(eagle, Falsehoods) :- lists_equal(Falsehoods, [eats_plants]).
falsehood(ostrich, Falsehoods) :- lists_equal(Falsehoods, [can_fly, can_swim, eats_meat]).
falsehood(penguin, Falsehoods) :- lists_equal(Falsehoods, [eats_plants, can_fly]).



% Predicates:
lists_equal(List1, List2) :- msort(List1, Sorted1), msort(List2, Sorted2), Sorted1 = Sorted2.
classify(L1, L2, X) :- fact(X, L1), falsehood(X, L2). % L1 = list of facts, L2 = list of falsehoods, X = type of animal



% Partial Classification Predicates:
% X = animal to classify
is_mammal(X) :- member(X, [rodent, chipmunk, muskrat, squirrel, rat, wolverine]), !.
is_rodent(X) :- member(X, [muskrat, squirrel, rat, chipmunk]), !.
is_bird(X) :- member(X, [eagle, ostrich, penguin]), !.
is_omnivore(X) :- member(X, [raccoon]).
is_herbivore(X) :- member(X, [ostrich]).
is_carnivore(X) :- member(X, [wolverine, eagle, penguin]).