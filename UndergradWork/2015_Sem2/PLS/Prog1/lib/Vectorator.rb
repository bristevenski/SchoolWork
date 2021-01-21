# File: Vectorator.rb
# 
# Vectorator class represents an array of TVectors. The user can 
# add and delete TVectors from the array, sum all the TVectors in the array,
# and prints the TVectors in the array.
# Author: Brianna Muleski

require_relative 'TVector'

class Vectorator
  
  # Constructor - creates a new TVector array
  def initialize
    @vectlist = Array.new
  end

  # Run - runs through different commands and outputs the results, ends the
  # program when the user inputs "Q"
  def run
    done = false
    while !done
      str = gets
      ch = str[0,1]
      
      if ch == "S"
        sum
      elsif ch == "P"
        print
      elsif ch == "A"
        add(str[2, str.length])
      elsif ch == "D"
        delete(str[2, str.length])
      elsif ch == "Q"
        puts "Normal Termination of Program 1"
        done = true
      else
        puts ch + " is not a valid command! \n"
      end
    end
  end

  # Adds the vector represented by str to the vectorlist
  def add(str)
    v = TVector.new(str)
    @vectlist.insert(@vectlist.length, v)
    puts v.to_s + " was added to the list. \n"
  end
  
  # Adds all the vectors in vectorlist
  def sum
    sum = TVector.new
    temp = @vectlist
    i = 0
    while i < temp.length do
      sum = sum.plus(temp[i])
      i = i + 1
    end
    
    puts "The sum of the list is: " + sum.to_s + "\n"
  end

  # Deletes the vector represented by str from vectorlist, if it exists
  def delete(str)
    v = TVector.new(str)
    @vectlist.delete(v)
    puts "All vectors equal to " + v.to_s + " have been deleted. \n"
  end
  
  # prints the vectors in vectorlist, one per line
  def print
    puts "The list of vectors is: \n"
    for v in @vectlist
      puts v.to_s + "\n"
    end
  end
  
end
