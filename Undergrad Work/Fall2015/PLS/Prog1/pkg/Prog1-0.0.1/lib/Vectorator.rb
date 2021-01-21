require_relative 'TVector'

class Vectorator
  
  def initialize
    @vectlist = Array.new
  end

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

  def add(str)
    v = TVector.new(str)
    @vectlist.insert(@vectlist.count(), v)
    puts v.to_s + " was added to the list. \n"
  end
  
  def sum
    sum = TVector.new
    i = 0
    
    while i < @vectlist.count() - 1 do
      temp = TVector.new
      temp = @vectlist[i].plus(@vectlist[i + 1])
      sum = sum.plus(temp)
      i = i + 1
    end
    
    puts "The sume of the list is: " + sum.to_s + "\n"
  end

  def delete(str)
    v = TVector.new(str)
    @vectlist.delete(str)
    puts "All vectors equal to " + v.to_s + " have been deleted. \n"
  end
  
  def print
    puts "The list of vectors is: \n"
    for v in @vectlist
      puts v.to_s + "\n"
    end
  end
  
end
