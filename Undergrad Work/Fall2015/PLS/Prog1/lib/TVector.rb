# File: TVector.rb
# 
# TVector class represents a vector and overrides to_s and == operations.
# TVectors can be added using vector addition.
# Author: Brianna Muleski

class TVector

  N = 6               # vector dimension, a constant
  attr_reader :vect   # Needed to write plus and override ==

  # Constructor - the optional parameter is a string representing a TVector.
  def initialize(str = nil)
    @vect = Array.new(N,0)	# This is the internal representation of the vector
    if( str != nil)
      tokens = str.to_s.delete("(").chop.split(",")
      vect.clear
      for i in tokens
        i.delete(")")
        vect << i.to_i
      end
    end
  end

  # override toString (to_s) method, 
  # so when it used with puts, it returns a string like (1,2,3,4,5,6)
  def to_s
    i = 0
    temp = "("
    while i < N - 1
        temp += @vect[i].to_s + ','
        i += 1
    end
    temp += vect[i].to_s + ")"
    return temp
  end

  # override ==
  def == (vec)
    i = 0
    while i < N
      if (self.vect[i] != vec.vect[i])
        return false
      end
      i += 1
    end
    
    return true
  end

  # Addition - Returns a new TVector which is the sum of itself and vec
  # Vec is a TVector
  def plus ( vec )
    newvect = TVector.new
    # To be completed
    newvect = self
    i = 0
    while i < N
      newvect.vect[i] += vec.vect[i]
      i += 1
    end
    return newvect
  end

end
