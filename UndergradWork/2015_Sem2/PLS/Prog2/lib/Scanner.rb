# Scanner.rb
# Holds the Scanner class.
# Author: Brianna Muleski

# Used to scan through a string, one character at a time.
class Scanner

    # Initializes the scanner object. Gets the current line of the input.
    def initialize
        @cur_line = gets
    end # end of initialize

    # Puts str back into the current line.
    def push_back(str)
        @cur_line = str + @cur_line
    end # end of push_back()

    # Gets the next character in the current line. if the current line is empty
    # then gets the next line before getting the next character.
    def get_next_char
        if @cur_line.length == 0
            @cur_line = gets
        end
        char = @cur_line[0]
        @cur_line = @cur_line[1, @cur_line.length - 1]
        return char
    end # end of get_next_char
end # end of Scanner class
