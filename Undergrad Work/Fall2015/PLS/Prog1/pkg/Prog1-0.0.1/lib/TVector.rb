# TVector class

class TVector

  N = 6               # vector dimension, a constant
  attr_reader :vect   # Needed to write plus and override ==

  # Constructor - the optional parameter is a string representing a TVector.
  def initialize(str = nil)
    @vect = Array.new(N,0)	# This is the internal representation of the vector
    if( str != nil)
      tokens = str.to_s.delete("(").chop.split(",")
      # You finish this - tokens is an array of strings
      # Put them into Vect as integers
      @vect.clear
      for i in tokens
        i.delete(")")
        @vect << i.to_i
      end
    end
  end

  # override toString (to_s) method, 
  # so when it used with puts, it returns a string like (1,2,3,4,5,6)
  def to_s
    temp = "("
    while i < @vectlist.count() - 1 do
      temp += val.to_s + ','
    end
    temp += ")"
    return temp
  end

  # override ==
  def == (vec)
    # To be completed, it only return true when all pairs of elements 
	# from both vectors are equal, otherwise return false
    for val in @vect
      if (val != vec.val)
        return false
      end
    end
    
    return true
  end

  # Addition - Returns a new TVector which is the sum of itself and vec
  # Vec is a TVector
  def plus ( vec )
    newvect = TVector.new
    # To be completed
    newvect = @vect
    for val in newvect
      val += vec.val
    end
    return newvect
  end

end
